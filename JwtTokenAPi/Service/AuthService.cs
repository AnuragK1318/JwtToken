using JwtTokenAPi.Abstract;
using JwtTokenAPi.Context;
using JwtTokenAPi.Domain;
using JwtTokenAPi.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenAPi.Service
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly UserContext userContext;

        public AuthService(IConfiguration configuration,UserContext userContext)
        {
            this.configuration = configuration;
            this.userContext = userContext;
        }

        public async Task<User> RegisterAsync(UserDto request)
        {
            //check if user exists or not
            var existinguser = await userContext.Users.AnyAsync(x => x.Username == request.Username);

            //if user already exist throw an error
            if (existinguser)
            {
                throw new Exception("User already exists");
            }

            // Create a new User object and assign the username from the request
            var user = new User { 
                Username = request.Username 
            };

            // Create an instance of PasswordHasher to hash the password securely
            var passwordHasher = new PasswordHasher<User>();
            // Convert the plain text password into a hashed version and store it
            user.PasswordHash = passwordHasher.HashPassword(
                user,               // user object (used internally by hasher)
                request.Password);  

            //save to database
            userContext.Users.Add(user);
            await userContext.SaveChangesAsync();
            return user;
        }

        public async Task<string?> LoginAsync(UserDto request)
        {
            // Try to find a user in the database with the given username
            var user = await userContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            // If no user is found, throw an error
            if (user == null)
            {
                throw new Exception($"No user found with {request.Username}");
            }
            // Create an instance of PasswordHasher to verify the password
            var passwordHasher = new PasswordHasher<User>();
            // Compare the stored hashed password with the entered password
            var result = passwordHasher.VerifyHashedPassword(
                user,                   // user object (used internally by hasher)
                user.PasswordHash,      // hashed password stored in DB
                request.Password);      // password entered by the user

            // If password verification fails, throw an error
            if (result==PasswordVerificationResult.Failed)
            {
                throw new Exception("Incorrect Password!!");
            }
            //Generate JWt token for authenticated user
            string token = CreateToken(user);
            return token;
        }

        public string CreateToken(User user)
        {
            //details about who are you
            var claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Name,user.Username),
                 new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                 new Claim(ClaimTypes.Role,user.Role)
            };
            //An encryption key
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("appSettings:Key")!));
            //sign with an encryption algorith
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("appSettings:Issuer"),
                audience: configuration.GetValue<string>("appSettings:Audience"),
                claims : claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}

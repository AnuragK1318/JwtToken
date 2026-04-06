using JwtTokenAPi.Abstract;
using JwtTokenAPi.Domain;
using JwtTokenAPi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            try 
            {
                await authService.RegisterAsync(request);
                return Ok("User registered successfully");
            }
            catch(Exception ex) 
            {
                    return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            try
            {
                var token = await authService.LoginAsync(request);
                return Ok(token);
            }
            catch(Exception ex) 
            {
                return BadRequest("Invalid Username or Password!!!");
            }
        }

        [HttpGet]
        [Authorize]
        [Route("AuthCheck")]
        public ActionResult AuthCheck()
        {
            return Ok("Auth Check");
        }

        [HttpGet]
        [Route("AdminCheck")]
        [Authorize(Roles ="Admin")]
        public ActionResult AdminCheck()
        {
            return Ok("Admin Role Auth Check");
        }

    }
}

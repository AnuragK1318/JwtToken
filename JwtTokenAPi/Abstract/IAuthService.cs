using JwtTokenAPi.Domain;
using JwtTokenAPi.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JwtTokenAPi.Abstract
{
    public interface IAuthService
    {
        public Task<User> RegisterAsync(UserDto request);
        public Task<string?> LoginAsync(UserDto request);
        public string CreateToken(User user);

    }
}

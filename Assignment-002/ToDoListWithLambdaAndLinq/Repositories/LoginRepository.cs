using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _config;
        private readonly IUserRepository _userService;

        public LoginRepository(IConfiguration config, IUserRepository userService)
        {
            _config = config;
            _userService = userService;
        }

        public async Task<string> Login(LoginModel login)
        {
            var userFound = await _userService.GetUserByEmail(login.Email);
            if (userFound == null)
            {
                throw new Exception("User not found");
            }

            var passwordIsValid = BCrypt.Net.BCrypt.EnhancedVerify(login.Password, userFound.Password);
            if (!passwordIsValid)
            {
                throw new Exception("Password incorrect");
            }

            var secretKey = _config.GetSection("Jwt:Key").Get<string>();

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new Exception("Token configuration not found");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userFound.Username),
                new Claim(ClaimTypes.Email, userFound.Email),
                new Claim(ClaimTypes.NameIdentifier, userFound.Id.ToString())
            };

            var tokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials
            };

            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token);
        }
    }
}

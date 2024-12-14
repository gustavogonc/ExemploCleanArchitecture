using ExemploCleanArchitecture.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExemploCleanArchitecture.Infra.IoC.Services.Security
{
    public class TokenGenerator : ITokenGenerator
    {
        private string _signinKey = string.Empty;
        private int _validHours = 0;
        public TokenGenerator(string signInKey, int validHours)
        {
            _signinKey = signInKey;
            _validHours = validHours;
        }
        public string GenerateToken(string email, string name)
        {
            var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, name),
            new(ClaimTypes.Email, email)
        };

            var signinKey = TokenHandler.JwtTokenHandler.SecurityKey(_signinKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                Expires = DateTime.Now.AddHours(_validHours)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}

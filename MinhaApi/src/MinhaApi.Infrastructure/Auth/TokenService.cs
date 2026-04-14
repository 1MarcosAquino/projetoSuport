using System.Text;
using MinhaApi.Application.Interfaces;
using System.Security.Claims;
using MinhaApi.Domain.Entities;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MinhaApi.Infrastructure.Auth
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey = "chave secreta e super segura. carinha de riso";

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Level.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: "api",
                audience: "api",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
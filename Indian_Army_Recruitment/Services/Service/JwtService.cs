using Indian_Army_Recruitment.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Indian_Army_Recruitment.Services.Service
{
    public class JwtService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtService(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }

        public string GenerateToken(string username, string role, Guid userId)
        {
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var cred = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim("role",role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("userId", userId.ToString())
            };

            var Token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}

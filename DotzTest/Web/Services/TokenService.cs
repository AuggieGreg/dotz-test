using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using DotzTest.Security;
using DotzTest.Models;

namespace DotzTest.Services
{
    public static class TokenService
    {
        public static string GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecuritySettings.TokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
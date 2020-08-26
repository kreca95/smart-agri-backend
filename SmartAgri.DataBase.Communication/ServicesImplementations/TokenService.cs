using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartAgri.DataBase.Communication.Helpers;
using SmartAgri.DataBase.Communication.Interfaces;
using SmartAgri.DataBase.Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SmartAgri.DataBase.Communication.ServicesImplementations
{
    public class TokenService : ITokenService
    {
        public string GenerateRefreshToken()
        {
            return randomTokenString();
        }

        public TokenResponse GenerateToken(User user, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email)
            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
              configuration["Jwt:Issuer"],
              tokenDescriptor.Subject.Claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var refreshToken = GenerateRefreshToken();
            return new TokenResponse { Token = tokenString, RefreshToken = refreshToken };
        }

        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}

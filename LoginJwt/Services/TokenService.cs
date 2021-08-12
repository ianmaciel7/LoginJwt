using LoginJwt.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using LoginJwt.Exceptions;
using LoginJwt.Models;
using LoginJwt.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace LoginJwt.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secret;

        public TokenService(IConfiguration configuration)
        {
            _secret = configuration.GetSection("Key").Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("name", user.UserName.ToString()),
                    new Claim("role", user.Role.ToString())
                }),
                //Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); ;
        }
    }
}
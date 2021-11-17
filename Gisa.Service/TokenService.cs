using Gisa.Domain;
using Gisa.Domain.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gisa.Service
{
    public class TokenService : ITokenService
    {
        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        private readonly IConfiguration _configuration;

        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("GisaSecret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject    = new System.Security.Claims.ClaimsIdentity(new Claim[] 
                { 
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Perfil)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

using ClubeBeneficiosAPi.Domain.Authentication;
using ClubeBeneficiosAPi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(Client client)
        {
            var permission = client.UserPermissions != null && client.UserPermissions.Any()
                ? string.Join(",", client.UserPermissions.Select(x => x.Role))
                : string.Empty;

            var claims = new List<Claim>

        {   new Claim("Id", client.Id.ToString()),
            new Claim("Email", client.Email ?? string.Empty),
             new Claim("Role", permission) 
        };

            var expires = DateTime.UtcNow.AddDays(4);

            // Criar a chave antes de usá-la
            byte[] key = Encoding.UTF8.GetBytes("ClubeBeneficiosAPI");
            var keyReady = new SymmetricSecurityKey(key);

            var tokenData = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: new SigningCredentials(keyReady, SecurityAlgorithms.HmacSha256)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return new
            {
                acess_token = token,
                expirations = expires
            };
        }
    }
}

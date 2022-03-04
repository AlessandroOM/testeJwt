using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using testeJwt.Models;

namespace testeJwt.Services
{
    public static class TokenServices
    {
       public static string GenerateToken(User user) 
       {
          var tokenHandler = new JwtSecurityTokenHandler() ;
          var key = Encoding.ASCII.GetBytes(Settings.Secret);
          var tokenDescriptor = new SecurityTokenDescriptor{

              Subject = new ClaimsIdentity(new Claim []      // subject é obrigatorio
              {
                  new Claim(ClaimTypes.Name, user.Name.ToString()), // componentes que quero validar no authorize
                  new Claim(ClaimTypes.Role, user.Role.ToString())
              }),
              Issuer = "teste123456",
              Audience = "45kl6",
              Expires = DateTime.UtcNow.AddHours(2),
              SigningCredentials = new SigningCredentials(
                  new SymmetricSecurityKey(key),
                  SecurityAlgorithms.HmacSha256Signature)
              
       };

          var token = tokenHandler.CreateToken(tokenDescriptor);
          return tokenHandler.WriteToken(token);

       }
    }
}
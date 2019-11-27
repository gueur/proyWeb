using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Mudanzas.Models.Auth;
using System.Text;
using System.Security.Claims;

namespace Mudanzas.Helpers
{
    public static class JWTHelper
    {

        private const string JWTKEY = "JPkv6ZbLGEDpTFgu";
        public static string convertoUsuarioToJWT(Usuario user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(JWTKEY);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //TODO: Poner aqui los datos necesarios para que guarde el token
                      new Claim("id", user.getId().ToString()),
                      new Claim("rol", user.getRole()),
                      new Claim("coreroElectronico", user.getCorreoElectronico()),
                      new Claim("nombre", $"{user.getNombre()} {user.getPrimerApellido()} {user.getSegundoApellido()}")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //Creamos el token y lo convertimos a string
            var token= tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }

        
    }
}

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

        public static string convertTokenUrl(string correoElectronico)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(JWTKEY);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("correoElectronico", correoElectronico)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //Creamos el token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;

        }

        public static bool CheckJWT(string jwt)
        {
            try
            {

            byte[] key = Encoding.ASCII.GetBytes(JWTKEY);
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            SecurityToken validatedToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var user = handler.ValidateToken(jwt, validationParameters, out validatedToken);
            if(user.Claims.Count() == 0)
                return false;
            return true;
            }
                catch(Exception e)
            {
                return false;
            }
        }


    }
}

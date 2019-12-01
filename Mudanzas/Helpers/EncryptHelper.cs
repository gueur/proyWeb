using System.Text;
using System;
using System.Security.Cryptography;

namespace Mudanzas.Helpers
{
    public static class EncryptHelper
    {

        //TODO: Hacer que esta key la tome de la configuracion o de las variables de entorno del sistema
        private const string KEY = "ProyectoIntEINGWEB";
        public static string encryptString(string cadenaAEncriptar)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(KEY);
            using(HMACSHA256 sha = new HMACSHA256(keyBytes))
            {
                byte[] cadenaBytes = Encoding.UTF8.GetBytes(cadenaAEncriptar);
                byte[] cadenaEncriptada = sha.ComputeHash(cadenaBytes);
                return Convert.ToBase64String(cadenaEncriptada);
            }
        }

        //TODO: Checar metodo
        public static bool checkStrings(string encryptedString, string nonEncrytedString)
        {
            string encryptNonencryptedString = encryptString(nonEncrytedString);
            return encryptedString.Equals(encryptNonencryptedString);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Templates
{
    public class UsuarioEmailTemplate
    {

        public static string bienvenidoProspecto(string nombre, string codigoVerificacion, string link)
        {
            string template = $"" +
                $"<h2>Bienvenido {nombre}</h2>, <br> para continuar con tu registro introduce este codigo en la aplicación<br>" +
                $"<strong>{codigoVerificacion}</strong><br>" +
                $"<a href=\"http://www.proyweb.com.mx'\">Link a la aplicacion</a>" +
            $"";
            return template;
        }
    }
}

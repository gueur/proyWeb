using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;

namespace Mudanzas.Helpers.Requests
{
    public class LoginResponse
    {

        public string token {get;set;}
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public  string segundoApellido { get; set; }
        public  string telefono { get; set; }
        public  string correoElectronico { get; set; }
        public string rol { get; set; }
        public LoginResponse(Usuario usuario) {
            token = usuario.getToken();
            nombre = usuario.getNombre();
            primerApellido= usuario.getPrimerApellido();
            segundoApellido = usuario.getSegundoApellido();
            telefono = usuario.getTelefono();
            correoElectronico = usuario.getCorreoElectronico();
            rol = usuario.getRole();
        }
    }
}

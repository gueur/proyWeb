using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mudanzas.Helpers.Requests;
using Mudanzas.Models;
using Mudanzas.Models.Auth;
using Newtonsoft.Json.Linq;
using Mudanzas.Helpers;

namespace Mudanzas.Controllers
{
    public class UsuarioController : Controller 
    {
        private UsuarioModel modelo = new UsuarioModel();

        [HttpPost("/chofer/login")]
        public async Task<ActionResult<LoginResponse>> DoChoferLogin([FromBody]LoginRequest login)
        {
            Usuario usuario = modelo.AutenticarChofer(login);
            if (usuario != null)
            {
                return new LoginResponse(usuario);
            }
            return Unauthorized();
        }
        [HttpPost("/chofer/registro")]
        public async Task<ActionResult<Chofer>> RegistrarChofer([FromBody] RegistroChoferRequest registroRequest)
        {
            Chofer chofer = modelo.RegistrarChofer(registroRequest);
            return chofer;
        }

        [HttpPost("/admin/login")]
        public async Task<ActionResult<LoginResponse>> DoAdminLogin([FromBody]LoginRequest login)
        {
            Usuario usuario = modelo.AutenticarAdmin(login);
            if (usuario != null)
            {
                return new LoginResponse(usuario);

            }
            return Unauthorized();
        }

        [HttpPost("/admin/registro")]
        public async Task<ActionResult<Administrador>> RegistrarAdmin([FromBody] RegistroAdminRequest registroRequest)
        {
            Administrador admin = modelo.RegistrarAdmin(registroRequest);
            return admin;
        }

        [HttpPost("/cliente/login")]
        public async Task<ActionResult<LoginResponse>> DoClienteLogin([FromBody]LoginRequest login)
        {
            Usuario usuario = modelo.AutenticarCliente(login);
            if (usuario != null)
            {
                return new LoginResponse(usuario);
            }
            return Unauthorized();
        }

        [HttpPost("/prospecto/registro")]
        public async Task<ActionResult<Usuario>> ProspectoRegistro([FromBody]RegistroRequest registro)
        {
           Cliente cliente =  modelo.RegistrarNuevoCliente(registro);

            return cliente;
        }
        //Metodo para verificar que no es un robot y que proceda
        [HttpPost("/prospecto/verificar")]
        public async Task<ActionResult<Usuario>> VerificarRegistro([FromBody]VerificacionRequest verificacion)
        {
            Cliente cliente = modelo.VerificarProspecto(verificacion.codigoVerificacion);
            return cliente;
        }


        //[Authorize(Roles = Rol.Admin)]
        [HttpPost("/cliente/registro")]
        public async Task<ActionResult<Usuario>> RegistrarCliente([FromBody] HacerClienteRequest clienteRequest)
        {

            Cliente cliente = null;
            cliente = modelo.RegistrarCliente(clienteRequest.prospectoId);
            if (cliente != null)
            {
                //Enviar correo

                return cliente;
            }
            return BadRequest();
        }

        [HttpPost("/usuario/cambiarpassword")]
        public async Task<ActionResult<Usuario>> CambiarPassword([FromBody] CambiarPasswordRequest cambiarPasswordRequest)
        {
            Usuario user = modelo.CambiarPassword(cambiarPasswordRequest.password, cambiarPasswordRequest.token);
            if (user != null)
                return user;
            return Unauthorized();
        }

        [HttpPost("/usuario/olvidopassword")]
        public async Task<ActionResult<Usuario>> OlvidoPassword([FromBody] OlvidoPasswordRequest olvidoPasswordRequest)
        {
            modelo.OlvidoPassword(olvidoPasswordRequest.correoElectronico);
            return new Chofer();
        }

        [HttpPost("/send")]
        public async Task<ActionResult<string>> EnviarCorreo()
        {
  //          Templates.UsuarioEmailTemplate.bienvenidoProspecto(nombre, numeroVerificacion, "http://www.proyweb.com.mx");
//            EmailHelper.sendEmail("manuelvillegasley@gmail.com", "Manuel Villegas el guapo",email);
            return "";
        }

    }



   
}

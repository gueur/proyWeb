using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mudanzas.Helpers.Requests;
using Mudanzas.Models;
using Mudanzas.Models.Auth;

namespace Mudanzas.Controllers
{
    public class UsuarioController : Controller 
    {
        private UsuarioModel modelo = new UsuarioModel();

        [HttpPost("/chofer/login")]
        public async Task<ActionResult<Usuario>> DoChoferLogin([FromBody]LoginRequest login)
        {
            Usuario usuario = modelo.AutenticarChofer(login);
            if (usuario != null)
            {
                return usuario;
            }
            return Unauthorized();
        }
        [HttpPost("/admin/login")]
        public async Task<ActionResult<Usuario>> DoAdminLogin([FromBody]LoginRequest login)
        {
            Usuario usuario = modelo.AutenticarAdmin(login);
            if (usuario != null)
            {
                return usuario;
            }
            return Unauthorized();
        }
        [HttpPost("/cliente/login")]
        public async Task<ActionResult<Usuario>> DocClienteLogin([FromBody]LoginRequest login)
        {
            Usuario usuario = modelo.AutenticarCliente(login);
            if (usuario != null)
            {
                return usuario;
            }
            return Unauthorized();
        }
    }
}

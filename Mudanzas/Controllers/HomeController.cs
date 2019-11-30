using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mudanzas.Models.Auth;
using Mudanzas.Models;
using Mudanzas.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Mudanzas.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/")]
        public async Task<ActionResult<string>> Index()
        {
            return "Esto es una prueba de SSL Aqui bien chida, es solo la API";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost("/check")]
        public async Task<ActionResult<string>> Check([FromBody]Autenticacion auth)
        {
            string passEncrypted = EncryptHelper.encryptString(auth.password);

            return passEncrypted;
        }
        // Metodo para poder entrar como quieran
        [AllowAnonymous]
        [HttpPost("/jwt")]
        public async Task<ActionResult<string>> JWT()
        {
            Cliente user = new Cliente("12", "Manuel", "Villegas", "Leyva", "6674714557", "humbapumbamv@gmail.com","12345678", "Esta casa perrona", "Sinaloa");// { id= 12 , correoElectronico="HumbaPumbaMV@gmail.com", direccion="Calle de la tundra # 2416 col prados del sol", nombre="Manuel", primerApellido="Villegas", segundoApellido="Leyva", telefono="6674714557"};
            string jwt = JWTHelper.convertoUsuarioToJWT(user);

            return jwt;
        }
        //Metodo para cualquiera, pero con un token valido
        [Authorize]
        [HttpGet("/onlyauth")]
        public async Task<ActionResult<string>> Autenticado()
        {

            return "Si está autenticado"; 
        }

        //Con esto es solo para X rol (Se pueden agregar más)
        [Authorize(Roles = Rol.Admin)]
        [HttpGet("/onlyauthadmin")]
        public async Task<ActionResult<string>> AutenticadoAdmin()
        {

            return "Si está autenticado";
        }


    }
}

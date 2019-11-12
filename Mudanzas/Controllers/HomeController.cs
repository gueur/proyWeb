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

        public IActionResult Index()
        {
            return View();
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
        [HttpPost("/jwt")]
        public async Task<ActionResult<string>> JWT()
        {
            Usuario user = new Usuario { id= 12 , correoElectronico="HumbaPumbaMV@gmail.com", direccion="Calle de la tundra # 2416 col prados del sol", nombre="Manuel", primerApellido="Villegas", segundoApellido="Leyva", telefono="6674714557"};
            string jwt = JWTHelper.convertoUsuarioToJWT(user);

            return jwt;
        }

        [Authorize]
        [HttpGet("/onlyauth")]
        public async Task<ActionResult<string>> Autenticado()
        {

            return "Si está autenticado"; 
        }

        [Authorize(Roles = Rol.Admin)]
        [HttpGet("/onlyauthadmin")]
        public async Task<ActionResult<string>> AutenticadoAdmin()
        {

            return "Si está autenticado";
        }


    }
}

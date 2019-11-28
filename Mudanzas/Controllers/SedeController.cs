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

namespace Mudanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        
         ModeloSede modelo;
         public SedeController()
        {
            modelo = new ModeloSede();
        }

        // GET: api/Sede
        [HttpGet]
        public List<Sede> obtenerSede()
        {
            return modelo.obtenerSedes();
        }

        // GET: api/Sede/NAV
        [HttpGet("{alias}")]
        public Sede obtenerSede(string alias)
        {
            return modelo.obtenerSede(alias);
        }

    }
}
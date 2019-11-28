using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mudanzas.Models;

namespace Mudanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamionController : ControllerBase
    {
        ModeloCamion modelo;
        public CamionController()
        {
            modelo = new ModeloCamion();
        }

        // GET: api/Camion
        [HttpGet]
        public List<Camion> obtenerCamiones()
        {
            return modelo.obtenerCamiones();
        }

        // GET: api/Sede/NAV
        [HttpGet("{id}")]
        public Camion obtenerSede(int id)
        {
            return modelo.obtenerCamion(id);
        }

      
    }
}
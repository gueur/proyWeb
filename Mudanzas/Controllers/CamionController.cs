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

        // GET: api/Camion/1
        [HttpGet("{id}")]
        public Camion obtenerCamion(int id)
        {
            return modelo.obtenerCamion(id);
        }

        // POST: api/Camion
        [HttpPost]
        public async Task<ActionResult<Camion>> CamionRegistro([FromBody]CamionRequest registro)
        {
            Camion camion = modelo.RegistrarNuevoCamion(registro.kilometraje, registro.kilometrajeUltimoServicio, registro.capacidadPeso, registro.tipoCamion, registro.tipoCombustible, registro.volumen, registro. placas);

            return camion;
        }


    }
}
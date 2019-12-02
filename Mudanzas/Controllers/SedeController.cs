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
using Mudanzas.Helpers.Requests;
using System;  
using System.IO;  
using System.Net;
using Newtonsoft.Json;

using System.Net.Http;

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
        // GET: api/Sede/NAV
        [HttpGet("prueba/cacatua")]
        public async Task<ActionResult<Google>> cacas()
        {

            Google distancia = new Google();

            string texto = " ";

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://maps.googleapis.com/maps/api/distancematrix/json?origins=24.762946,-107.71&destinations=24.789236,-107.40&mode=transitg&key=AIzaSyCdck7BKZxfVoN_6eY2wJsZcec4ZhleSWM");
                string tt = await result.Content.ReadAsStringAsync();
                tt = tt.Replace("\n", "");
                tt = tt.Replace("\"", "'");
                var d = JsonConvert.DeserializeObject<JObject>(tt);
                JsonSerializer serializer = new JsonSerializer();
                distancia = (Google)serializer.Deserialize(new JTokenReader(d), typeof(Google));

            }
            return distancia;
        }
        
        // POST: api/Sede
        [HttpPost]
        public async Task<ActionResult<SedeRequest>> SedeRegistro([FromBody]SedeRequest sedeRequest)
        {
            Sede sede = await  modelo.RegistraSede(sedeRequest.id, sedeRequest.alias, sedeRequest.ciudad, sedeRequest.estado, sedeRequest.latitud, sedeRequest.longitud, sedeRequest.tipoSede, sedeRequest.pertenece);
            if (sede != null)
            {
                return new SedeRequest(sede);
            }
            return BadRequest();
        }

    }
}
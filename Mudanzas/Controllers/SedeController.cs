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
        public string cacas()
        {
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
              "https://maps.googleapis.com/maps/api/distancematrix/json?origins=24.762946,-107.71&destinations=24.789236,-107.40&mode=transitg&key=AIzaSyCdck7BKZxfVoN_6eY2wJsZcec4ZhleSWM");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            string texto = " ";
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }
            
            // Close the response.  
            response.Close();
          
            return texto;
        }
        
        // POST: api/Sede
        [HttpPost]
        public async Task<ActionResult<SedeRequest>> SedeRegistro([FromBody]SedeRequest sedee)
        {
            Sede sede = modelo.RegistraSede(sedee.id, sedee.alias, sedee.ciudad, sedee.estado, sedee.latitud, sedee.longitud, sedee.tipoSede, sedee.pertenece);
            if (sede != null)
            {
                return new SedeRequest(sede);
            }
            return BadRequest();
        }

    }
}
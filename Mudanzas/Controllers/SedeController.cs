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

        // PUT: api/Sede/NAV
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{alias}")]
        public void putSedes()
        {
            modelo.putSede();
           
        }








    }
}
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
    public class ReservacionController : ControllerBase
    {
        ModeloReservacion modelo;
        public ReservacionController()
        {
            modelo = new ModeloReservacion();
        }
        // POST: api/Reservacion
         [HttpPost]
         public void postExceso([FromBody]ExcesoRequest folio)
         {
            modelo.postExceso(folio);
         }
        [HttpGet]
        public string postExceso()
        {
            return "holi";
        }



    }
}
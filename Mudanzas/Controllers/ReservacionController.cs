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
         [HttpPost("exceso")]
         public ExcesoRequest postExceso([FromBody]ExcesoRequest excesoRequest)
         {
            modelo.postExceso(excesoRequest.folio);
            return excesoRequest;
         }

         [HttpGet]
        public List<Reservacion> obtenerReservaciones()
        {
            return modelo.obtenerReservaciones();
        }

    }
}
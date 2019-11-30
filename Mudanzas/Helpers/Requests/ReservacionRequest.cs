using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Requests
{
    public class ReservacionRequest
    {
        public string sedeOrigen { get; set; }
        public string sedeDestino { get; set; }
        public string fechaReservacion { get; set; }
        public string tipoCamion { get; set; }
        public string idCliente { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Requests
{
    public class CamionRequest
    {
        public decimal kilometraje { get; set; }
        public decimal kilometrajeUltimoServicio { get; set; }
        public decimal capacidadPeso { get; set; }
        public string tipoCamion { get; set; }
        public string tipoCombustible { get; set; }
        public decimal volumen { get; set; }
        public string placas { get; set; }

    }
}

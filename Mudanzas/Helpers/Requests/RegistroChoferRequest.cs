using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Requests
{
    public class RegistroChoferRequest
    {
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string password { get; set; }
        public string correoElectronico { get; set; }
        public string telefono { get; set; }

    }
}

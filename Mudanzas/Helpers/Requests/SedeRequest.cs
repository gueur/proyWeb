using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Requests
{
    public class SedeRequest
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string tipoSede { get; set; }
        public string pertenece { get; set; }
    }
}





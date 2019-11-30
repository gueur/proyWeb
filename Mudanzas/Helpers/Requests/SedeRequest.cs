using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;

namespace Mudanzas.Helpers.Requests
{
    public class SedeRequest
    {

        public SedeRequest()
        {

        }

        public SedeRequest(Sede sede)
        {
            this.id = sede.id;
            this.alias = sede.alias;
            this.ciudad = sede.ciudad;
            this.estado = sede.estado;
            this.latitud = sede.latitud;
            this.longitud = sede.longitud;
            this.tipoSede = sede.tipoSede;
            this.pertenece = sede.pertenece;
        }

        public int id { get; set; }
        public string alias { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string tipoSede { get; set; }
        public int pertenece { get; set; }
    }
}





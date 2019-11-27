using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models
{
    public class Sede
    {
        public Sede(string alias, string ciudad, string estado, double latitud, double longitud, string tipoSede, int idAdministrador, string pertenece)
        {
            this.alias = alias;
            this.ciudad = ciudad;
            this.estado = estado;
            this.latitud = latitud;
            this.longitud = longitud;
            this.tipoSede = tipoSede;
            this.idAdministrador = idAdministrador;
            this.pertenece = pertenece;
        }
        public string alias { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string  tipoSede { get; set; }
        public int idAdministrador { get; set; }
        public string pertenece { get; set; }
    }
}

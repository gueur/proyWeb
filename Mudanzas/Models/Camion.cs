using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models
{
    public class Camion
    {
        public Camion(string id, decimal kilometraje, decimal kilometrajeUltimoServicio, decimal capacidadPeso, string tipoCamion,string tipoCombustible, decimal volumen, string placas)
        {
            this.id = id;
            this.kilometraje = kilometraje;
            this.kilometrajeUltimoServicio = kilometrajeUltimoServicio;
            this.capacidadPeso = capacidadPeso;
            this.tipoCamion = tipoCamion;
            this.tipoCombustible = tipoCombustible;
            this.volumen = volumen;
            this.placas = placas;
        }
        public string id { get; set; }
        public decimal kilometraje { get; set; }
        public decimal kilometrajeUltimoServicio { get; set; }
        public decimal capacidadPeso { get; set; }
        public string tipoCamion { get; set; }
        public string tipoCombustible { get; set; }
        public decimal volumen { get; set; }
        public string placas { get; set; }

    }
}

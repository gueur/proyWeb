using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;

namespace Mudanzas.Helpers.Requests
{
    public class ProspectoResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string password { get; set; }
        public string telefono { get; set; }
        public string correoElectronico { get; set; }
        public string codigoVerificacion { get; set; }
        public string direccion { get; set; }

        public ProspectoResponse(Prospecto p)
        {
            this.id = p.getId();
            this.nombre = p.getNombre();
            this.primerApellido = p.getPrimerApellido();
            this.segundoApellido = p.getSegundoApellido();
            this.telefono= p.getTelefono();
            this.correoElectronico= p.getCorreoElectronico();
            this.direccion= p.getDireccion();
            this.codigoVerificacion = p.getCodigoVerificacion();

        }

        public static List<ProspectoResponse> ConvertProspectosToResponse(List<Prospecto> prospectos)
        {
            List<ProspectoResponse> pr = new List<ProspectoResponse>(); 
            foreach(Prospecto p in prospectos)
            {
                pr.Add(new ProspectoResponse(p));
            }
            return pr;
        }

    }
}

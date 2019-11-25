using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Chofer : Usuario
    {
        public override string getRole()
        {
            return Rol.Chofer;
        }

        public Chofer(int id, string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido= segundoApellido;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
        }

       
    }
}

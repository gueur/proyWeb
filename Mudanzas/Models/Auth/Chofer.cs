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
        public Chofer()
        {

        }
        public Chofer(string id, string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico)
        {
            this.setId(id);
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
        }

       
    }
}

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

        public Chofer( string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico)
        {
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
        }


        public Chofer(string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string password)
        {
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
            this.setPassword(password);
        }
        public Chofer(string id, string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string password)
        {
            this.setId(id);
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
            this.setPassword(password);
        }


    }
}

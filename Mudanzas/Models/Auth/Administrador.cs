using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Administrador : Usuario
    {
        private string sede { get; set; }
        public override string getRole()
        {
            return Rol.Admin;
        }

        public Administrador( string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string sede)
        {
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
            this.setSede(sede);
        }

        public Administrador(string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string sede,string password)
        {
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
            this.setSede(sede);
            this.setPassword(password);
        }
        public Administrador(string id, string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string sede, string password)
        {
            this.setId(id);
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
            this.setSede(sede);
            this.setPassword(password);
        }

        public string getSede()
        {
            return this.sede; 
        }
        public void setSede(string sede)
        {
            this.sede = sede;
        }

    }
}

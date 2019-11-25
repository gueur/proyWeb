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
        public Administrador(int id, string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string sede)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.sede = sede;
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

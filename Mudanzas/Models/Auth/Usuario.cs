using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public abstract class Usuario
    {

        private string id { get; set; }
        private string nombre { get; set; }
        private string primerApellido { get; set; }
        private string segundoApellido { get; set; }
        private string password { get; set; }
        private string telefono { get; set; }
        private string correoElectronico { get; set; }
        private string token { get; set; }

        public abstract string getRole();
        public string getToken()
        {
            return this.token ;
        }
        public void setToken(string token)
        {
            this.token = token;
        }

        public string getId()
        {
            return this.id;
        }
        public void setId(string id)
        {
            this.id= id;
        }

        public string getNombre()
        {
            return this.nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getPrimerApellido()
        {
            return this.primerApellido;
        }
        public void setPrimerApellido(string primerApellido)
        {
            this.primerApellido = primerApellido;
        }

        public string getSegundoApellido()
        {
            return this.segundoApellido;
        }
        public void setSegundoApellido(string segundoApellido)
        {
            this.segundoApellido = segundoApellido;
        }

        public string getPassword()
        {
            return this.password;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getTelefono()
        {
            return this.telefono;
        }
        public void setTelefono(string telefono)
        {
            this.telefono = telefono;
        }
        public string getCorreoElectronico()
        {
            return this.correoElectronico;
        }
        public void setCorreoElectronico(string correoElectronico)
        {
            this.correoElectronico = correoElectronico;
        }

    }
}

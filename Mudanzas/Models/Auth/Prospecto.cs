using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Prospecto { 

        private int id { get; set; }
        private string nombre { get; set; }
        private string primerApellido { get; set; }
        private string segundoApellido { get; set; }
        private string password { get; set; }
        private string telefono { get; set; }
        private string correoElectronico { get; set; }
        private string codigoVerificacion { get; set; }
        private string direccion;
        public Prospecto(int id, string nombre, string primerApellido, string segundoApellido, string telefono, string direccion, string correoElectronico)
        {
            this.setId(id);
            this.setNombre(nombre);
            this.setPrimerApellido(primerApellido);
            this.setSegundoApellido(segundoApellido);
            this.setTelefono(telefono);
            this.setCorreoElectronico(correoElectronico);
            this.setDireccion(direccion);
        }

        public string getDireccion()
        {
            return this.direccion;
        }
        public void setDireccion(string direccion)
        {
            this.direccion = direccion;
        }
        public string getCodigoVerificacion()
        {
            return this.codigoVerificacion;
        }
        public void setCodigoVerificacion(string codigoVerificacion)
        {
            this.codigoVerificacion = codigoVerificacion;
        }
        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
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

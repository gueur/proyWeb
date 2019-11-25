using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;
using Mudanzas.Services.IServices;
using System.Data.SqlClient;


namespace Mudanzas.Data.Usuarios
{
    public class ChoferDB
    {
        private string tipoUsuario = "CHOFER";
        private string aliasTipoUsuario = "ch";
        private string extraAtributos= ", c.direccion";

        public Usuario actualizarUsuario(Usuario user)
        {
            throw new NotImplementedException();
        }

        public Usuario Autorizar(string correoElectronico, string password)
        {
            //TODO: Aqui simulamos que va a la bd para buscar el usuario y contraseña
            Usuario user = null;
            using (SqlCommand com = new SqlCommand($"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token , c.direccion FROM USUARIO u inner join {this.tipoUsuario} {this.aliasTipoUsuario} on u.id = {aliasTipoUsuario}.id where u.correoElectronico={correoElectronico} and u.contrasena={password}"))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                string primerApellido = reader.GetString(2);
                string segundoApellido = reader.GetString(3);
                string telefono = reader.GetString(5);
                string token = reader.GetString(7);
                user = new Chofer(id, nombre, primerApellido, segundoApellido, telefono, correoElectronico);
                }
            }
            return user;
        }

        public Usuario BuscarUsuarioId(string id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarUsuarioNombre(string nombre, string apellido)
        {
            throw new NotImplementedException();
        }
    }
}

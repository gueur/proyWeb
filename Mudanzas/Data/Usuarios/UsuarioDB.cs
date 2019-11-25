using Mudanzas.Models.Auth;
using Mudanzas.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Data
{
    public class UsuarioDB : IUsuarioDB
    {

        public readonly SqlConnection db = ConexionDB.GetConnection();
        public Usuario actualizarUsuario(Usuario user)
        {

            //TODO: Hacer actualizar usuario
            throw new NotImplementedException();
        }

        
        public Usuario BuscarUsuarioId(string id)
        {
            //TODO: Hacer buscar usuario por id
            throw new NotImplementedException();
        }

        public Usuario BuscarUsuarioNombre(string nombre, string apellido)
        {
            //TODO: Hacer el buscar usuario nombre
            throw new NotImplementedException();
        }

        public Chofer AutorizarChofer(string correoElectronico, string password)
        {
            Chofer user = null;
            using (SqlCommand com = new SqlCommand($"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token  FROM USUARIO u inner join chofer c on u.id = c.id where u.correoElectronico='{correoElectronico}' and u.contrasena='{password}'",db))
            {
                SqlDataReader reader=null;
                try
                {
                    reader =  com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string primerApellido = reader.GetString(2);
                        string segundoApellido = reader.GetString(3);
                        string telefono = reader.GetString(5);
                        //string token = reader.GetString(7);
                        user = new Chofer(id, nombre, primerApellido, segundoApellido, telefono, correoElectronico);
                    }
                }
                finally
                {
                    reader.Close();
                }
                
            }
            return user;
        }

        public Cliente AutorizarCliente(string correoElectronico, string password)
        {
            Cliente user = null;
            using (SqlCommand com = new SqlCommand($"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token, c.direccion  FROM USUARIO u inner join cliente c on u.id = c.id where u.correoElectronico='{correoElectronico}' and u.contrasena='{password}'", db))
            {
                SqlDataReader reader = null;
                try
                {
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string primerApellido = reader.GetString(2);
                        string segundoApellido = reader.GetString(3);
                        string telefono = reader.GetString(5);
                        string direccion = reader.GetString(8);
                        //string token = reader.GetString(7);
                        user = new Cliente(id, nombre, primerApellido, segundoApellido, telefono, correoElectronico,direccion);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }
            return user;
        }

        public Administrador AutorizarAdministrador(string correoElectronico, string password)
        {
            Administrador user = null;
            string query = $"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token , c.direccion FROM USUARIO u inner join chofer c on u.id = c.id where u.correoElectronico={correoElectronico} and u.contrasena={password}";
            using (SqlCommand com = new SqlCommand($"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token, a.tipoAdministrador  FROM USUARIO u inner join administrador a on u.id = a.id where u.correoElectronico='{correoElectronico}' and u.contrasena='{password}'", db))
            {
                SqlDataReader reader = null;
                try
                {
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string primerApellido = reader.GetString(2);
                        string segundoApellido = reader.GetString(3);
                        string telefono = reader.GetString(5);
                        string sede = reader.GetString(8);
                        //string token = reader.GetString(7);
                        user = new Administrador(id, nombre, primerApellido, segundoApellido, telefono, correoElectronico, sede);
                    }
                }
                finally
                {
                    reader.Close();
                }

            }
            return user;
        }
    }
}

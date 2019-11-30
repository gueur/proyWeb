using Mudanzas.Models.Auth;
using Mudanzas.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data;
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
            using (SqlCommand com = new SqlCommand($"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token  FROM USUARIO u inner join chofer c on u.id = c.idUsuario where u.correoElectronico='{correoElectronico}' and u.contrasena='{password}'",db))
            {
                SqlDataReader reader=null;
                try
                {
                    reader =  com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string id = reader.GetString(0);
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
                    if(reader!=null)
                        reader.Close();
                }
                
            }
            return user;
        }

        public Cliente AutorizarCliente(string correoElectronico, string password)
        {
            Cliente user = null;
            string query = $"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token, c.direccion FROM USUARIO u inner join cliente c on u.id = c.idUsuario where u.correoElectronico='{correoElectronico}' and u.contrasena='{password}'";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                SqlDataReader reader = null;
                try
                {
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string id = reader.GetString(0);
                        string nombre = reader.GetString(1);
                        string primerApellido = reader.GetString(2);
                        string segundoApellido = reader.GetString(3);
                        string telefono = reader.GetString(5);
                        string direccion = reader.GetString(8);
                        //TODO: Agregar la ciudad
                        //string ciudad = reader.GetString(9);
                        //string token = reader.GetString(7);
                        user = new Cliente(id, nombre, primerApellido, segundoApellido, telefono, correoElectronico, null, direccion,"");
                    }
                }
                finally
                {   
                    if(reader!=null)
                        reader.Close();
                }

            }
            return user;
        }

        public Administrador AutorizarAdministrador(string correoElectronico, string password)
        {
            Administrador user = null;
            string query = $"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token , c.direccion FROM USUARIO u inner join chofer c on u.id = c.id where u.correoElectronico={correoElectronico} and u.contrasena={password}";
            using (SqlCommand com = new SqlCommand($"SELECT TOP 1 u.id, u.nombre ,u.primerApellido, u.segundoApellido, u.contrasena, u.telefono, u.correoelectronico, u.token, a.tipoAdministrador  FROM USUARIO u inner join administrador a on u.id = a.idUsuario where u.correoElectronico='{correoElectronico}' and u.contrasena='{password}'", db))
            {
                SqlDataReader reader = null;
                try
                {
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string id = reader.GetString(0);
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
                    if(reader!=null)
                        reader.Close();
                }

            }
            return user;
        }

        public Cliente RegistrarProspecto(Cliente cliente)
        {
            string query = $"INSERT INTO PROSPECTO (nombre, primerApellido, segundoApellido, telefono, correoElectronico, direccion, codigoVerificacion) VALUES('{cliente.getNombre()}', '{cliente.getPrimerApellido()}', '{cliente.getSegundoApellido()}', '{cliente.getTelefono()}', '{cliente.getCorreoElectronico()}', '{cliente.getDireccion()}', '{cliente.getToken()}')";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                //TODO: Agregar verificar de usuario (prospecto)
                com.CommandType = System.Data.CommandType.Text;
                com.ExecuteNonQuery();
                db.Close();
            }

            return cliente;
        }

        public Cliente VerificacionProspecto(Cliente cliente) 
        {
            string query = $"UPDATE PROSPECTO SET codigoVerificacion = null where codigoVerificacion={cliente.getToken()}";

            using(SqlCommand com = new SqlCommand(query, db))
            {
                //TODO: Verificar si existe (regresar algo para saber si hizo el cambio o no)
                var f=com.ExecuteNonQuery();
                db.Close();
            }
            //TODO: Hacer que regrese el prospecto para llenarlo completamente
            return cliente;
        }

        public Usuario RegistrarChofer(Chofer usuario)
        {
            string query = "registraUsuarios";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@nombre", usuario.getNombre()));
                com.Parameters.Add(new SqlParameter("@primerApellido", usuario.getPrimerApellido()));
                com.Parameters.Add(new SqlParameter("@segundoApellido", usuario.getSegundoApellido()));
                com.Parameters.Add(new SqlParameter("@contraseña", usuario.getPassword()));
                com.Parameters.Add(new SqlParameter("@telefono", usuario.getTelefono()));
                com.Parameters.Add(new SqlParameter("@correoElectronico", usuario.getCorreoElectronico()));
                com.Parameters.Add(new SqlParameter("@tipo", "CH"));
                com.ExecuteNonQuery();
                db.Close();
            }
            return usuario;
        }


        public Usuario RegistrarAdmin(Administrador usuario)
        {
            string query = "registraUsuarios";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@nombre", usuario.getNombre()));
                com.Parameters.Add(new SqlParameter("@primerApellido", usuario.getPrimerApellido()));
                com.Parameters.Add(new SqlParameter("@segundoApellido", usuario.getSegundoApellido()));
                com.Parameters.Add(new SqlParameter("@contraseña", usuario.getPassword()));
                com.Parameters.Add(new SqlParameter("@telefono",  usuario.getTelefono()));
                com.Parameters.Add(new SqlParameter("@correoElectronico", usuario.getCorreoElectronico()));
                com.Parameters.Add(new SqlParameter("@tipo", "AD"));
                com.ExecuteNonQuery();
                db.Close();
            }
            return usuario;
        }


        public Cliente MoverProspectoACliente(int prospectoId)
        {
            Cliente c = new Cliente();
            using (SqlCommand com = new SqlCommand("altaClientes", db))
            {
                //TODO: Verificar si existe (regresar algo para saber si hizo el cambio o no)
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@idProspecto", prospectoId));
                var f = com.ExecuteNonQuery();
                //TODO: Hacer la validacion si se hizo correctamente
                db.Close();
            }

            return c;
        }

        public Usuario CambiarPassword(string password, string token)
        {
            //TODO: Modificar el regreso
            string query = "SP_ChangePass";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@password", password));
                com.Parameters.Add(new SqlParameter("@token", token));
                com.ExecuteNonQuery();
                db.Close();
            }
            return null;
        }

        public Usuario OlvidoPassword(string correoElectronico, string token)
        {

            string query = "SP_OlvidoPass";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@correoElectronico", correoElectronico));
                com.Parameters.Add(new SqlParameter("@token", token));
                com.ExecuteNonQuery();
                db.Close();
            }
            //TODO: Modificar el regreso
            return null;
        }

    }
}

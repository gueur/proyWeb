using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;
using Mudanzas.Models.Auth;
using Mudanzas.Services.IServices;
using System.Data.SqlClient;

namespace Mudanzas.Data
{
    public class dbSede
    {
        public readonly SqlConnection db = ConexionDB.GetConnection();


        // GET Sedes
        public List<Sede> obtenerSedes()
        {
            //TODO: Obtener todas las Sedes
            //Sede sede = List<Sede>;
            List<Sede> sede = new List<Sede>();
            using (SqlCommand com = new SqlCommand($"SELECT * FROM Sede",db))
            { 
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string alias = reader.GetString(0);
                        string ciudad = reader.GetString(1);
                        string estado = reader.GetString(2);
                        double latitud = reader.GetDouble(3);
                        double longitud = reader.GetDouble(4);
                        string tipoSede = reader.GetString(5);
                        int idAministrador = reader.GetInt32(6);
                        string pertence = reader.GetString(7);
                        sede.Add(new Sede(alias, ciudad, estado, latitud, longitud, tipoSede, idAministrador, pertence));
                    }
                }   
                reader.Close();
            }
            return sede;
        }

        // GET/ID Sede
        public Sede obtenerSede(string aliass)
        {
            //TODO: Obtener todas las Sedes
            //Sede sede = List<Sede>;
            Sede sede = null;
            using (SqlCommand com = new SqlCommand($"SELECT Top 1 * FROM Sede where alias='{aliass}' ", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string alias = reader.GetString(0);
                        string ciudad = reader.GetString(1);
                        string estado = reader.GetString(2);
                        double latitud = reader.GetDouble(3);
                        double longitud = reader.GetDouble(4);
                        string tipoSede = reader.GetString(5);
                        int idAministrador = reader.GetInt32(6);
                        string pertence = reader.GetString(7);
                        sede = new Sede(alias, ciudad, estado, latitud, longitud, tipoSede, idAministrador, pertence);
                    }
                }
                reader.Close();
            }
            return sede;
        }
        // GET/ID Sede
        public Sede putSede()
        {
            //TODO: Obtener todas las Sedes
            //Sede sede = List<Sede>;
            Sede sede = null;
            using (SqlCommand com = new SqlCommand($"UPDATE SEDE SET alias = 'CLN', ciudad = 'cul', estado = 'sin', latitud = 24.789105, longitud = -107.398337, tipoSede = 1, idAdministrador = 1, pertenece = 'CLN' WHERE ALIAS = 'CUL2' ; ", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string alias = reader.GetString(0);
                        string ciudad = reader.GetString(1);
                        string estado = reader.GetString(2);
                        double latitud = reader.GetDouble(3);
                        double longitud = reader.GetDouble(4);
                        string tipoSede = reader.GetString(5);
                        int idAministrador = reader.GetInt32(6);
                        string pertence = reader.GetString(7);
                        sede = new Sede(alias, ciudad, estado, latitud, longitud, tipoSede, idAministrador, pertence);
                    }
                }
                reader.Close();
            }
            return sede;
        }

        // POST SEDE

        public Sede guardarSede(Sede sede)
        {
           // string query = $"INSERT INTO SEDE (alias, ciudad, estado, latitud, longitud, tipoSede, idAdministrador, pertenece) VALUES ( 'MAZ','Mazatlan','Sinaloa', 23.237738, -106.438588, 2, 1, 'CLN' )";
            string query = $"INSERT INTO SEDE (alias, ciudad, estado, latitud, longitud, tipoSede, idAdministrador, pertenece) VALUES ( '{sede.alias}','{sede.ciudad}','{sede.estado}', {sede.latitud}, {sede.longitud}, {sede.tipoSede}, {sede.idAdministrador}, '{sede.pertenece}' )";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                //TODO: Agregar en la tabla cliente la ciudad
                //TODO: Agregar verificar de usuario (prospecto)
                com.CommandType = System.Data.CommandType.Text;
                com.ExecuteNonQuery();
                db.Close();
            }

            return sede;
        }


        public Sede RegistrarCliente(Sede sede)
        {
            string query = $"INSERT INTO SEDE (alias, ciudad, estado, latitud, longitud, tipoSede, idAdministrador, pertenece) VALUES ( '{sede.alias}','{sede.ciudad}','{sede.estado}', {sede.latitud}, {sede.longitud}, {sede.tipoSede}, {sede.idAdministrador}, '{sede.pertenece}' )";

            using (SqlCommand com = new SqlCommand(query, db))
            {
                //TODO: Agregar en la tabla cliente la ciudad
                //TODO: Agregar verificar de usuario (prospecto)
                com.CommandType = System.Data.CommandType.Text;
                com.ExecuteNonQuery();
                db.Close();
            }

            return sede;
        }







    }
}

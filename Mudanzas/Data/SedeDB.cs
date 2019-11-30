using Mudanzas.Models.Auth;
using Mudanzas.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;
using System.Data;

namespace Mudanzas.Data
{
    public class SedeDB: ISedeDB
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
                        int id = reader.GetInt32(0);
                        string alias = reader.GetString(1);
                        string ciudad = reader.GetString(2);
                        string estado = reader.GetString(3);
                        double latitud = reader.GetDouble(4);
                        double longitud = reader.GetDouble(5);
                        string tipoSede = reader.GetString(6);
                        int pertence = reader.GetInt32(7);
                        sede.Add(new Sede(id, alias, ciudad, estado, latitud, longitud, tipoSede, pertence));
                    }
                }   
                reader.Close();
            }
            return sede;
        }

        // GET/ID Sede
        public Sede obtenerSede(string alias)
        {
            //TODO: Obtener todas las Sedes
            //Sede sede = List<Sede>;
            Sede sede = null;
            using (SqlCommand com = new SqlCommand($"SELECT Top 1 * FROM Sede where id=1 ", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string localalias = reader.GetString(1);
                        string ciudad = reader.GetString(2);
                        string estado = reader.GetString(3);
                        double latitud = reader.GetDouble(4);
                        double longitud = reader.GetDouble(5);
                        string tipoSede = reader.GetString(6);
                        int pertence = reader.GetInt32(7);

                        sede = new Sede(id, localalias, ciudad, estado, latitud, longitud, tipoSede, pertence);
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
                        int id = reader.GetInt32(0);
                        string alias = reader.GetString(1);
                        string ciudad = reader.GetString(2);
                        string estado = reader.GetString(3);
                        double latitud = reader.GetDouble(4);
                        double longitud = reader.GetDouble(5);
                        string tipoSede = reader.GetString(6);
                        int pertence = reader.GetInt32(7);
                        sede = new Sede(id, alias, ciudad, estado, latitud, longitud, tipoSede, pertence);
                    }
                }
                reader.Close();
            }
            return sede;
        }

       
          // POST/ID Camion
        public Sede RegistraSede(Sede sede)
        {
           
            using (SqlCommand com = new SqlCommand("SP_ALTASEDES", db))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@alias", sede.alias));
                com.Parameters.Add(new SqlParameter("@ciudad", sede.ciudad));
                com.Parameters.Add(new SqlParameter("@estado", sede.estado));
                com.Parameters.Add(new SqlParameter("@latitud", sede.latitud));
                com.Parameters.Add(new SqlParameter("@longitud", sede.longitud));
                com.Parameters.Add(new SqlParameter("@pertenece", sede.pertenece));
                SqlDataReader reader = com.ExecuteReader();
                if (reader.RecordsAffected== 0)
                {
                    //Se hizo correctamente
                    sede=null;
                }
                //TODO: Manejar el error cuando no se creo la sede
                db.Close();
            }
            return sede;
        }
    }
}

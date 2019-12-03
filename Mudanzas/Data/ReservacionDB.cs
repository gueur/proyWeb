using Mudanzas.Models.Auth;
using Mudanzas.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;

namespace Mudanzas.Data
{
    public class ReservacionDB: IReservacionDB
    {
        public readonly SqlConnection db = ConexionDB.GetConnection();

        public List<Reservacion> GetReservaciones()
        {
            //TODO: Obtener todas las Sedes
            //Sede sede = List<Sede>;
            List<Reservacion> reservaciones = new List<Reservacion>();
            using (SqlCommand com = new SqlCommand($"SELECT * FROM Reservacion", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int folio = reader.GetInt32(0);
                        string sedeOrigen= reader.GetString(1);
                        string sedeDestino = reader.GetString(2);
                        string fechaReservacion= reader.GetString(3);
                        string tipoCamion= reader.GetString(4);
                        string idCliente= reader.GetString(5);
                        reservaciones.Add(new Reservacion(folio,sedeOrigen,sedeDestino,fechaReservacion,tipoCamion,idCliente));
                    }
                }
                reader.Close();
            }
            return reservaciones;
        }

        public List<Reservacion> GetReservacionesPendientes()
        {
            List<Reservacion> reservaciones = new List<Reservacion>();
            using (SqlCommand com = new SqlCommand($"SELECT s.folio, s.sedeOrigen, s.sedeDestino, s.fechaReservacion, s.tipoCamion, s.idCliente FROM Sede s", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int folio = reader.GetInt32(0);
                        string sedeOrigen = reader.GetString(1);
                        string sedeDestino = reader.GetString(2);
                        string fechaReservacion = reader.GetString(3);
                        string tipoCamion = reader.GetString(4);
                        string idCliente = reader.GetString(5);
                        reservaciones.Add(new Reservacion(folio, sedeOrigen, sedeDestino, fechaReservacion, tipoCamion, idCliente));
                    }
                }
                reader.Close();
            }
            return reservaciones;
        }

        // POST/ID Camion
        public void postExceso(int folio)
        {

            //string query = $"SP_ALTACAMIONES {folio}";
            string query = $"EXEC REGISTROEXCESO @Folio = {folio}";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.ExecuteNonQuery();
                db.Close();
            }
        }


    }
}

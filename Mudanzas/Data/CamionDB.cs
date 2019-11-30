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
    public class CamionDB: ICamionDB
    {
        public readonly SqlConnection db = ConexionDB.GetConnection();


        // GET Sedes
        public List<Camion> obtenerCamiones()
        {
            //TODO: Obtener todas las Camiones
            //Sede sede = List<Camion>;
            List<Camion> camiones = new List<Camion>();
            using (SqlCommand com = new SqlCommand($"SELECT * FROM Camion", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        decimal kilometraje = reader.GetDecimal(1);
                        decimal kilometrajeUltimoServicio = reader.GetDecimal(2);
                        decimal capacidadPeso = reader.GetDecimal(3);
                        string tipoCamion = reader.GetString(4);
                        string tipoCombustible = reader.GetString(5);
                        decimal volumen = reader.GetDecimal(6);
                        string placas = reader.GetString(7);
                        camiones.Add(new Camion(id, kilometraje, kilometrajeUltimoServicio, capacidadPeso, tipoCamion, tipoCombustible, volumen, placas));
                    }
                }
                reader.Close();
            }
            return camiones;
        }

        // GET/ID Sede
        public Camion obtenerCamion(int ids)
        {
            //TODO: Obtener todas las Sedes
            //Sede sede = List<Sede>;
            Camion camion = null;
            using (SqlCommand com = new SqlCommand($"SELECT Top 1 * FROM Camion where id={ids} ", db))
            {
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string  id = reader.GetString(0);
                        decimal kilometraje = reader.GetDecimal(1);
                        decimal kilometrajeUltimoServicio = reader.GetDecimal(2);
                        decimal capacidadPeso = reader.GetDecimal(3);
                        string tipoCamion = reader.GetString(4);
                        string tipoCombustible = reader.GetString(5);
                        decimal volumen = reader.GetDecimal(6);
                        string placas = reader.GetString(7);
                        camion = new Camion(id, kilometraje, kilometrajeUltimoServicio, capacidadPeso, tipoCamion, tipoCombustible, volumen, placas);
                    }
                }
                reader.Close();
            }
            return camion;
        }
        // POST/ID Camion
        public Camion RegistrarCamion(Camion camion)
        {
            // string query = $"INSERT INTO CAMION (nombre, primerApellido, segundoApellido, telefono, correoElectronico, direccion, codigoVerificacion) VALUES('{cliente.getNombre()}', '{cliente.getPrimerApellido()}', '{cliente.getSegundoApellido()}', '{cliente.getTelefono()}', '{cliente.getCorreoElectronico()}', '{cliente.getDireccion()}', '{cliente.getToken()}')";
            string query = $"SP_ALTACAMIONES '{camion.tipoCamion}',{camion.kilometraje}, {camion.capacidadPeso}, '{camion.tipoCombustible}',{camion.volumen}, '{camion.placas}'";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.ExecuteNonQuery();
                db.Close();
            }
            return camion;
        }


    }
}

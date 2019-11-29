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

        // POST/ID Camion
        public void postExceso(int folio)
        {

            //string query = $"SP_ALTACAMIONES {folio}";
            string query = $"EXEC SP_REGISTRAEXCESO @Folio = {folio}";
            using (SqlCommand com = new SqlCommand(query, db))
            {
                com.ExecuteNonQuery();
                db.Close();
            }
        }


    }
}

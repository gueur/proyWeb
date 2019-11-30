using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;
using Mudanzas.Services;
using System.Data.SqlClient;
namespace Mudanzas.Data
{
    public class DBHandler 
    {
        private SqlConnection conexionDB = ConexionDB.GetConnection();
        private UsuarioDB usuarioDB;



    }
}

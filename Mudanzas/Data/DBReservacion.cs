﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mudanzas.Data
{
    public class DBReservacion
    {
        private readonly SqlConnection dbCon = ConexionDB.GetConnection();
        
        
    }
}

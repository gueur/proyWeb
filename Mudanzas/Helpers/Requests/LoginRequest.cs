﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Requests
{
    public class LoginRequest
    {
        public string correoElectronico { get; set; }
        public string password { get; set; }
    }
}

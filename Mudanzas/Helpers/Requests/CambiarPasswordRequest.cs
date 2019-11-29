using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Helpers.Requests
{
    public class CambiarPasswordRequest
    {

        public string token { get; set; }
        public string password { get; set; }
    }
}

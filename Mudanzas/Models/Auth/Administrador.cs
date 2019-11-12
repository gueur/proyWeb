using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Administrador : Persona
    {
        public string sede { get; set; }
        public override string getRole()
        {
            return Rol.Admin;
        }
    }
}

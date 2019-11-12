using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Chofer : Persona
    {
        public override string getRole()
        {
            return Rol.Chofer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Cliente: Persona
    {
        public string direccion { get; set; }
        public override string getRole()
        {
            return Rol.Cliente;
        }
    }
}

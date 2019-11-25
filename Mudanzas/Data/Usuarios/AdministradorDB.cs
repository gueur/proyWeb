using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Data.Usuarios
{
    public class AdministradorDB: UsuarioDB
    {
        private string tipoUsuario="ADMINISTRADOR";
        private string extraAtributos= ", a.direccion";



    }
}

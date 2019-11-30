using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;

namespace Mudanzas.Services
{
    interface IDataService
    {
        Usuario BuscarUsuarioPorCredenciales(string correoElectronico, string password);
        Usuario VerificarUsuarioToken(string token);
        Usuario BuscarUsuarioPorEmail(string correoElectronico);
        
    }
}

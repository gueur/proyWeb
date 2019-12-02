using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;
namespace Mudanzas.Services.IServices
{
    interface ISedeDB
    {
        List<Sede> obtenerSedes();
        Sede obtenerSede(string alias);
        Sede putSede();
        Sede RegistraSede(Sede sede);
        bool GuardarDistancias(List<DistanciaSede> distancias);
    }
}

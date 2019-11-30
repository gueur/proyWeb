using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;

namespace Mudanzas.Services.IServices
{
    interface ICamionDB
    {
        List<Camion> obtenerCamiones();
        Camion obtenerCamion(int ids);

    }
}

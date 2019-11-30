using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;

namespace Mudanzas.Services.IServices
{
    interface IReservacionDB
    {
        void postExceso(int folio);
        List<Reservacion> GetReservaciones();
        List<Reservacion> GetReservacionesPendientes();
    }
}

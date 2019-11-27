using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;
using Mudanzas.Helpers.Requests;
using Mudanzas.Services.IServices;
using Mudanzas.Data;
using Mudanzas.Helpers;

namespace Mudanzas.Models
{
    public class ModeloSede
    {
        private dbSede bd;
        public ModeloSede()
        {
            bd = new dbSede();
        }
        // GET ALIAS
        public List<Sede> obtenerSedes()
        {
            return bd.obtenerSedes();
        }
        // GET SEDES/ALIAS
        public Sede obtenerSede(string alias)
        {
           return bd.obtenerSede(alias);
        }
        // PUT POST/SEDE
        public Sede altaSede(Sede sede)
        {
            Sede nuevaSede = new Sede(sede.alias, sede.ciudad, sede.estado, sede.latitud, sede.longitud, sede.tipoSede, sede.idAdministrador, sede.pertenece);
            bd.guardarSede(nuevaSede);
            return nuevaSede;
        }
        public Sede RegistrarNuevoCliente(RegistroRequest sede)
        {
            //TODO: modificarle parametros
            Sede nuevaSede = new Sede(sede.alias, sede.ciudad, sede.estado, sede.latitud, sede.longitud, sede.tipoSede, sede.idAdministrador, sede.pertenece);

            bd.RegistrarCliente(nuevaSede);
            return nuevaSede;
        }







    }
}

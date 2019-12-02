using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;
using Mudanzas.Models;
using Mudanzas.Helpers.Requests;
using Mudanzas.Services.IServices;
using Mudanzas.Data;
using Mudanzas.Helpers;
using System;  
using System.IO;  
using System.Net;
using Mudanzas.Services;
namespace Mudanzas.Models
{
    public class ModeloSede
    {
        private ISedeDB bd;
        private GoogleService googleService;
        public ModeloSede()
        {
            bd = new SedeDB();
            googleService = new GoogleService();
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
         // POST CAMION
        public async Task<Sede> RegistraSede(int id, string alias, string ciudad, string estado, double latitud, double longitud, string tipoSede, int pertenece)
        { 
            //TODO: modificarle parametros
            Sede nuevaSede = new Sede (id, alias, ciudad, estado, latitud, longitud, tipoSede, pertenece );
            //bd.RegistrarCamion(nuevoCamion); 
            nuevaSede = bd.RegistraSede(nuevaSede);

            List<Sede> listaSedes = bd.obtenerSedes();
            List<DistanciaSede> distancias = new List<DistanciaSede>();
            
            foreach (Sede sede in listaSedes)
            {

                // Logica para sacar la Distancia 
                // Agregar en tabla DistanciaSede.
                // Agregar a table como bulkInsert
                DistanciaSede distancia= await googleService.GetDistanciaFromMaps(nuevaSede, sede);
                if (distancia != null)
                {
                    distancias.Add(distancia);
                }
            }

            bd.GuardarDistancias(distancias);

            return nuevaSede;
        }
    }
}

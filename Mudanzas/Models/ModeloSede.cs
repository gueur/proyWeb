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

namespace Mudanzas.Models
{
    public class ModeloSede
    {
        private ISedeDB bd;
        public ModeloSede()
        {
            bd = new SedeDB();
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
        public Sede RegistraSede(SedeRequest registro)
        { 
            //TODO: modificarle parametros
            Sede nuevaSede = new Sede (registro.id, registro.alias, registro.ciudad, registro.estado, registro.latitud, registro.longitud, registro.tipoSede, registro.pertenece );
            //bd.RegistrarCamion(nuevoCamion);
             
            bd.RegistraSede(nuevaSede);

            List<Sede> listaSedes = bd.obtenerSedes();
            foreach(Sede sede in listaSedes){
                
                // Logica para sacar la Distancia 
                // Agregar en tabla DistanciaSede.
                // Agregar a table como bulkInsert
                
            
            }
             // Create a request for the URL.   
            WebRequest request = WebRequest.Create(
              "https://docs.microsoft.com");
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;
            
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            
            
               
            return nuevaSede;
        }
    }
}

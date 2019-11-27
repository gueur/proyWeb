using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Data;

namespace Mudanzas.Models
{
    public class ModeloCamion
    {
        private dbCamion bd;
        public ModeloCamion()
        {
            bd = new dbCamion();
        }
        // GET CAMION
        public List<Camion> obtenerCamiones()
        {
            return bd.obtenerCamiones();
        }
        // GET CAMION/ALIAS
        public Camion obtenerCamion(int id)
        {
            return bd.obtenerCamion(id);
        }
        
    }
}

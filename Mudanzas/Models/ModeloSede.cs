using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Data;

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
        // PUT SEDE/ALIAS
        public void putSede()
        {
            bd.putSede();
        }


       

    


}
}

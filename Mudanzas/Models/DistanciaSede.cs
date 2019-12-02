using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models
{
    public class DistanciaSede
    {
        private int idSedeOrigen { get; set; }
        private int idSedeDestino{ get; set; }
        private float distancia { get; set; }
        private float tiempo { get; set; }
        
        public DistanciaSede(int idSedeOrigen, int idSedeDestino, float distancia, float tiempo)
        {
            this.idSedeOrigen = idSedeOrigen;
            this.idSedeDestino = idSedeDestino;
            this.distancia = distancia;
            this.tiempo = tiempo;
        }

        public int getIdSedeOrigen()
        {
            return this.idSedeOrigen;
        }

        public void setIdSedeOrigen(int sedeOrigen)
        {
            this.idSedeOrigen = sedeOrigen;
        }
        
        public void setIdSedeDestino(int sedeDestino)
        {
            this.idSedeDestino = sedeDestino;
        }

        public int getIdSedeDestino()
        {
            return this.idSedeDestino;
        }

        public void setDistancia(float distancia)
        {
            this.distancia = distancia;
        }

        public float getDistancia()
        {
            return this.distancia;
        }

        public void setTiempo(float tiempo)
        {
            this.tiempo= tiempo;
        }

        public float getTiempo()
        {
            return this.tiempo;
        }
    }
}

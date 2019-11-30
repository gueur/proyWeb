using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mudanzas.Models
{
    public class Reservacion
    {

        private int folio { get; set; }
        private string sedeOrigen { get; set; }
        private string sedeDestino { get; set; }
        private DateTime fechaReservacion { get; set; }
        private string tipoCamion { get; set; }
        private string idCliente { get; set; }

        public Reservacion(int folio, string sedeOrigen, string sedeDestino, string fechaReservacion, string tipoCamion, string idCliente)
        {
            this.setFolio(folio);
            this.setSedeDestino(sedeDestino);
            this.setSedeOrigen(sedeOrigen);
            //TODO: Podria tener error
            this.setFechaReservacion(DateTime.Parse(fechaReservacion));
            this.setTipoCamion(tipoCamion);
            this.setIdCliente(idCliente);
        }


        public int getFolio()
        {
            return this.folio ;
        }
        public void setFolio(int folio)
        {
            this.folio = folio;
        }

        public string getSedeOrigen()
        {
            return this.sedeOrigen;
        }
        public void setSedeOrigen(string sedeOrigen)
        {
            this.sedeOrigen= sedeOrigen;
        }

        public string getSedeDestino()
        {
            return this.sedeDestino;
        }
        public void setSedeDestino(string sedeDestino)
        {
            this.sedeDestino = sedeDestino;
        }

        public DateTime getFechaReservacion()
        {
            return this.fechaReservacion;
        }
        public void setFechaReservacion(DateTime fechaReservacion)
        {
            this.fechaReservacion = fechaReservacion;
        }

        public string getTipoCamion()
        {
            return this.tipoCamion;
        }
        public void setTipoCamion(string tipoCamion)
        {
            this.tipoCamion = tipoCamion;
        }

        public string getIdCliente()
        {
            return this.idCliente;
        }
        public void setIdCliente(string idCliente)
        {
            this.idCliente = idCliente;
        }
    }
}


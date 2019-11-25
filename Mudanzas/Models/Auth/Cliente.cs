﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Models.Auth
{
    public class Cliente: Usuario
    {
        private string direccion { get; set; }
        public override string getRole()
        {
            return Rol.Cliente;
        }

        public Cliente(int id, string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.telefono = telefono;
            this.correoElectronico = correoElectronico;
            this.direccion= direccion;
        }

        public string getDireccion()
        {
            return this.direccion;
        }
        public void setDireccion(string direccion)
        {
            this.direccion = direccion;
        }


    }
}

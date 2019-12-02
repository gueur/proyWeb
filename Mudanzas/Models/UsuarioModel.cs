using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mudanzas.Models.Auth;
using Mudanzas.Helpers.Requests;
using Mudanzas.Services.IServices;
using Mudanzas.Data;
using Mudanzas.Helpers;
using Mudanzas.Models;
using Mudanzas.Helpers.Templates;

namespace Mudanzas.Models
{
    public class UsuarioModel
    {

        private readonly IUsuarioDB db;

        public UsuarioModel()
        {
            db = new UsuarioDB();
        }
        //TODO: Agregar encriptado a las contrasenas
        public Usuario AutenticarChofer(string correoElectronico, string password)
        {
            Chofer chofer = db.AutorizarChofer(correoElectronico, password);
            if (chofer != null)
            {
                chofer.setToken(JWTHelper.convertoUsuarioToJWT(chofer));
                return chofer;

            }
            return null;
        }

        public List<Prospecto> GetProspectos()
        {
            List<Prospecto> prospectos = db.GetProspectos();
            return prospectos;
        }

        public Chofer RegistrarChofer(string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string password)
        {
            //TODO: Checar esto
            Chofer chofer = new Chofer(nombre, primerApellido, segundoApellido, telefono, correoElectronico, EncryptHelper.encryptString(password));
            db.RegistrarChofer(chofer);
            return chofer;
        }

        public Usuario AutenticarCliente(string correoElectronico, string password)
        {
            Cliente cliente= db.AutorizarCliente(correoElectronico, EncryptHelper.encryptString(password));
            if (cliente != null)
            {
                cliente.setToken(JWTHelper.convertoUsuarioToJWT(cliente));
                return cliente;
            }
            return null;
        }

        public Usuario AutenticarAdmin(string correoElectronico, string password)
        {
            Administrador admin= db.AutorizarAdministrador(correoElectronico, password);
            if(admin!=null){
                admin.setToken(JWTHelper.convertoUsuarioToJWT(admin));
                return admin;
            }
            return null;
        }

        public Administrador RegistrarAdmin(string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string idSede, string password) {
            Administrador admin = new Administrador(nombre, primerApellido, segundoApellido, telefono, correoElectronico, idSede, EncryptHelper.encryptString(password));
            db.RegistrarAdmin(admin);
            return admin;
        }


        public Cliente RegistrarCliente(int idProspecto)
        {
            Cliente c = db.MoverProspectoACliente(idProspecto);
            return c;
        }
        public Cliente RegistrarNuevoCliente(string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string direccion)
        {
            //TODO: modificarle parametros
            Cliente nuevoCliente= new Cliente(nombre, primerApellido, segundoApellido, telefono, correoElectronico, direccion, $"{new Random().Next(10000000, 99999999)}");
            db.RegistrarProspecto(nuevoCliente);
            string email =  UsuarioEmailTemplate.bienvenidoProspecto($"{nuevoCliente.getNombre()} {nuevoCliente.getPrimerApellido()}", nuevoCliente.getToken(), "http://www.proyweb.com.mx");
            EmailHelper.sendEmail(nuevoCliente.getCorreoElectronico(), $"{nuevoCliente.getNombre()} {nuevoCliente.getPrimerApellido()}", email);
            // EmailHelper.sendSMSCodigoVerificacion(nuevoCliente.getTelefono(), nuevoCliente.getToken());
            return nuevoCliente;
        }
        public Cliente VerificarProspecto(string codigoVerificacion)
        {
            //TODO: Modificar esto para que regrese algo el cliente
            Cliente prospecto = new Cliente();
            prospecto.setToken(codigoVerificacion);
            db.VerificacionProspecto(prospecto);
            return prospecto;
        }

        public Usuario CambiarPassword(string password, string token)
        {
            //TODO: Implementarlo bien, no jalla el CheckJWT
            if (JWTHelper.CheckJWT(token))
            {
                Usuario usuario = db.CambiarPassword(EncryptHelper.encryptString(password), token);
                return usuario;
            }

            return null;
        }

        public void OlvidoPassword(string correoElectronico)
        {
            string token = JWTHelper.convertTokenUrl(correoElectronico);
            db.OlvidoPassword(correoElectronico, token);
            
        }
    }
}

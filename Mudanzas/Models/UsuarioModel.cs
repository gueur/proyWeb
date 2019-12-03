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
            Chofer chofer = db.AutorizarChofer(correoElectronico, EncryptHelper.encryptString(password));
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
            Administrador admin= db.AutorizarAdministrador(correoElectronico, EncryptHelper.encryptString(password));
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


        public Cliente RegistrarCliente(int idProspecto, bool aceptado)
        {
            Cliente c = db.MoverProspectoACliente(idProspecto,aceptado);
            if (c!=null && c.getCorreoElectronico()!=null)
            {
                string token = JWTHelper.convertTokenUrl(c.getCorreoElectronico());
                db.OlvidoPassword(c.getCorreoElectronico(), token);
                string nombre = $"{c.getNombre()} {c.getPrimerApellido()}";
                EmailHelper.sendEmail(c.getCorreoElectronico(), nombre, UsuarioEmailTemplate.prospectoAceptado(nombre, $"https://proyweb-1570850601368.web.app/", token));
            }
            return c;
        }
        public Prospecto RegistrarNuevoCliente(string nombre, string primerApellido, string segundoApellido, string telefono, string correoElectronico, string direccion)
        {
            //TODO: modificarle parametros
            Prospecto prospecto= new Prospecto(0,nombre, primerApellido, segundoApellido, telefono, direccion, correoElectronico,$"{new Random().Next(10000000, 99999999)}");
            db.RegistrarProspecto(prospecto);
            string email =  UsuarioEmailTemplate.bienvenidoProspecto($"{prospecto.getNombre()} {prospecto.getPrimerApellido()}", prospecto.getCodigoVerificacion(), "https://proyweb-1570850601368.web.app/");
            EmailHelper.sendEmail(prospecto.getCorreoElectronico(), $"{prospecto.getNombre()} {prospecto.getPrimerApellido()}", email);
            // EmailHelper.sendSMSCodigoVerificacion(nuevoCliente.getTelefono(), nuevoCliente.getToken());
            return prospecto;
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
            Usuario usuario = db.BuscarUsuarioCorreo(correoElectronico);
            if (usuario!=null) { 
                string token = JWTHelper.convertTokenUrl(correoElectronico);
                db.OlvidoPassword(correoElectronico, token);
                string nombre = $"{usuario.getNombre()} {usuario.getPrimerApellido()}";
                EmailHelper.sendEmail(usuario.getCorreoElectronico(), nombre, UsuarioEmailTemplate.cambioContrasena(nombre, $"https://proyweb-1570850601368.web.app/", token));
            }

        }
    }
}

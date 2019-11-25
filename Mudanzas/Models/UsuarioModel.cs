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
    public class UsuarioModel
    {

        private readonly IUsuarioDB db;

        public UsuarioModel()
        {
            db = new UsuarioDB();
        }
        public Usuario AutenticarChofer(LoginRequest usuarioLogin)
        {
            Chofer chofer = db.AutorizarChofer(usuarioLogin.correoElectronico, usuarioLogin.password);
            if (chofer != null)
            {
                chofer.setToken(JWTHelper.convertoUsuarioToJWT(chofer));
                return chofer;

            }
            return null;
        }

        public Usuario AutenticarCliente(LoginRequest usuarioLogin)
        {
            Cliente cliente= db.AutorizarCliente(usuarioLogin.correoElectronico, usuarioLogin.password);
            if (cliente != null)
            {
                cliente.setToken(JWTHelper.convertoUsuarioToJWT(cliente));
                return cliente;
            }
            return null;
        }

        public Usuario AutenticarAdmin(LoginRequest usuarioLogin)
        {
            Administrador admin= db.AutorizarAdministrador(usuarioLogin.correoElectronico, usuarioLogin.password);
            if(admin!=null){
                admin.setToken(JWTHelper.convertoUsuarioToJWT(admin));
                return admin;
            }
            return null;
        }
    }
}

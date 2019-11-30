using Mudanzas.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mudanzas.Services.IServices
{
    interface IUsuarioDB
    {
        Chofer AutorizarChofer(string correoElectronico, string password);
        Cliente AutorizarCliente(string correoElectronico, string password);
        Administrador AutorizarAdministrador(string correoElectronico, string password);
        Usuario CambiarPassword(string password, string token);
        Usuario OlvidoPassword(string correoElectronico, string token);
        Usuario BuscarUsuarioNombre(string nombre, string apellido);
        Usuario BuscarUsuarioId(string id);
        Usuario actualizarUsuario(Usuario user);
        Cliente RegistrarProspecto(Cliente prospecto);
        Cliente VerificacionProspecto(Cliente prospecto);
        Cliente MoverProspectoACliente(int prospectoId);
        Usuario RegistrarChofer(Chofer chofer);
        Usuario RegistrarAdmin(Administrador admin);
    }
}
  
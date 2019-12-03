namespace Mudanzas.Helpers.Templates
{
    public class UsuarioEmailTemplate
    {

        public static string bienvenidoProspecto(string nombre, string codigoVerificacion, string link)
        {
            string template = $"" +
                $"<h2>Bienvenido {nombre}</h2>, <br> para continuar con tu registro introduce este codigo en la aplicación<br>" +
                $"<strong>{codigoVerificacion}</strong><br>" +
                $"<a href=\"{link}\">Link a la aplicacion</a>" +
            $"";
            return template;
        }

        public static string prospectoAceptado(string nombre, string link, string token)
        {
            string template = $"" +
                $"<h2>Hola {nombre}</h2>, ¡Bienvenido a ProyWeb! <br> Actualmente posees una cuenta que te permitirá reservar servicios de mudanza. <br>" +
                $"<h3> Para ingresar a tu cuenta entra a <a href=\"{link}/cambiopass?token={token}\">Mudanzas Proyweb</a> y elige tu contraseña.</h3><br>" +
                $"<h3>Atentamente, <br> el equipo de </h3>" +
                $"<a href=\"{link}\">Mudanzas Proyweb</a>" +
            $"";
            return template;

        }

        public static string cambioContrasena(string nombre, string link, string token)
        {
            string template = $"" +
                $"<h2>Hola {nombre}</h2>, <br> Has pedido un reestablecimiento de tu contraseña de acceso a ProyWeb. <br> " +
                $"<h3> Para cambiar la contraseña de acceso a tu cuenta entra a <a href=\"{link}/cambiopass?token={token}\">Mudanzas Proyweb</a> y elige tu nueva contraseña.</h3><br>" +
                $"<h3>Atentamente, <br> el equipo de </h3>" +
                $"<a href=\"{link}\">Mudanzas Proyweb</a>";
            return template;

        }

        public static string detalleReservacion(string nombre, string folioReservacion, string numAutorizacionPago, string origen, string destino, string tipoCamion, string fechaReservacion, string link)
        {
            string template = $"" +
                $"<h2>Gracias por elegirnos, {nombre}</h2><br>" +
                $"<h6>Folio de resevación: <strong>{folioReservacion}</strong></h6><br>" +
                $"<h6>Número de autorizacion de pago: <strong>{numAutorizacionPago}</strong></h6><br>" +
                $"<h6>Ciudad origen: <strong>{origen}</strong></h6><br>" +
                $"<h6>Ciudad destino: <strong>{destino}</strong></h6><br>" +
                $"<h6>Tipo de camión: <strong>{tipoCamion}</strong></h6><br>" +
                $"<h6>Fecha de resevacion: <strong>{fechaReservacion}</strong></h6><br>" +
                $"<h3>Atentamente, <br> el equipo de </h3>" +
                $"<a href=\"{link}\">Mudanzas Proyweb</a>" +
            $"";
            return template;
        }
    }
}
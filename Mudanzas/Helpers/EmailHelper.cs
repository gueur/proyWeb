using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//SMS
using Twilio;
using Twilio.Rest.Api.V2010.Account;
//Email
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Mudanzas.Helpers
{
    public class EmailHelper
    {
        private static readonly string accountSid = "AC01f1a00a52a6695957e7e109c7ac5c8b";
        private static readonly string authToken = "e6c115b291a1dd16af5e50befca8e50c";
        private static readonly string emailApiKey = "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";



        public async static void sendEmail(string correoElectronico,string nombre, string emailHtml)
        {
            var client = new SendGridClient(emailApiKey);
            var from = new EmailAddress("humbapumbamv@gmail.com","Mudanzas Proyweb");
            var subject = "Bienvenido a envio de correos sendGrid";
            var to = new EmailAddress(correoElectronico, nombre);
            var plainTextContent = "Ejemplo de correo perron de sendgrid";
            var htmlContent = emailHtml;
            var email= MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(email);

        }
        public static void sendSMSCodigoVerificacion(string numero, string numeroVerificacion)
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"Este es un mensaje de verificación de ProyWeb por favor ingrese este código {numeroVerificacion} en la aplicación.",
                from: new Twilio.Types.PhoneNumber("+12053410192"),
                to: new Twilio.Types.PhoneNumber($"+52{numero}")
                );
        }


    }
}

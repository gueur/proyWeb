using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Mudanzas.Helpers
{
    public class EmailHelper
    {
        public static readonly string accountSid = "AC01f1a00a52a6695957e7e109c7ac5c8b";
        public static readonly string authToken = "e6c115b291a1dd16af5e50befca8e50c";

        public static void sendEmail()
        {
            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Este es un mensaje de verificación de ProyWeb por favor ingrese este código 879513 en la aplicación",
                from: new Twilio.Types.PhoneNumber("+12053410192"),
                to: new Twilio.Types.PhoneNumber("+526674714557")
                );
        }


    }
}

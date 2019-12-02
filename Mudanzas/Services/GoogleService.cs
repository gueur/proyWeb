using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mudanzas.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Mudanzas.Services
{
    public class GoogleService
    {

        private readonly string KEY = "AIzaSyCdck7BKZxfVoN_6eY2wJsZcec4ZhleSWM";
        public GoogleService()
        {

        }


        public async Task<DistanciaSede> GetDistanciaFromMaps(Sede origen, Sede destino)
        {
            DistanciaSede distancia = null;
                        using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"https://maps.googleapis.com/maps/api/distancematrix/json?origins={origen.latitud},{origen.longitud}&destinations={destino.latitud},{origen.longitud}&mode=transitg&key={KEY}");
                string tt = await result.Content.ReadAsStringAsync();
                tt = tt.Replace("\n", "");
                tt = tt.Replace("\"", "'");
                var d = JsonConvert.DeserializeObject<JObject>(tt);
                JsonSerializer serializer = new JsonSerializer();
                Google g = (Google)serializer.Deserialize(new JTokenReader(d), typeof(Google));
                if (g.rows[0].elements[0].status != "OK")
                    return null;
                distancia = new DistanciaSede(origen.id, destino.id,g.rows[0].elements[0].distance.value, g.rows[0].elements[0].duration.value);
            }
            return distancia;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Linq;
using Geocoding;
using Geocoding.Google;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
       

        [HttpGet]
        public async Task<IActionResult >GetDatos()
        {

           HttpContent content;
            HttpClient httpClient = new HttpClient();
            string url = "https://maps.googleapis.com/maps/api/geocode/json?latlng= -2.164340633284654,-79.93638611985538 &sensor=true&key=AIzaSyCz9I2ZBKcQf1x6D4lxlP1xi-PErtn-WgY";
          //  string url = "https://maps.googleapis.com/maps/api/geocode/json?latlng= {Latitud},{Longitud}&sensor=true&key={apiKey}";
       
            double Latitud = -0.099098;
            double Longitud = -78.435101;
            string apiKey = "AIzaSyCz9I2ZBKcQf1x6D4lxlP1xi-PErtn-WgY";
            string placeid = "GhIJej3zzZFQAUARdPv2v-37U8A";
            url = url.Replace("{Latitud}",$"{Latitud}").Replace("{Longitud}", $"{Longitud}").Replace("{apiKey}", apiKey);
            var response = await httpClient.GetAsync(url);
            content = response.Content;
            
            var asd = await content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(asd);
       /*     Location location = new Location(Latitud,Longitud);

            IGeocoder geoCoder = new GoogleGeocoder(apiKey); 
            IEnumerable<GoogleAddress> addresses = (IEnumerable<GoogleAddress>)await geoCoder.ReverseGeocodeAsync(location);
            List<object> list = new List<object>();

            addresses.ForEach(e => {

                list.Add(new
                {
                    ty = e.Type,
                    ciudad = e.Components.Select(y => new
                    {
                        y.LongName,
  

                    }).First(),
                   FormateAdress= e.FormattedAddress,
               
                });
            
            });
            list.FirstOrDefault()

         var locaion =  GoogleAddressType.Locality;

*/

            return Ok(json);
        }
    }
    
}

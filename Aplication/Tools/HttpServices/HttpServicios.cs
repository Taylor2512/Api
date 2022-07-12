using Domain.Entities.Http;
using Domain.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Tools.HttpServices
{
    internal class HttpServicios
    {
        public static async Task<TResul?> Paso2Paymen<TResul>(object obj,  string mensaje, string acces_token, string url)
        {
            try
            {
                TResul resultObj;
                var jsonObj = Conversiones.SerializarObjetoAjson(obj, ref mensaje);
                if (jsonObj == null) throw new Exception(mensaje);
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", acces_token);
                    StringContent httpContent = new StringContent(jsonObj, Encoding.UTF8, "application/json");


                    var response = await client.PostAsync(url, httpContent);
                    
                    HttpContent content = response.Content;
                    var a = content.ReadAsStringAsync();
                    a.Wait();
                    string result = a.Result;
                    if (string.IsNullOrEmpty(result)) throw new Exception("Respuesta no válida");
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                    {
                        resultObj = Conversiones.DeserializarJsonAobjeto<TResul>(result, ref mensaje);
                    }
                    else
                    {
                        var codigoRespuesta = Conversiones.DeserializarJsonAobjeto<TResul>(result, ref mensaje);
                        if (codigoRespuesta == null) throw new Exception(mensaje);
                        // resultObj = new ResponseFormularioBtn { codigoRespuesta = codigoRespuesta };
                        resultObj = codigoRespuesta;
                    }
                    if (resultObj == null) throw new Exception(mensaje);
                    return resultObj;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                
            }
            return default(TResul);


        }


    }
}

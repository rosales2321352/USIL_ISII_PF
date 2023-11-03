using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WebApp.Controllers
{
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        [HttpGet]
        [Route("webhook")]
        public string Webhook(
            [FromQuery(Name = "hub.mode")] string mode,
            [FromQuery(Name = "hub.challenge")] string challenge,
            [FromQuery(Name = "hub.verify_token")] string verify_token
        )
        {
            if (verify_token.Equals("hola"))
            {
                return challenge;
            }
            else
            {
                return "";
            }
        }

        [HttpPost]
        [Route("webhook")]
        public dynamic EntryMessage([FromBody] object entry)
        {
            Console.WriteLine(entry.ToString());
            //JToken parsedJson = JToken.Parse(entry);

            // Ahora, puedes imprimir el JSON formateado en la consola
            //Console.WriteLine(parsedJson.ToString(Formatting.Indented));
            //ESTRAEMOS EL MENSAJE RECIBIDO
            /*string mensaje_recibido = entry.entry[0].changes[0].value.messages[0].text.body;
            //ESTRAEMOS EL ID UNICO DEL MENSAJE
            string id_wa = entry.entry[0].changes[0].value.messages[0].id;
            //ESTRAEMOS EL NUMERO DE TELEFONO DEL CUAL RECIBIMOS EL MENSAJE
            string telefono_wa = entry.entry[0].changes[0].value.messages[0].from;
            //INICIALIZAMOS LA CONEXION A LA BD
            MessageRecieved dat = new MessageRecieved(mensaje_recibido, id_wa, telefono_wa);
            //INSERTAMOS LOS DATOS RECIBIDOS
            //dat.PrintMessage();
            //SI NO HAY ERROR RETORNAMOS UN OK
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            */
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }
    }
}
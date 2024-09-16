using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace IDFXML.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("Import data")]
        public async Task<ActionResult> ImportData([Required] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("Файл не был загружен");
            try
            {
                XmlDocument xmlDoc;
                using (var stream = file.OpenReadStream())
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(stream);
                }
                XmlNodeList? orders = xmlDoc.SelectNodes("/orders/order");
                if (orders is null)
                    throw new ArgumentException("Не удалось найти обязательные элементы xml-файла: \"/orders/orders\"");

                var deserializer = new XmlDeserializer();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка обработки XML-файла: " + ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace IDFXML.Application.Interfaces
{
    public interface IOrderService
    {
        public interface IOrderService
        {
            Task ImportOrdersFromXmlAsync(IFormFile xmlFile);
        }
    }
}

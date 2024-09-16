using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public interface IOrderService
    {
        Task AddOrder(Order orderModel);
    }
}

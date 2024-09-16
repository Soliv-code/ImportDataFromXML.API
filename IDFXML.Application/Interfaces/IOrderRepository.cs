using IDFXML.Domain;

namespace IDFXML.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order orderModel);
    }
}

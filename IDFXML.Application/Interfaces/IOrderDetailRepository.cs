using IDFXML.Domain;

namespace IDFXML.Application.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task AddOrderDetail(OrderDetail orderDetail);
        Task AddOrderDetailRange(List<OrderDetail> _orders);
    }
}

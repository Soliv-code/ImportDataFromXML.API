using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public interface IOrderDetailService
    {
        Task AddOrderDetail(OrderDetail orderDetail);
        Task AddOrderDetailRange(List<OrderDetail> _orders);
    }
}

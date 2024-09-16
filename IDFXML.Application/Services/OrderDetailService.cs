using IDFXML.Application.Interfaces;
using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailService _ods;

        public OrderDetailService(IOrderDetailService orderDetailService)
        {
            _ods = orderDetailService;
        }
        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            await _ods.AddOrderDetail(orderDetail);
            return;
        }

        public async Task AddOrderDetailRange(List<OrderDetail> _orders)
        {
            return await _ods.AddOrderDetailRange(_orders);
        }
    }
}

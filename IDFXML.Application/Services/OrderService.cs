using IDFXML.Application.Interfaces;
using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _or;

        public OrderService(IOrderRepository orderRepository)
        {
            _or = orderRepository;
        }
        public async Task AddOrder(Order orderModel)
        {
            await _or.AddOrder(orderModel);
            return;
        }
    }
}

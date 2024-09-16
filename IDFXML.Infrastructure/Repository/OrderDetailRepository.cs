using IDFXML.Application.Interfaces;
using IDFXML.Domain;
using IDFXML.Infrastructure.Context;

namespace IDFXML.Infrastructure.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _db;

        public OrderDetailRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddOrderDetail(OrderDetail orderDetail)
        {
            if(orderDetail is not null)
            {
                await _db.OrderDetails.AddAsync(orderDetail);
                await _db.SaveChangesAsync();
            }
        }

        public async Task AddOrderDetailRange(List<OrderDetail> _orders)
        {
            if(_orders is not null)
            {
                await _db.OrderDetails.AddRangeAsync(_orders);
                await _db.SaveChangesAsync();
            };
        }
    }
}

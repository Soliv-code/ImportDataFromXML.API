using IDFXML.Application.Interfaces;
using IDFXML.Domain;
using IDFXML.Infrastructure.Context;

namespace IDFXML.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddOrder(Order orderModel)
        {
            if(orderModel is not null)
            {
                await _db.Orders.AddAsync(orderModel);
                await _db.SaveChangesAsync();
            }
        }
    }
}

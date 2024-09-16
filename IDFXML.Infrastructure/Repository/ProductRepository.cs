using IDFXML.Application.Interfaces;
using IDFXML.Domain;
using IDFXML.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace IDFXML.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Product?> GetProductByName(string productName)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Name == productName);
        }

        public async Task AddProduct(Product productModel)
        {
            if(productModel is not null)
            {
                await _db.Products.AddAsync(productModel);
                await _db.SaveChangesAsync();
            }
        }
    }
}

using IDFXML.Application.Interfaces;
using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _pr;
        public ProductService(IProductRepository productRepository)
        {
            _pr = productRepository;
        }
        public async Task<Product?> GetProductByName(string ProductName)
        {
            return await _pr.GetProductByName(ProductName);
        }
        public async Task AddProduct(Product productModel)
        {
            await _pr.AddProduct(productModel);
            return;
        }
    }
}

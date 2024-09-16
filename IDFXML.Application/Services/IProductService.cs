using IDFXML.Domain;

namespace IDFXML.Application.Services
{
    public interface IProductService
    {
        Task<Product?> GetProductByName(string ProductName);
        Task AddProduct(Product productModel);
    }
}

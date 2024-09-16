using IDFXML.Domain;

namespace IDFXML.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByName(string ProductName);
        Task AddProduct(Product productModel);
    }
}

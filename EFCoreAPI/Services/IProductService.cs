using EFCoreAPI.Models;

namespace EFCoreAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync( int productId);
        Task<Product> CreateProductAsync(Product ProductToCreate);
        Task DeleteProductAsync(int id);
        Task<Product> UpdateProductAsync(Product ProductToUpdate);


    }
}

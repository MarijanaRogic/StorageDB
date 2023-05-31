using EFCoreAPI.Models;
using EFCoreAPI.Models.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EFCoreAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext; //injection from dbcontext

        public ProductService(AppDbContext dbContext)  //contructor
        {
            _dbContext = dbContext;
        }



        public async Task<Product> CreateProductAsync(Product ProductToCreate)
        {
            var product = Product.MapFromProducts(ProductToCreate);

            var productDb = await _dbContext.product.SingleOrDefaultAsync(pro => pro.ProductId == product.ProductId);

            if (productDb != null)
            {
                productDb.ProductId = product.ProductId;
                productDb.Name = product.Name;
                productDb.Cost = product.Cost;
                productDb.UpdatedAt = DateTime.Now;


                await _dbContext.SaveChangesAsync();
                return Product.MapFromProducts(productDb);
            }
            else
            {
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                product.Active = true;

                await _dbContext.product.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return Product.MapFromProducts(product);

            }

            return ProductToCreate;
        }


        public async Task DeleteProductAsync(Product productToDelete)
        {
            var product = new Product();

            _dbContext.product.Remove(product);
            await _dbContext.SaveChangesAsync();
            return;

        }

        public async Task DeleteProductAsync(int id)
        {
            var product = _dbContext.product.Find(id);
            if(product != null)
            {
                _dbContext.product.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
            
            return;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var result = await _dbContext.product.ToListAsync();

            var prod = new List<Product>();

            foreach (var pro in result)
            {
                prod.Add(Product.MapFromProducts(pro));
            }
            return prod;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
             return await _dbContext.product.FindAsync(productId);
            
        }

        public Task<Product> UpdateProductAsync(Product ProductToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}

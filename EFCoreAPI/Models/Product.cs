using System.ComponentModel.DataAnnotations;

namespace EFCoreAPI.Models
{
    public class Product : IUpdateable
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
       DateTime IUpdateable.CreatedAt { get; set; }

        public static Product MapFromProducts(Product pro)
        {
            return new()
            {
                ProductId = pro.ProductId,
                Name = pro.Name,
                Cost = pro.Cost,
                Active = pro.Active,
                CreatedAt = pro.CreatedAt,
                UpdatedAt = pro.UpdatedAt

            };

        }

        internal Product MapFromProduct(Product productDb)
        {
            throw new NotImplementedException();
        }
    }
}

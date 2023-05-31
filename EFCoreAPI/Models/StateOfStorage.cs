using System.ComponentModel.DataAnnotations;

namespace EFCoreAPI.Models
{
    public class StateOfStorage 
    {
        [Key]

        public int StateOfStorageId { get; set; }
        public int StorageId { get; set; }  
        public Storage Storage { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }

        public static StateOfStorage MapFromStateOfStorage(StateOfStorage sos)
        {
            return new()
            {
                StateOfStorageId = sos.StateOfStorageId,
                StorageId = sos.StorageId,
                ProductId = sos.ProductId,
                Quantity = sos.Quantity,
                CreatedAt = sos.CreatedAt,
                UpdatedAt = sos.UpdatedAt,
                Active = sos.Active
            };

        }
    }

    
}

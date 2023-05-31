using System.ComponentModel.DataAnnotations;

namespace EFCoreAPI.Models
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        
        public string Name { get; set; }

        public string KindOfStorage { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }

        public static Storage MapFromStorage(Storage stor)
        {
            return new()
            {
                StorageId = stor.StorageId,
                Name = stor.Name,
                KindOfStorage = stor.KindOfStorage,
                Active = stor.Active,
                CreatedAt = stor.CreatedAt,
                UpdatedAt = stor.UpdatedAt

            };

        }
    }
}

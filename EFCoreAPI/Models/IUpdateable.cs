namespace EFCoreAPI.Models
{
    public interface IUpdateable
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Active { get; set; }
    }
}

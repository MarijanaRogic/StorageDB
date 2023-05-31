using Microsoft.EntityFrameworkCore;

namespace EFCoreAPI.Models.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> product { get; set; }
        public Task Product { get; internal set; }
        public DbSet<Storage> storage { get; set; }
        public DbSet<StateOfStorage> stateofstorage { get; set; }




    }
}

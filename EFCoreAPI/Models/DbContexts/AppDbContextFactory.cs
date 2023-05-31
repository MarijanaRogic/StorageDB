using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreAPI.Models.DbContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBulider = new DbContextOptionsBuilder<AppDbContext>();
            optionBulider.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StorageDB;Integrated Security=True;Connect Timeout=300;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new AppDbContext(optionBulider.Options);
        }
    }
}

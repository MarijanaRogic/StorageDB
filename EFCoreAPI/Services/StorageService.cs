using EFCoreAPI.Models;
using EFCoreAPI.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAPI.Services
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _dbContext; //injection from dbcontext

        public StorageService(AppDbContext dbContext)  //contructor
        {
            _dbContext = dbContext;
        }

        public async Task<Storage> CreateStorageAsync(Storage StorageToCreate)
        {
            var storage = Storage.MapFromStorage(StorageToCreate);

            var storageDb = await _dbContext.storage.SingleOrDefaultAsync(str => str.StorageId == storage.StorageId);

            if(storageDb != null)
            {
                storageDb.Name = storage.Name;
                storageDb.KindOfStorage = storage.KindOfStorage;
                storageDb.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                storage.CreatedAt = DateTime.Now;
                storage.Active = true;

                await _dbContext.storage.AddAsync(storage);
                await _dbContext.SaveChangesAsync();
            }

            return StorageToCreate;
        }

        //public async Task DeleteStorageAsync(Storage StorageToDelete)
        //{
        //    //var storage = _dbContext.storage.Find(StorageToDelete);
        //    //if(storage != null)
        //    //{
        //    //    _dbContext.storage.Remove(storage);
        //    //    await _dbContext.SaveChangesAsync();
        //    //}
        //    //return;
        //}

        public async Task DeleteStorageAsync(int id)
        {
            var storage = _dbContext.storage.Find(id);
            if (storage != null)
            {
                _dbContext.storage.Remove(storage);
                await _dbContext.SaveChangesAsync();
            }
            return;

        }

        public async Task<List<Storage>> GetAllStoragesAsync()
        {
            var storage = await _dbContext.storage.ToListAsync();

            var str = new List<Storage>();
            
            foreach (var st in storage)
            {
                str.Add(Storage.MapFromStorage(st));
            }
            return str;
        }

        public async Task<Storage> GetStorageByIdAsync(int id)
        {
            return await _dbContext.storage.FindAsync(id);
        }
    }
}

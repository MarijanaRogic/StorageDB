using EFCoreAPI.Models;
using EFCoreAPI.Models.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAPI.Services
{
    public class StateOfStorageService : IStateOfStorageService
    {
        private readonly AppDbContext _dbContext; //injection from dbcontext

        public StateOfStorageService(AppDbContext dbContext)  //contructor
        {
            _dbContext = dbContext;

        }
        public async Task<StateOfStorage> CreateStateOfStorage(StateOfStorage stateOfStorageCreate)
        {
            var stateOfStorage = StateOfStorage.MapFromStateOfStorage(stateOfStorageCreate);

            var stateOfStorageDb = await _dbContext.stateofstorage.SingleOrDefaultAsync(sos => sos.StateOfStorageId == stateOfStorage.StateOfStorageId);

            if(stateOfStorageDb != null)
            {
                stateOfStorageDb.StorageId = stateOfStorage.StorageId;
                stateOfStorageDb.ProductId = stateOfStorage.ProductId;
                stateOfStorageDb.Quantity = stateOfStorage.Quantity;
                stateOfStorageDb.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                stateOfStorage.CreatedAt = DateTime.Now;
                stateOfStorage.Active = true;

                await _dbContext.stateofstorage.AddAsync(stateOfStorage);
                await _dbContext.SaveChangesAsync();

            }


            return stateOfStorage;
        }

        public async Task DeleteStateOfStorage(int id)
        {
            var dsos = _dbContext.stateofstorage.Find(id);
            if(dsos != null)
            {
                _dbContext.stateofstorage.Remove(dsos);
                await _dbContext.SaveChangesAsync();
            }

            return;

        }

        public async Task<List<StateOfStorage>> GetAllStateOfStoragesAsync()
        {
            var list = await _dbContext.stateofstorage.ToListAsync();

            var stateOfStorage = new List<StateOfStorage>();

            foreach(var state in list)
            {
                stateOfStorage.Add(StateOfStorage.MapFromStateOfStorage(state));
            }

            return stateOfStorage;
        }

        public async Task<StateOfStorage> GetStatesOfStorageById(int id)
        {
            return await _dbContext.stateofstorage.FindAsync(id);
        }
    }
}

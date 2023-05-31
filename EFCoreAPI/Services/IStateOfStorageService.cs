using EFCoreAPI.Models;

namespace EFCoreAPI.Services
{
    public interface IStateOfStorageService
    {
        Task<List<StateOfStorage>> GetAllStateOfStoragesAsync();

        Task<StateOfStorage> GetStatesOfStorageById(int id);

        Task<StateOfStorage> CreateStateOfStorage(StateOfStorage stateOfStorage);

        Task DeleteStateOfStorage(int id);
       
    }
}

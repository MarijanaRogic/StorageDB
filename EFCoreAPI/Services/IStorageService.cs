using EFCoreAPI.Models;

namespace EFCoreAPI.Services
{
    public interface IStorageService
    {
        Task<List<Storage>> GetAllStoragesAsync();

        Task<Storage> GetStorageByIdAsync(int id);
        Task<Storage> CreateStorageAsync(Storage StorageToCreate);
        Task DeleteStorageAsync(int id);
    }
}

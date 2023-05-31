using EFCoreAPI.Models;
using EFCoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetStorage()
        {
            var storage = await _storageService.GetAllStoragesAsync();
            return Ok(storage);
        }

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> GetStorageById(int Id)
        {
            var storId = await _storageService.GetStorageByIdAsync(Id);
            return Ok(storId);
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateStorage([FromBody] Storage storage)
        {
            var str = await _storageService.CreateStorageAsync(storage);

            return Ok(storage);
        }

        [HttpDelete]
        [Route("[action]")]

        public async Task<IActionResult> DeleteStorage(int id)
        {
            await _storageService.DeleteStorageAsync(id);
            return Ok();


        }
    }
}

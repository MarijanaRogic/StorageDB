using EFCoreAPI.Models;
using EFCoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EFCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateOfStorageController : ControllerBase
    {
        private readonly IStateOfStorageService _stateOfStorageService;

        public StateOfStorageController(IStateOfStorageService stateOfStorageService)
        {
            _stateOfStorageService = stateOfStorageService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<ActionResult> GetStateOfStorage()
        {
            var stateOfStorage = await _stateOfStorageService.GetAllStateOfStoragesAsync();
            return Ok(stateOfStorage);

        }

        [HttpGet]
        [Route("[action]/{Id}")]

        public async Task<ActionResult> GetStateOfStorageById(int Id)
        {
            var sosId = await _stateOfStorageService.GetStatesOfStorageById(Id);
            return Ok(sosId);
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<ActionResult> CreateStateOfStorage([FromBody] StateOfStorage stateOfStorage)
        {
            var csos = await _stateOfStorageService.CreateStateOfStorage(stateOfStorage);

            return Ok(stateOfStorage);
        }

        [HttpDelete]
        [Route("[action]")]

        public async Task<ActionResult> DeleteStateOfStorage(int id)
        {
            await _stateOfStorageService.DeleteStateOfStorage(id);
            return Ok();
        }



    }
}

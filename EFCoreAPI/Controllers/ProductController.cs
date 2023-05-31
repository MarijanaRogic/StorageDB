using EFCoreAPI.Models;
using EFCoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<ActionResult> GetProductsById(int Id)
        {
            var prodId = await _productService.GetProductByIdAsync(Id);
            return Ok(prodId);
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var prd = await _productService.CreateProductAsync(product);

            return Ok(product);
        }

        [HttpDelete]
        [Route("[action]")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();


        }

    }
    }

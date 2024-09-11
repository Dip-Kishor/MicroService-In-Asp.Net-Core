using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Services;

namespace ProductMicroservice.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<ProductModel>> AddProduct(ProductModel product)
        {
            var createdProduct = await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }
    }
}

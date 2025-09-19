using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubeBeneficios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseControllers
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductDto productDTO)
        {
            var result = await _productService.CreateAsync(productDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProductssync()
        {
            var result = await _productService.GetAllProductsAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }


        
        [HttpGet("filter")]
        public async Task<ActionResult> GetProductsByFilteringAsync([FromQuery] int minPrice, [FromQuery] int maxPrice)
        {
            var result = await _productService.GetProductsByFilteringAsync(minPrice, maxPrice);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

using Api.DTOs;
using Asp.Versioning;
using Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductBusiness _productBusiness;

        public ProductsController(ProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }



        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var product = await _productBusiness.GetProduct();

            if (product is null)
                return NotFound(new { message = "Product not found." });

            var response = new ProductV1ResponseDto(
                product.Id,
                product.Name,
                product.Price
            );

            return Ok(response);
        }
    }
}
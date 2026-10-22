using Api.DTOs;
using Asp.Versioning;
using Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
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

            var response = new ProductV2ResponseDto(
                product.Id,
                product.Name,
                product.Price,
                product.CategoryName
            );

            return Ok(response);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllProduct()
        {
            try
            {
                var products = _productService.GetProductsApi();

                return Ok(products);


            }
            catch (Exception ex)
            {
                return StatusCode(500, "Servis Hatası");
            }
        }
    }
}

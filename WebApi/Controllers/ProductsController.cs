using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProduct()
        {
            var result = productService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetProductById")]
        public IActionResult GetProductByd(int id)
        {
            var result = productService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("AddProduct")]
        public IActionResult Add(Product product)
        {
            var result = productService.Add(product);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

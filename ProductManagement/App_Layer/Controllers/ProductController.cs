using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService service;
        public ProductController(ProductService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult Get()
        {
            var data = service.Get();
            return Ok(data);
        }
        [HttpGet("all/{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }
        [HttpPost("Create")]
        public IActionResult Create(ProductDTO p)
        {
            var data = service.Create(p);
            return Ok(data);

        }
        [HttpPost("update")]
        public IActionResult Update(ProductDTO p)
        {
            var data = service.Update(p);
            return Ok(data);

        }
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            return Ok(data);
        }

    }
}

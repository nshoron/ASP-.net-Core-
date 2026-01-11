using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace App_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        CatagoryService service;
        public CatagoryController(CatagoryService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.Get();
            return Ok(data);

        }
        [HttpGet("GetID")]
        public IActionResult Get(int id)
        {
            var data=service.Get(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(CatagoryDTO c)
        {
            var res =service.Create(c);
            if(res==true)
            {
               return Ok(res);
            }
            else {return BadRequest(res); }
        }
        [HttpPost("Update")]
        public IActionResult Update(CatagoryDTO c)
        {
            var res = service.Update(c);
            if (res == true)
            {
                return Ok(res);
            }
            else { return BadRequest(res); }
        }
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = service.Delete(id);
            if (res == true)
            {
                return Ok(res);
            }
            else { return BadRequest(res); }
        }
        [HttpGet("withproducts")]
        public IActionResult GetWithProducts()
        {
            var data = service.GetWithProducts();
            return Ok(data);
        }

    }
}

using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App_layer
{
    [Route("Api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentService Service;
        public StudentController (StudentService Service)
        {
            this.Service = Service;
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = Service.Get();
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create (StudentDTO s)
        {
            var res = Service.Create(s);
            return Ok(res);


        }

    }
}

using IntroWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentController: ControllerBase
    {
        [HttpGet("all")]
        public IActionResult All()
        {
            var d1 = new DepartmentDTO()
            {
                Id = 1,
                Name = "CSE"

            };
            var d2 = new DepartmentDTO()
            {
                Id=2,
                Name="EEE"

            };

            var data = new List<DepartmentDTO> { d1, d2 };
            return Ok(data);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var d1 = new DepartmentDTO() { Id = id,Name="DF"+id };
            return Ok(d1);


        }
        [HttpGet("id/{id}/name/{name}")]
        public IActionResult Get(int id, string name)
        {
            var d1= new DepartmentDTO()
            { 
                Id = id,
                Name = name 
            };
            return Ok(d1);

        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO DT)
        { return Ok(DT); }

    }
}

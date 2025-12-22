using IntroWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var s1 = new StudentDTO()
            {
                Id=1,Name="SHoron",Email="@gmail",
                Phone="025511"
               
            };
            var s2 = new StudentDTO()
            {
                Id = 2,
                Name = "Sn",
                Email = "@mail",
                Phone = "05511"
            };
            var data =new List <StudentDTO> { s1, s2 };
            return Ok(data);

        }
        [HttpPost]
        public IActionResult Post (StudentDTO s)
        {
            return Ok(s);
        }
        

    }
}

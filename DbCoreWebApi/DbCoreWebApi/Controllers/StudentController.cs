
using DbCoreWebApi.EF;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using DbCoreWebApi.EF.Models;


namespace DbCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly UmsContext db;
        public StudentController(UmsContext db) { this.db = db; }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = db.Students.ToList();
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create()
        {
            var s1 = new Student
            {
                Name = "Shoron",
                Email = "Shoron@gmail.com",
                Gender = "Male"
            };

            db.Students.Add(s1);
            db.SaveChanges();

            return Ok(s1);
        }

    }
}

using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        DoctorAvailabilityService service;
        public AvailabilityController(DoctorAvailabilityService service)

        {
            this.service = service;
        }
        [HttpPost("Create/DoctorAvailability")]
        public IActionResult CreateDoctorAvailability(DoctorAvailabilityDTO da)
        {
            var result = service.CreateDoctorAviability(da);
            if(result==false)
            {                 
                return BadRequest("Could not create availability");
            }
            return Ok(result);
        }
        [HttpGet("AvailableDoctor/{Day}")]
        public IActionResult GetAvailableDoctor(string dayofweek)
        {
            var result=service.AvailableDoctors(dayofweek);
            if (result == null)
            {
                return NotFound("No doctor Found");
            }
            return Ok(result);
        }
    }
}

using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTOs;

namespace App_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        DoctorService service;
        public DoctorController(DoctorService service)
        {
            this.service = service;
        }
        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = service.GetAll();
            if (result == null)
            {
                return NotFound("No doctors found.");
            }
            return Ok(result);
        }
        [HttpGet("Getby/{id}")]
        public IActionResult Get(int id)
        {
            var result = service.Get(id);
            if (result == null)
            {
                return NotFound("No doctors found.");
            }
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create(DoctorDTO dto)
        {
            var result = service.Create(dto);
            if (result == false)
            {
                return BadRequest("Doctor creation failed.");
            }
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(DoctorDTO dto)
        {
            var result = service.Update(dto);
            if (result == false)
            {
                return BadRequest("Doctor update failed.");
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result == false)
            {
                return BadRequest("Doctor delete failed.");
            }
            return Ok(result);
        }
        [HttpGet("SearchByStatus")]
        public IActionResult FilterbyStatus(string status)
        {
            var result = service.FilterbyStatus(status);
            if (result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);

        }
        [HttpGet("GetDoctorsWithPatients")]
        public IActionResult GetDoctorWithPatient()
        {
            var result = service.GetDoctorWithPatient();
            if (result == null)
            {
                return NotFound("Not Found");
            }

            return Ok(result);
        }
        [HttpGet("GetDoctorByNameWithPatient")]
        public IActionResult GetDoctorByNameWithPatient(string name)
        {
            var result=service.GetDoctorByName(name);
            if (result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }

    }
}

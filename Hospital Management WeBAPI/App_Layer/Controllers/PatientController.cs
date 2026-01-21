using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace App_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        PatientService service;
        public PatientController(PatientService service)
        {
            this.service = service;
        }
        [HttpGet("Getall")]
        public IActionResult GetAllPatient()
        {
            var result = service.GetAllPatient();
            if (result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var result = service.Get(id);
            if (result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create(PatientDTO dto)
        {
            var result = service.Create(dto);
            if (result == false)
            {
                return BadRequest("Could not create patient");
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult Update(PatientDTO dto)
        {
            var result = service.Upadte(dto);
            if (result == false)
            {
                return BadRequest("Could not update");
            }
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result == false)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }
        [HttpGet("FilterByAge")]
        public IActionResult FilterByAge(int MinAge,int MaxAge)
        {
            var result = service.FilterbyAge(MinAge,MaxAge);
            if (result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }
      

    }
}

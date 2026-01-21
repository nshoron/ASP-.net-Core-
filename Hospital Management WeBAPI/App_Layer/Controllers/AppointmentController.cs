using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace App_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentService service;
        public AppointmentController(AppointmentService service)
        {
            this.service = service;
           
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = service.GetAllAppointments();

            if (result == null || result.Count==0)
            {
                return NotFound("No appointments found");
            }

            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var result = service.Get(id);
           if(result== null)
            {
                return NotFound("Appointment not found");
                
            }
            return Ok(result);
        }
        [HttpPost("Create")]
        public IActionResult Create(AppointmentDTO dto)
        {
            var result = service.Create(dto);
            if (result == false)
            {
               return BadRequest("Failed to create appointment");

            }
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(AppointmentDTO dto)
        {
            var result = service.Update(dto);
            if (result == false)
            {
                return BadRequest("Failed to create appointment");
            }

            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (result == false)
            { 
             return BadRequest("Failed to delete appointment");
            }
            return Ok(result);
        }
        [HttpGet("AdvancedFilter")]
        public IActionResult AdvanceFilter(int? doctorId, int? patientId, string? status)
        {
            var result = service.AdvanceFilter(doctorId, patientId, status);
            if (result == null || result.Count == 0)
            {
                return NotFound("No appointments found with the given criteria");
            }
            return Ok(result);
        }
        [HttpGet("Appointment/PatientAlert")]
        public IActionResult GetAppointmentAlert(int id)
        {
            var alert = service.GetAppointmentAlertForPatient(id);

            if (alert == "Appointment not found")
                return NotFound(alert);

            return Ok(alert);
        }
        [HttpPut("Cancel/{id}")]
        public IActionResult Cancel(int id)
        {
            var result = service.Cancel(id);
            if (result == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to cancel appointment");
            }
            
        }
        [HttpPut("Confirm/{id}")]
        public IActionResult Confirm(int id)
        {
            var result = service.Confirm(id);
            if (result == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Failed to confirm appointment");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public string Time { get; set; }

        public string Status { get; set; }= "Pending";
        public int DoctorId { get; set; }

        
        public int PatientId { get; set; }
    }
}

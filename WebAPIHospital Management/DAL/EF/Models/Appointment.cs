using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public string Time { get; set; }

        
        
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Status { get; set; } = "Pending";

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }




    }
}

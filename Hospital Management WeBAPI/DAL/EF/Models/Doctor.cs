using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string DoctorName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string Status { get; set; }

        // One-to-Many
        public virtual ICollection<Appointment> Appointments { get; set; }

        public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }






    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class DoctorAvailability
    {
        [Key]
        public int AvailabilityId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}

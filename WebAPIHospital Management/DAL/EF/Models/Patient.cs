using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string PatientName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }




    }
}

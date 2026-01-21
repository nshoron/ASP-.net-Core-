using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }
       

    }
}

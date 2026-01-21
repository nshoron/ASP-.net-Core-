using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.DTOs
{
    public class DoctorPatientDTO 
    {
        public DoctorDTO Doctor { get; set; }

        public List<PatientDTO> Patients { get; set; }
        public DoctorPatientDTO()
        {
            Patients = new List<PatientDTO>();
            
        }
    }
}

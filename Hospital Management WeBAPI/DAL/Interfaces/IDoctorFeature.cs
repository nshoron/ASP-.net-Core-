using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDoctorFeature
    {
       
        List<Doctor> GetWithPatients();
        List<Doctor> FilterbyStatus(string? Status);
        Doctor GetByNameWithPatient (string name);


    }
}

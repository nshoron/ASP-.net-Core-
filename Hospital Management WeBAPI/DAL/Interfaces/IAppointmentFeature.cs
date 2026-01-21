using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAppointmentFeature
    {
    List<Appointment> FilterBy(int? doctorId,int? patientId,string? status);
    }
}

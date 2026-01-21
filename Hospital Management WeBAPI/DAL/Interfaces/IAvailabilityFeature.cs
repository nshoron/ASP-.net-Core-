using DAL.EF.Models;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAvailabilityFeature
    {
        public bool CreateAvailability(DoctorAvailability Da);
        public List<DoctorAvailability> AvailableDoctor(string date);
    }
}

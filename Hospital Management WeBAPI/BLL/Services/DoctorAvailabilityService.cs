using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorAvailabilityService
    {
        DataAccessFactory factory;
        public DoctorAvailabilityService (DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public bool CreateDoctorAviability(DoctorAvailabilityDTO da)
        {
            var mapper = MapperConfig.GetMapper();
            var data=mapper.Map<DoctorAvailability>(da);
            return factory.AvailabilityFeature().CreateAvailability(data);
             
        }
        public List<AvailableDoctorDTO> AvailableDoctors(string dayofweek)
        {
           var data=factory.AvailabilityFeature().AvailableDoctor(dayofweek);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<AvailableDoctorDTO>>(data);
        }
    }
}

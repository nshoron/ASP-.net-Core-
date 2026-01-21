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
    public class DoctorService
    {
        DataAccessFactory factory;
        public DoctorService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<DoctorDTO> GetAll()
        {
            var data = factory.DoctorData().GetAll();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<DoctorDTO>>(data);

        }
        public DoctorDTO Get(int id)
        {
            var data = factory.DoctorData().Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<DoctorDTO>(data);
        }
        public bool Create(DoctorDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Doctor>(dto);
            return factory.DoctorData().Create(data);
        }
        public bool Update(DoctorDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Doctor>(dto);
            return factory.DoctorData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.DoctorData().Delete(id);
        }
        public List<DoctorDTO> FilterbyStatus(string Status)
        {
            var data = factory.DoctorFeature().FilterbyStatus(Status);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<DoctorDTO>>(data);
        }
        public List<DoctorPatientDTO> GetDoctorWithPatient()
        {
            var data = factory.DoctorFeature().GetWithPatients();
            var mapper = MapperConfig.GetMapper();

            return mapper.Map<List<DoctorPatientDTO>>(data);


        }
        public DoctorPatientDTO GetDoctorByName(string name)
        {
            var data = factory.DoctorFeature().GetByNameWithPatient(name);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<DoctorPatientDTO>(data);
        }
    }
    }

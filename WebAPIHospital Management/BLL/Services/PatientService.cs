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
    public class PatientService
    {
        DataAccessFactory factory;
        public PatientService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<PatientDTO> GetAllPatient()
        {
            var data = factory.PatientData().GetAll();
            var mapper= MapperConfig.GetMapper().Map<List<PatientDTO>>(data);
            return mapper;
        }
        public PatientDTO Get(int id)
        {
            var data=factory.PatientData().Get(id);
            var mapper = MapperConfig.GetMapper().Map<PatientDTO>(data);
            return mapper;
        }
        public bool Create(PatientDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var data= mapper.Map<Patient>(dto);
            return factory.PatientData().Create(data);


        }
        public bool Upadte(PatientDTO dto)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Patient>(dto);
            return factory.PatientData().Update(data);

        }
        public bool Delete (int id)
        {
         return factory.PatientData().Delete(id);
        }
        public List<PatientDTO> FilterbyAge(int  MinAge,int MaxAge)
        {
            var data = factory.PatientFeature().FilterbyAge(MinAge, MaxAge);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<PatientDTO>>(data);
        }
      





    }
}

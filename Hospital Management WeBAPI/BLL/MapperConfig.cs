using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Doctor, DoctorDTO>().ReverseMap();
            cfg.CreateMap<Patient, PatientDTO>().ReverseMap();
            cfg.CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            cfg.CreateMap<DoctorAvailability, DoctorAvailabilityDTO>().ReverseMap();
            cfg.CreateMap<DoctorAvailability, AvailableDoctorDTO>()
                              .ForMember(d => d.DoctorName,
                                o => o.MapFrom(s => s.Doctor.DoctorName)).ReverseMap();

            cfg.CreateMap<Doctor, DoctorPatientDTO>()
                         .ForMember(d => d.Doctor,
                             o => o.MapFrom(s => new DoctorDTO
                             {
                                 DoctorId = s.DoctorId,
                                 DoctorName = s.DoctorName,
                                 Status = s.Status
                             }))
                         .ForMember(d => d.Patients,
                             o => o.MapFrom(s =>
                                 s.Appointments
                                  .Where(a => a.Patient != null)
                                  .Select(a => a.Patient)
                             )).ReverseMap();
        });
                        
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }

    }
}

using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        HASDbContext db;
        public DataAccessFactory(HASDbContext db)
        {
            this.db = db;
        }
        public IRepository<Doctor> DoctorData()
        {
            return new DoctorRepositoy(db);
        }
        public IDoctorFeature DoctorFeature ()
        { 
        return new DoctorRepositoy(db);
        }
        public IRepository<Patient> PatientData()
        {
            return new PatientRepository(db);
        }
        public IRepository<Appointment> AppointmentData()
        {
            return new AppointmentRepository(db);
        }
        public IAvailabilityFeature AvailabilityFeature()
        {
            return new DoctorAvailablityRepository(db);
        }
        public IPatientFeature PatientFeature()
        {
            return new PatientRepository(db);
        }
        public IAppointmentFeature AppointmentFeature()
        {
            return new AppointmentRepository(db);
        }
    }
}

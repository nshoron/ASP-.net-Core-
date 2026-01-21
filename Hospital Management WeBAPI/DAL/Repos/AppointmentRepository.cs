using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AppointmentRepository : IRepository<Appointment>, IAppointmentFeature
    {
        HASDbContext db;
        public AppointmentRepository(HASDbContext db)
        {
            this.db = db;
        }

        public bool Create(Appointment a)
        {
            db.Appointments.Add(a);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Appointments.Find(id);
            db.Appointments.Remove(ex);
            return db.SaveChanges() > 0;
        }
        public Appointment Get(int id)
        {
            return db.Appointments.Find(id);
        }

        public List<Appointment> GetAll()
        {
            return db.Appointments.ToList();
        }

        public bool Update(Appointment a)
        {
            var ex = db.Appointments.Find(a.AppointmentId);
            db.Entry(ex).CurrentValues.SetValues(a);
            return db.SaveChanges() > 0;

        }

        public List<Appointment> FilterBy(int? doctorId, int? patientId, string? status)
        {
            var query = db.Appointments.AsQueryable();
            if (doctorId.HasValue)
            {
                query = query.Where(a => a.DoctorId == doctorId);
            }
            if (patientId.HasValue)
            {
                query = query.Where(a => a.PatientId == patientId);
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(a => a.Status.Contains(status));
            }
            return query.ToList();
        }
    }
}

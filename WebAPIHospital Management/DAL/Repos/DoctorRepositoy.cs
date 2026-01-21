using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorRepositoy : IRepository<Doctor>, IDoctorFeature
    {
        HASDbContext db;
        public DoctorRepositoy(HASDbContext db)
        {
            this.db = db;
        }

        public List<Doctor> GetAll()
        {
            return db.Doctors.ToList();
        }
        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);

        }

        public bool Create(Doctor d)
        {
            db.Doctors.Add(d);
            return db.SaveChanges()>0;

        }

        public bool Delete(int id)
        {
            var ex= db.Doctors.Find(id);
            var ret=db.Doctors.Remove(ex);
            return db.SaveChanges() > 0;
        }

       



        public bool Update(Doctor d)
        {
           var ex= db.Doctors.Find(d.DoctorId);
            db.Entry(ex).CurrentValues.SetValues(d);
            return db.SaveChanges() > 0;
        }
        //Funtionlities
     
        public List<Doctor> GetWithPatients()
        {
           var data=db.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToList();
            return data;
            
        }

        public Doctor GetByNameWithPatient(string name)
        {
            var data = db.Doctors.Include(d => d.Appointments)
                               .ThenInclude(a => a.Patient)
                               .FirstOrDefault(d => d.DoctorName == name);
            return data;
        }

        public List<Doctor> FilterbyStatus(string? Status)
        {
            var query=db.Doctors.AsQueryable();
            if(!string.IsNullOrEmpty(Status))
            {
                query = query.Where(d => d.Status.Contains(Status));
            }
            return query.ToList();
        }
    }

    }

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
    internal class PatientRepository : IRepository<Patient>,IPatientFeature
    {
        HASDbContext db;
        public PatientRepository(HASDbContext db)
        {
            this.db = db;
        }
        public bool Create(Patient p)
        {
            db.Patients.Add(p);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = db.Patients.Find(id);
            db.Patients.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Patient Get(int id)
        {
            var data = db.Patients.Find(id);

            return data;
        }

        public List<Patient> GetAll()
        {
           return db.Patients.ToList();
        }

        public bool Update(Patient p)
        {
          var ex= db.Patients.Find(p.PatientId);
            db.Entry(ex).CurrentValues.SetValues(p);
            return db.SaveChanges() > 0;
        }
       
        public List<Patient> FilterbyAge(int? MinAge, int? MaxAge)
        {
            var query = db.Patients.AsQueryable();
            if (MinAge.HasValue)
            {
                query = query.Where(p => p.Age >= MinAge);
            }
            if (MaxAge.HasValue)
            {
                query = query.Where(p => p.Age <= MaxAge);
            }
            return query.ToList();
        }

     
        }

    }


using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class DoctorAvailablityRepository : IAvailabilityFeature
    {
        HASDbContext db;
        public DoctorAvailablityRepository (HASDbContext db)
        {
            this.db = db;
        }

        public List<DoctorAvailability> AvailableDoctor(string Dayofweek)
        {
            return db.DoctorAvailabilities
             .Include(d => d.Doctor)
             .Where(a => a.DayOfWeek== Dayofweek)
             .ToList(); ;
        }

        public bool CreateAvailability(DoctorAvailability Da)
        {
            db.DoctorAvailabilities.Add(Da);
            return db.SaveChanges() > 0;

        }
    }
}

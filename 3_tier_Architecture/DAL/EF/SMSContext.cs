using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SMSContext : DbContext
    {
        public SMSContext(DbContextOptions<SMSContext>opt) : base(opt)
        {

        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> departments { get; set; }
        

    }
}


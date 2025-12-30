using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UMSSDbContext : DbContext
    {
        public UMSSDbContext(DbContextOptions<UMSSDbContext> opt) : base(opt)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}

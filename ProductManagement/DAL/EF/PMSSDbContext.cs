using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class PMSSDbContext : DbContext
    {
        public PMSSDbContext(DbContextOptions<PMSSDbContext> opt) : base(opt) {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory>Catagories { get; set; }
    }
}

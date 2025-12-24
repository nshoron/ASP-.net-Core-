using CFWebApiDB.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CFWebApiDB.EF
{
    public class NmsDbContext : DbContext
    {
         public NmsDbContext (DbContextOptions<NmsDbContext> options) : base(options)
        { 
        }
        public DbSet<Catagory> Catagories { get; set; } 
        public DbSet<News> Newses { get; set; }
        } 



    }


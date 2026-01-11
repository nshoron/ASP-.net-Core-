using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repository<T> where T : class
    {
        PMSSDbContext db;
        DbSet<T> table;
        public Repository (PMSSDbContext db)
        {
            this.db = db;
            table=db.Set<T>();
        }
        public List<T> Get ()
        {
            return table.ToList();
           
        }
        public T Get(int id)
        {
            return table.Find(id);

        }
        public bool Create(T obj)
        {
            table.Add(obj);
            return db.SaveChanges()>0;

        }
        public bool Update(T obj)
        {
            return true;

        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            table.Remove(ex);
            return db.SaveChanges() > 0; 

        }
    }
}

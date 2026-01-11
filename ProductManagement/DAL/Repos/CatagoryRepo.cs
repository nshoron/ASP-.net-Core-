using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CatagoryRepo: IRepository<Catagory>,ICatagoryFeature
    {
        PMSSDbContext db;
        public CatagoryRepo(PMSSDbContext db)
        {
            this.db = db;
        }
        public bool Create(Catagory c)
        {
            db.Catagories.Add(c);
            return db.SaveChanges() > 0;
        }
        public List<Catagory> Get()
        {
            return db.Catagories.ToList();
        }
        public Catagory Get(int id)
        {
            return db.Catagories.Find(id);
        }
        public bool Update(Catagory c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex= Get(id);
            db.Catagories.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<Catagory> GetWithProduct(int id)
        {
            var cat = db.Catagories
                .Include(ct => ct.Products)
                .Where(c => c.Id == id)
                .ToList();
            return cat;
        }

      

        public Catagory FindByName(string name)
        {
            var cat = (from c in db.Catagories
                       where c.Name.Contains(name)
                       select c).SingleOrDefault();
            return cat;
          
                        
        }

        public Catagory FindByNameWithProducts(string name)
        {
            var cat = db.Catagories.Include(ct=>ct.Products)
                .SingleOrDefault(c=>c.Name.Contains(name));
            return cat;
        }

        public Catagory HighestProducts()
        {
            var cat = (from c in db.Catagories.Include(c => c.Products)
                       orderby c.Products.Count() descending
                       select c).FirstOrDefault();
            return cat;

        }

        public List<Catagory> GetWithProduct()
        {
            // Return all categories including their Products
            return db.Catagories
                .Include(ct => ct.Products)
                .ToList();
        }

        public Catagory GetWithProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}

using DAL.EF;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo
    {
        PMSSDbContext db;
        public ProductRepo (PMSSDbContext db)
        {
            this.db = db;
        }
        public bool Create (Product product)
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }
        public List<Product> Get()
        {
            var data = db.Products.ToList();
            return data;
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
            
        }
        public bool Update(Product p)
        {
            var ex = Get(p.Id);
            db.Entry(ex).CurrentValues.SetValues(p);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex= Get(id);
            db.Products.Remove(ex);
            return db.SaveChanges() > 0;
        }
    }
}

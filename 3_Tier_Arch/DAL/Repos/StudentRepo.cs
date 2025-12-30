using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        UMSSDbContext db;
        public StudentRepo(UMSSDbContext db)
        {
            this.db = db;
        }

        public bool Create(Student s)
        {
            db.Students.Add(s);
            return db.SaveChanges() > 0;
        }
        public List<Student> Get()
        {
            //var data = new List<Student>();
            //for (int i = 1; i <= 10; i++) { 
            //    data.Add(new Student() { 
            //        Id = i,
            //        Name = "S"+i
            //    });
            //}

            return db.Students.ToList();

        }
    }
}

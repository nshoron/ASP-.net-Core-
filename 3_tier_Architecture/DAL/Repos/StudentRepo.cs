using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        SMSContext db;
        public StudentRepo(SMSContext db)
        {
            this.db = db;
        }
       
    }
}

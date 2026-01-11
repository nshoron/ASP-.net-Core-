using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        PMSSDbContext db;
        public DataAccessFactory(PMSSDbContext db)
        {
        this.db = db;   
        }
        public IRepository<Catagory> CatagoryData()
        {
            return new CatagoryRepo(db);
        }
        public ICatagoryFeature CatagoryFeature()
        {
            return new CatagoryRepo(db);
        }

    }
}

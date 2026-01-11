using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CatagoryService
    {
        DataAccessFactory factory;
        public CatagoryService( DataAccessFactory factory)
        {
            this.factory = factory;
        }
    public List<CatagoryDTO> Get()
        {
            var data=factory.CatagoryData().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<CatagoryDTO>>(data);
            return ret;
            
        }
    public CatagoryDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<CatagoryDTO>(factory.CatagoryData().Get(id));
        }
    public bool Create(CatagoryDTO c)
        {
            var mapper=MapperConfig.GetMapper();
            var data = mapper.Map<Catagory>(c);
            return factory.CatagoryData().Create(data);
        }
        public bool Update(CatagoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Catagory>(c);
            return factory.CatagoryData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.CatagoryData().Delete(id);

        }
        public List<CatagoryProductDTO> GetWithProducts()
        {
            // Use CatagoryFeature which exposes methods that include related Products
            var data = factory.CatagoryFeature().GetWithProduct();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<CatagoryProductDTO>>(data);
            return ret;
        }

    }
}

using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        Repository<Product> repo;
        public ProductService(Repository<Product> repo)
        {
            this.repo = repo;
        }
    public List<ProductDTO> Get()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<ProductDTO>>(data);
        }
    public ProductDTO Get(int id)
        {
            var data=repo.Get(id);
            return MapperConfig.GetMapper().Map<ProductDTO>(data);
        }
    public bool Create (ProductDTO p)
        {
            var data=MapperConfig.GetMapper().Map<Product>(p);
            return repo.Create(data);
        }
    public bool Update(ProductDTO p)
        {
            var data = MapperConfig.GetMapper().Map<Product>(p);
            return repo.Update(data);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}

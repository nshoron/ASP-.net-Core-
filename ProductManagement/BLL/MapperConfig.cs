using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Catagory, CatagoryDTO>().ReverseMap();     
            cfg.CreateMap<Product, ProductDTO>().ReverseMap();     
            cfg.CreateMap<Catagory,CatagoryProductDTO>().ReverseMap();     
        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }

    }
}

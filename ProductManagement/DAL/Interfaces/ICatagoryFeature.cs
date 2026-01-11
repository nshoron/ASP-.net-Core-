using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICatagoryFeature
    {
        List<Catagory> GetWithProduct();
        Catagory GetWithProducts(int id);
        Catagory FindByName(string name);
        Catagory FindByNameWithProducts(string name);
        Catagory HighestProducts();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CatagoryProductDTO : CatagoryDTO
    {
        public List<ProductDTO> Products { get; set; }
        public CatagoryProductDTO() 
        {
        Products=new List<ProductDTO>();
        }

    }
}

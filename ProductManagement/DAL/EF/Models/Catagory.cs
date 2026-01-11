using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Catagory
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public virtual List<Product>Products { get; set; }
        public Catagory() 
        {
         Products = new List<Product>();
        }
    }
}

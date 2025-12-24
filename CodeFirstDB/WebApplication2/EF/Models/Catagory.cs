using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFWebApiDB.EF.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}

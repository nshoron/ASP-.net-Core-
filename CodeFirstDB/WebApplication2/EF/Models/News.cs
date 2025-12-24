using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFWebApiDB.EF.Models
{
    public class News
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Column(TypeName ="varchar")]
        public string? Tittle { get; set; }
        [ForeignKey("Cat")]
        public int c_id { get; set; }
        public DateOnly Date {  get; set; }
        public virtual Catagory? Cat { get; set; }

    }
}

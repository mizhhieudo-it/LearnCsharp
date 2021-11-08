using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai043_Migration_Scaffold_EF
{
    public class Tag
    {
        [Key]
        public int TagId {set; get;}

        //[StringLength(20)]
        //public int TagId {set; get;}
        [Column(TypeName="ntext")]
        public string Content {set; get;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai043_Migration_Scaffold_EF{
    [Table("article")]
    public class Article
    {
        [Key]
        public int ArticleId {set; get;}

        [StringLength(100)]
        public string Name {set;  get;}
        [Column(TypeName ="ntext")]
        public string Content {set;get;}

    }
    
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai043_Migration_Scaffold_EF
{
    public class ArticleTag{
        [Key]
        public int ArticleTagId {get;set;}
        public int TagId {get;set;}
        [ForeignKey("TagId")]
        public Tag tag {get;set;}
        public int ActicleId {get;set;}
        [ForeignKey("ActicleId")]
        public Article article {get;set;}
    }
}
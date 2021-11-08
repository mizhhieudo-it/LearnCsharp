using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ef
{
    /*
    Table("Table_Name")
    [KEY] -> là khóa chính 
    [Required] - not null 
    [StringLength] <-> nvarchar
    convert từ kiểu dữ liệu nguyên thủy <=> kiểu trong cơ sở dữ liệu vd [Column(TypeName ="ntext")] string <=> ntext
    */
    //[Table("Product")]
    public class Product{
        //[Key]
        public int ProductId{set ;get;}
        [Required]
        [StringLength(50)] // nvar50
        [Column("TenSP",TypeName ="ntext")]
        public string ProductName {get ;set;}
        [StringLength(50)]
        [Column(TypeName ="money")]

        public decimal Prince {get; set;}
        public int CateId{get;set;}
        [ForeignKey("CateId")] // chỉ ra cái cột là khóa ngoại
        public virtual Category Category{get;set;} //Fk -> Pk ( 1 - nhiều)
                                                    // 1 - 1
        public int? CateId2{get;set;} // phải cho có thể null vì liên kết đã lk chặt cateid 
        //[ForeignKey("CateId2")] // chỉ ra cái cột là khóa ngoại
        //[InverseProperty("Products")]
        public virtual Category Category2{get;set;}
        public void PrintInfo(){
            Console.WriteLine($"Mã ID - {ProductId} - Tên Sản Phẩm {ProductName} - Gía {Prince} - ID CATE {CateId}");
        }
    }
}
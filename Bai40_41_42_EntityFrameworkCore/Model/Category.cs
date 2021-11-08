using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef{
    [Table("Category")]
    public class Category{
        [Key]
        public int CategoryId{get ;set;}
        [StringLength(100)]
        public string Name {get ;set;}
        [Column(TypeName =("ntext"))]
        public string description {get ; set;}
        // điều hướng tập hợp :Collect Navigation 
        public virtual List<Product> Products {get;set;}
        public void PrintInfo(){
            Console.WriteLine($"Mã ID - {CategoryId} - Tên DanhMuc {Name} - Gía {description}");
        }
        public CategoryDetail categoryDetail {get;set;}
        


    }
}
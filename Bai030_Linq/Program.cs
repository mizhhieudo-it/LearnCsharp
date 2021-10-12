using System;
using System.Collections.Generic;
using Products;
using Brands;
using System.Linq;

namespace Bai030_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>() 
            {
            new Brand{ID = 1, Name = "Công ty AAA"},
            new Brand{ID = 2, Name = "Công ty BBB"},
            new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
            // Get Price Product = 400 
            // Way 1 : API LINQ 
            var LinQ_API_Price400 = products.Where(x =>{
                return x.Price == 400 ;
            }) ;
            // Way 2 : LINQ 
            var LinQ_Price400 = from x in products
                                where x.Price == 400 
                                select x ; 
            
            // 2 satisfying products
            LinQ_API_Price400.ToList().ForEach(x => {
                Console.WriteLine(x);
            });
            Console.WriteLine("======Linq======");
            LinQ_Price400.ToList().ForEach(x => {
                Console.WriteLine(x);
            });
            // 1 . Select 
            var LinQ_API_SELECT = products.Select(
              x => {
                  return new {
                      TenSP = x.Name,
                      GiaSP = x.Price
                  };
              }  
            );
            var LinQ_SELECT = from x in products
                            select new {
                                TenSP_LINQ = x.Name,
                                GiaSP_LINQ = x.Price
                            };
            LinQ_SELECT.ToList().ForEach(
                x =>{
                    Console.WriteLine(x);
                }
            );
            Console.WriteLine("===LINQ_API===");
            LinQ_API_SELECT.ToList().ForEach(
                x =>{
                    Console.WriteLine(x);
                }
            );
            // Select Many 
            // Way 1: LINQ_API
            var LinQ_API_SELECTMANY = products.SelectMany(
                x => {
                   return x.Colors ;
                }
            ).ToList();
            foreach (var item in LinQ_API_SELECTMANY)
            {
                Console.WriteLine(item);
            }
            // JOIN 
            // GET NAME PRODUCT AND BRAND 
            // LINQ_API 
            products.Join(brands,pro => pro.Brand,
                        bra => bra.ID,
                        (pro,bra)=>{
                            return new {
                                TenSP = pro.Name,
                                ThuongHieu = bra.Name
                            };
                        }).ToList().ForEach(
                            x => Console.WriteLine(x)
                        );
            Console.WriteLine("==LINQ JOIN==");
            var Linq_JOIN = from x in products
                            join y in brands 
                            on x.Brand equals y.ID
                            select new {
                                TENSP = x.Name,
                                TENTH = y.Name
                            } ; 
            Linq_JOIN.ToList().ForEach(x => Console.WriteLine(x));
            // JoinGruop : nhóm 1 phần phần tử với 1 bảng ( các sản phẩm có cùng thương thiệu)
            var joinGR = brands.GroupJoin
            (products,bra => bra.ID,
             pro => pro.Brand,
             (bra,pro)=>{
                return new {
                    TENTH = bra.Name,
                    pro
                };
             }
            ) ; 
            foreach (var item in joinGR)
            {
                Console.WriteLine("Sản Phẩm:"+item.TENTH);
                foreach(var i in item.pro){
                    Console.WriteLine(i);
                }
                
            }



            


            
            
            

            
        }
    }
}

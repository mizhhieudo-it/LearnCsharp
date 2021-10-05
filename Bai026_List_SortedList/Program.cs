using System;
using System.Collections.Generic;

namespace Bai026_List_SortedList
{
    class Product{
        public string Name {get;set;}
        public double Price {get;set;}
        public int ID{get; set;}
        public string Origin {get;set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>(){
                new Product(){
                    Name = "IphoneX" , Price = 1000 , Origin="China",ID=1
                },
                new Product(){
                    Name = "SamSung" , Price = 900 , Origin="China",ID=2
                },
                new Product(){
                    Name = "Nokia" , Price = 800 , Origin="China",ID=3
                },
                new Product(){
                    Name = "Sony" , Price = 13000 , Origin="China",ID=4
                },
                new Product(){
                    Name = "ViPhone" , Price = 1300 , Origin="VN",ID=5
                },
            };
            // VN get product made by Vn
            var sp = products.FindAll(e=>{
                return e.Price < 900;
            });
            // sắp xếp phần tử trong danh sách
            //================In List=====================
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} {item.Price}");
            }
            products.Sort(
                (p1,p2)=>{
                    //return 0 if p1 == p2 
                    // return 1 if p1 > p2 
                    // return -1 if p1 < p2 
                    if(p1.Price == p2.Price) return 0 ; // không đổi vị trí
                    if(p1.Price < p2.Price) return 1;  // 1 - 2 => 2 - 1 => gán 2 cho 1 => 1 luôn max => giảm dần
                    return -1 ;
                }
            ) ;
            Console.WriteLine("====================================");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} {item.Price}");
            }
            if(sp != null){
                foreach (var sp1 in sp)
                {
                    Console.WriteLine(sp1.Name+sp1.Origin+sp1.Price);
                }
                
            }
            // Sorted List 
            // 1 item chứa key và value
            SortedList<string,Product> productsED = new SortedList<string, Product>(); 
            // khai báo 1 đối tượng kiểu sortedlIST
            productsED["sp1"] = new Product(){Name="ip1",Price=2000,ID=5,Origin="vn"};
            var keys = productsED.Keys ; // => return 1 mảng keys
            var value =  productsED.Values ; // RETURN1 MẢNG VALUES 
            foreach (var item in keys)
            {
             Console.WriteLine("ket qua:"+productsED[item].Name);   
            }
            // cách 2 : 
            foreach (KeyValuePair<string,Product> item in productsED)
            {
                var key = item.Key ; // trả về key của sp 
                var values = item.Value ; // trả về value 
                Console.WriteLine(key+values.Name);
                
            }
            //productsED.Remove("sp1"); // xóa pt key sp 1 
            //productsED.RemoveAt("xóa phần tử index = 0 ")
            List<int> ds1 = new List<int>(){3,4,6};
            ds1.Add(1);
            ds1.Add(2);
            ds1.Insert(0,3); // thêm 1 phần tử tại 1 vị trị 
            ds1.RemoveAt(2) ; // xóa đi 1 phần tử trong vị trí 
            ds1.Remove(3) ; // chuyền vào giá trị muốn xóa đầu tiền 
            ds1.AddRange(new int[]{3,4,5}); // thêm 1 mảng vào ds 
            //==========tìm kiếm trong list======================
            var x = ds1.Find(e => {
                return e < -1;
            });
            // truyền vào 1 delegate trả về true là thoải mãn ( thực thi) , flase là ko thỏa mãn return 0 <=> false . lấy kết quả đầu tiên
            //FindAll()  => lấy tất cả
            Console.WriteLine("resl"+x);
            foreach (var item in ds1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(ds1.Count);
        }
    }
}

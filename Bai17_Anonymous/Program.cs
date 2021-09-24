using System;
using System.Collections.Generic;
using System.Linq;
namespace Bai17_Anonymous
{
    class Program
    {
        //Anonymous - kiểu dữ liệu vô danh 
        // Object - thuộc tính - chỉ đọc 
        // new {thuoc tinh = giatri,thuoctinh2 = giatri2 }
        // Dynamic - kiểu dữ liệu động : trong thời điêm biên dịch thì sẽ k sảy ra trong biên dịch mà sẽ sảy ra trong thực thi 
        class sv {
            public string name {get;set;}
            public int namsinh {get ;set;}
            public void Hello() => Console.WriteLine("hi");
        }
        static void PrintInfo(dynamic obj){
            obj.name = "ưeqweqweqw" ;  // ko cần biết obj có trường name hay k 
            obj.Hello();
        }
        static void Main(string[] args)
        {
            List<sv> a = new List<sv>(){
                new sv(){name="nam",namsinh=2000}, 
                new sv(){name="dan",namsinh=2002}, 
            };
            var ketqua = from sv in a 
                         where sv.namsinh <= 2000 
                         select new {
                             ten = sv.name ,
                             tuoi = sv.namsinh
                         };
            foreach (var x in ketqua){
                Console.WriteLine(x.ten);
            }
            sv b = new sv();
            PrintInfo(b);

        }
    }
}

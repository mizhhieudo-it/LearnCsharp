using System;
using MyNameSpace;
using a = MyNameSpace.ABC; // viết tắt namespace 
// sử dụng phương thức tĩnh
using static System.Console;
//namespace : gộp nhiều class 
namespace Bai15_Namespace_and_parital
{
    // có thể tạo ra các ns con khac 
    class Program
    {
        static void Main(string[] args)
        {
           a.Class1.XinChao();
           WriteLine("Hello");
           Sanpham.Product product = new Sanpham.Product();
           product.name = "Ipad" ; 
           product.price = 1000 ;
           product.description = "Đây là ipad";
           product.manufatory = new Sanpham.Product.Manufatory();
           product.manufatory.name = "Apple";
           product.manufatory.addr = "Cali";
           WriteLine(product.manufatory.name);
        }
    }
}

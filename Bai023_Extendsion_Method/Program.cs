using System;
using System.Linq; // mở rộng cho đối tượng mảng
using MyLib;

namespace Bai023_Extendsion_Method
{
    static class Abc{
        public static void Print(this string s,ConsoleColor color) // Mở rộng Phương Thức Chuỗi là Print 
        {
            Console.ForegroundColor = color ; 
            Console.WriteLine(s);
        }
    }
    //exenstion method
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor =ConsoleColor.DarkGreen;
            int a ;
            NhapXuatDuLieu.Xuat("MOI BAN NHAP VAO 1 SO");       
            int kq = NhapXuatDuLieu.Nhap("a")    ;
        }
    }
}

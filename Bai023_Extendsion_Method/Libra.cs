using  System;
namespace MyLib{

    public static class NhapXuatDuLieu {
        
        public static void Xuat(dynamic a) => Console.WriteLine(a); 
        public static dynamic Nhap(dynamic a) => Convert.ToInt32(Console.ReadLine(a));
        public static int BinhPhuong(this int x)=> x*x ; 
        public static double CanBacHai(this double x)=> Math.Sqrt(x) ; 
    }
}
using System;

namespace Bai5_if_else
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            if(dieu_kien_logic)
                long_lenh;
            if( dieu_kien_logic){
                ... 
            }
            else if( dieu_kien_1){
                ...
            }
            else if( dieu_kien_2){
                ...
            }
            else {
                .. khối lệnh esle
            }
            */
            // int a ; 
            // Console.WriteLine("Nhập số nguyên a:");
            // a = int.Parse(Console.ReadLine());
            // if(a% 2==0){
            //     Console.WriteLine("Result");
            //     Console.WriteLine("Số a là chẵn");
            // }
            // else{
            //     Console.WriteLine("Số a là số lẻ");
            // }
            // Console.WriteLine("Hello World!");
            // [8 - 10 ] : 1 st 
            // [6.5 - 8] : 2 st 
            // [5.0 - 6.5] : 3st
            // [0 -5.0]: 4st
            float dtb ;
            Console.WriteLine("Hay nhap diem trung binh"); 
            dtb = 3;
            // dtb = float.Parse(Console.ReadLine());
            if(dtb <5.0){
                Console.WriteLine("Hoc Luc Yeu");
            }
            else if(dtb < 6.5){
                Console.WriteLine("Hoc Luc TB");
            }
            else if(dtb < 8.5){
                Console.WriteLine("Hoc Luc Kha");
            }
            else if(dtb < 10.0){
                Console.WriteLine("Hoc Luc Kha");
            }
            else{
                Console.WriteLine("Nhap sai so diem");
            }
            // toan tu 3 ngoi
            float a,b ;
            Console.WriteLine("Nhap a");
            a = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhap b");
            b = float.Parse(Console.ReadLine());
            // (dieu_kien_kiem_tra) ? bieuthuc1 : bieuthuc2;
            float max = (a>b) ? a: b;
            Console.WriteLine($"Max = {max}");

        }
    }
}

using System;

namespace Bài2_Biến_Hằng_số_Kiểu_Dữ_Liệu_và_nhập_Xuất_dữ_liệu
{
    class Program
    {
        static void Main(string[] args)
        { 
            /*
            Kieu_du_lieu Ten_Bien:
            Ten_Bien :
            - a..z , A..z
            - 0...9 
            - Khong bat dau bang so
            */
            string studentName ="ANV"; 
            int studentAge;
            //Khai báo kiểu dữ liệu - DataType
            int seconds = 60 ; // số nguyên 
            double so_pi = 3.14 ;// kiểu dữ liệu số thực 
            bool isZero = true ; // kiểu logic 
            char ChooseAction = 'S'; // kiểu kí tự 
            string msgResult = "Kết quả giải:"; // kiểu chuỗi 
            float typefloat = 12.12f ; // kiểu float phải có chữ f đằng sau hoặc ép kiểu 12.12 <=> (float)12.12 
            object d = studentName;
            // Khai báo trên 1 dồng 
            int a =1 , b = 2 ,c = 3 ; 
            //thiết lập màu chữ 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            double pii =3.14 ;
            Console.WriteLine(pii);
            Console.Title ="Vi du su dung console"; 
            Console.Beep();
            Console.WriteLine("Xin Chao toi la C sharp");
            //reset Color 
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Di Cung Toi Ca Su Nghiep nhe H");
           
            // Xuat Ra giu cho 
            Console.WriteLine("Xin Chào {0} tôi là {1}","H","C sharp");
            // Convert Chuỗi : ban đầu tất cả dữ liệu người dùng nhập vào có dạng kiểu float 
            string input ; 
            Console.WriteLine("How old're name ");
            input = Console.ReadLine(); 
            // input lúc nào đang ở dạng chuỗi cần đc convert về dạng số 
            var old = int.Parse(input);
            Console.WriteLine("Year ! Come here ");
             Console.ReadKey();
            


        }
    }
}

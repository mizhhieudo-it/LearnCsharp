using System;

namespace Bai3_OperatorInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Operator + - x % 
            // bình phương mũ căn bặc 2 tính trước , nhân chia trước cộng trừ sau , bằng cấp tính từ trái qua phải
            // phép toán gán = += ; -= /= %=
            int x = 10 ; 
            int z = 2 * x++ ; 
            // z = (2*x) ++
            int z1 = 2 * ++x; 
            // z = 2 *(x <=> 10 + 1)
            float a = 5 ;
            int b = 4 ; 
            Console.WriteLine("a + b = {0}",a +b )  ;
            Console.WriteLine("a - b = {0}",a - b )  ;
            Console.WriteLine("a * b = {0}",a *b )  ;
            Console.WriteLine("a / b = {0}",a /b )  ;
            Console.WriteLine("a % b = {0}",a % b )  ;
            float kq = a + b * 2 ;
            Console.WriteLine(kq);
        }
    }
}

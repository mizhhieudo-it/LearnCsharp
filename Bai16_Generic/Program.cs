using System;

namespace Bai16_Generic
{
    class Program
    {
        // nếu ko có ref thì hàm kết thúc các value cũng bị xóa theo => ko đổi đc 
        static void Swap(ref int x,ref int y){
            int t ; 
            t = x ; 
            x = y ; 
            y = t ; 
        }
        static void Swap(ref float x,ref float y){
            float t ; 
            t = x ; 
            x = y ; 
            y = t ; 
        }
        // giải thuật giống nhau trên kiểu dữ liệu khác nhau
        static void Swap<T>(ref T x,ref T y){
            T t ; 
            t = x ; 
            x = y ; 
            y = t ; 
        }
        static void Main(string[] args)
        {
            float a = 1  , b = 2; 
            Console.WriteLine($"a ={a},b={b}");
            Swap(ref a,ref b);
            Console.WriteLine($"a ={a},b={b}");
            string x = "ABV" ; 
            string y = "ZXC";
            Console.WriteLine($"x ={x},y={x}");
            Swap<string>(ref x,ref y); // chỉ rõ kiểu phương thức
            Console.WriteLine($"x ={x},y={x}");
            Swap(ref x,ref y);
            Console.WriteLine($"x ={x},y={x}");
            Product.product<string> prox = new Product.product<string>();
            prox.SetID("33");
            Console.WriteLine(prox.ID);
            // VIDU : LIST LÀ KIỂU LIST
            

        }
    }
}

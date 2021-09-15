using System;

namespace Bai09_Methods
{
    class Program
    {
        /*
        Phạm_vi_truy_Cap kiểu_giá_Trị_trả_Về tên_phương_thức
        {
            // các câu lệnh trong phương thức
        }
        */
        public static int tich(int a,int b){
            return a*b ;
        }
        //  tham trị 
        static void binhphuong(ref int x){
            // thêm ref để giá trị của thay đổi sau khi ra khỏi hàm 
            // thêm out <=> tương tự nhưng out thì ko cần khởi tạo sẵn
            x = x * x ; 
            Console.WriteLine(x);
        }
        static void Main(string[] args)
        {
            Bai09_Methods.Program.xinchao();
            int kq = tich(3,4);
            int result = CS009.Tinhtoan.sum(4,5);
            Console.WriteLine($"ket qua ={kq}");
            Console.WriteLine($"ket qua ={result}");
            float a = 12.12f ; 
            float b = 10.0f ;
            Console.WriteLine($"ket qua ={CS009.Tinhtoan.sum(a,b)}");
            Hello("Hieu","Do");
            // truyền tham số với tên
            Hello(ho:"Nguyen",ten:"B");
            //Tham chiếu 
            int z = 5 ;
          //  binhphuong(z);
            Console.WriteLine(z) ;// => giá trị của a ko thay đổi
            binhphuong(ref z);
            Console.WriteLine(z) ;

        }
        static void xinchao()
        {
            // ...
            /*
            static : gọi bất kì đâu trong lớp
            cách gọi // namespace.lớp.methods
            cùng lớp thì bỏ đí namesapc.lớp 

            */
            Console.WriteLine("+++++++++++");
        }
        // truyền tham số với tên 
        // tham số mặc định
        static void Hello(string ten,string ho="Nguyen"){
            string fullname ; 
            fullname = ho + " " + ten ; 
            Console.WriteLine($"xin chào {fullname}");
        }
    }
}

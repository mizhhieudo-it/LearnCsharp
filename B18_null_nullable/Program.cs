using System;

namespace B18_null_nullable
{
    class Abc{
        public void XinChao() => Console.WriteLine("it's oke");
    }
    class Program
    {
        static void Main(string[] args)
        {// null,bullable: từ khóa null sẽ gán cho tham chiếu , nếu bắt buộc cần tham trị mà gán null ta cho int? trước trường 
            Abc a = new Abc();
            if(a !=null){
                a.XinChao();
            }
            a?.XinChao(); // nếu a != thực hiện xin chào
            // khai báo kiểu tham trị mà nhận null 
            int? age ; 
            age = null ; 
            age = 100 ;
            if(age.HasValue){ //hasvalue nghĩa là = true nếu có đc gán và flase nếu ko đc gán 
                int _age = age.Value;
                Console.WriteLine(_age);
            }
            Console.WriteLine("Hello World!");
        }
    }
}

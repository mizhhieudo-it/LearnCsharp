using System;

namespace Bai19_Virtual_Method
{
    class Program
    {
        //virtaul method 
        // ábstract : 
        // -khi đã khai báo abstract thì nghĩa là ko thể khởi tại đối đượng mà chỉ làm base cho lớp con định nghĩa lại
        abstract class Product
        {
            protected double Price {get; set ;}
            // virtual là muốn cho lớp con nạp lại
            public virtual void ProductInfo(){
                Console.WriteLine($"Gia san pham{Price}");
            }
            // khai báo hàm abstract: ko định nghĩa gì cả mà cho con địng nghĩa
            public abstract void  GetInfo();
            public void Test() => ProductInfo() ;

        }
        class Iphone : Product {
            public Iphone() => Price = 500 ;
            // overide : nộp chồng phương thức : định nghĩa lại phương thức của lớp cơ sở
            public override void ProductInfo(){
                Console.WriteLine($"OKE");
                base.ProductInfo(); // muốn gọi lại product info từ lớp cơ sở 
            }
            public override void GetInfo(){
                Console.WriteLine("GET INFO SUCCESS");
            }
            
        }
        //interface : triển khai từ lớp con 
        interface IHinhHoc
        {
            public double tinhcv();
            public double tinhs();
        }
        class HinhCN : IHinhHoc
        {
            public double a {get;set;}
            public double b {get ;set;}
            public HinhCN(double _a,double _b){
                a= _a ; 
                b= _b ;
            }
             public double tinhcv()
            {
                return 2 * (a+b);
            }

            public double tinhs()
            {
                return a*b;
            }
        }
        class HinhTron:IHinhHoc
        {
            public double r {get ;set;}
            public HinhTron(double _r) => r = _r ;

            public double tinhcv()
            {
                return 2*r * Math.PI ;
            }

            public double tinhs()
            {
                return r*r;
            }
        }
        static void Main(string[] args)
        {
            // Iphone ip13 = new Iphone();
            // ip13.Test();
            Iphone IPX =new Iphone();
            IPX.GetInfo();
            HinhCN X = new HinhCN(4,5);
            Console.WriteLine($"S={X.tinhs()} AND P={X.tinhcv()}");
            IHinhHoc ht = new HinhTron(4);
            Console.WriteLine($"S={ht.tinhs()} AND P={ht.tinhcv()}");
        }
    }
}

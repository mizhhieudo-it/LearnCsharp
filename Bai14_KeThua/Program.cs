using System;

namespace Bai14_KeThua
{
    // trong trường hợp 1 lớp ko muốn kế thừa từ 1 lớp nào đó ta cho từ khóa sealed
    class Animal{
        public Animal(){
            Console.WriteLine("Khoi tao lop Animal");
            // gọi khởi tạo lớp animal trước , cơ sở sau
        }
        public Animal(string abc){
            Console.WriteLine($"Khoi tao lop Animal (2)-{abc}");
            // gọi khởi tạo lớp animal trước , cơ sở sau
        }
        public int Legs {get ;set;}
        public float Weight {get;set;}
        public void showLegs()
        {
            Console.WriteLine($"Leg:{Legs}");
        }
        // lưu ý : protect ko truy cập đc từ bên ngoài 
        // bên trong thì lớp kế thừa
    }
    class Cat : Animal {
        // kế thừa lại hàm tạo có tham số của lớp cha : base
        // truyền vào lớp cha bằng cách sử dụng lại biến s
        public Cat(string s):base(s) 
        {
            Legs = 4 ; 
            Food = "Mouse";
            Console.WriteLine("Khoi tao lop Cat");

        }
        public string Food ; 
        public void Eat ()
        {
            Console.WriteLine(Food);
        }
        
        // định nghĩa lại lớp cha ==> them tu khoa new
        public new void showLegs()
        {
            Console.WriteLine($"Loai meo co so chan:{Legs}");
        }
        public void ShowInfo(){
            showLegs(); // show legs lớp kế thừa 
            base.showLegs();// lớp cha ;
        }
    }
    class A{

    }
    class B : A {

    }
    class C : B {
        // A -> B -> C
    }
    class Program
    {
        /*
        Tinh Ke Thua 
        A,B 
        B ke thua A
        A - cơ sở , lớp cha 
        B - kế thừa , con 
        class B : A
        {
            khai riêng của b 
        }
        Animal
        - Legs 
        - Weight
        - ShowLegs()
        Cat:Animal{

        }
        */
        static void Main(string[] args)
        {
            // Cat c = new Cat("ABC - ZZZ");
            // // c.showLegs();
            // // c.Eat();
            // c.ShowInfo();
            A  a ; 
            B b ; 
            C c ; 
            a = new B();
            b = new C();
        }
    }
}

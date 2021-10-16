using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
//using Microsoft.Extensions.DependencyInjection;

namespace Bai033_DependencyInjection
{
    // Complie Time : là lúc viết code 
    // run code : Là lúc code chạy
    // Inversion of Control (IOC):ĐẢO NGƯỢC QUYỀN ĐIỀU KHIỂN 
    // Dependency injection 
    // Dependency  : Lớp B Phục thuộc vào Lớp A => Lớp A là depency của Lớp A
    //================================ Description Dependency===================
    // class classA{
    //     public void ActionA() => Console.WriteLine("Action in ClassA");
    // }
    // class classB{
    //     public void ActionB(){
    //         var a = new classA();
    //         a.ActionA(); // => khi run thì class B dựa vào class A để hoàn thành nghiệm vụ =>  class A dependency của class B
    //     } 
    // }
    //==============Inversion of Control (IOC)==================

    //================Inverse Dependency(Đảo Ngược Sự Phụ Thuộc)=====================
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC() => Console.WriteLine("Action in ClassC1");
    }
    class ClassB2 : IClassB
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classc, string mgs)
        {
            c_dependency = classc;
            message = mgs;
            Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            Console.WriteLine(message);
            c_dependency.ActionC();
        }
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }


    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    //     {
    //         IClassD D_dependency { get; set; }
    //     public classX(IClassD _classD)
    //     {
    //         D_dependency = _classD;
    //         Console.WriteLine("Class X is Created");
    //     }
    //     public void ActionX()
    //     {
    //         Console.WriteLine("Action is ClassX");
    //     }
    // }
    //======================Dependency Injection===================
    /*  quan trọng là phải đưa đc dependency từ bên ngoài ( có khả năng injection)
    */
    class Horn
    {
        int level = 0;
        public Horn(int level)
        {
            this.level = level;
        }

        public void Beep() => Console.WriteLine("Beep Bepp........");
    }
    class Car
    {
        // nới lỏng sự phụ thuộc 
        Horn horn;
        public Car(Horn _horn) => horn = _horn;
        public void Beep()
        {
            //Horn horn = new Horn(3); // để linh hoạt thì các dependency ko đc tạo trong các lớp
            horn.Beep(); // Horn thay đổi => car cũng thay đổi
        }

    }
    class Program
    {
        public static IClassB CreateB2(IServiceProvider provider)
        {

            var b2 = new ClassB2(
                provider.GetService<IClassC>(), // LẤY DỊCH VỤ ICLASSC
                "Thực hiện trong class B2"
            );
            return b2;

        }
        public class MyServiceOptions
        {
            public string data1 { get; set; }
            public int data2 { set; get; }
        }
        public class MyService
        {
            public string data1 { get; set; }
            public int data2 { get; set; }

            // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
            public MyService(IOptions<MyServiceOptions> options)
            {
                // Đọc được MyServiceOptions từ IOptions
                MyServiceOptions opts = options.Value;
                data1 = opts.data1;
                data2 = opts.data2;
            }
            public void PrintData() => Console.WriteLine($"{data1} - {data2}");
        }
        static void Main(string[] args)
        {
            // ClassC objectC = new ClassC();
            // ClassB objectB = new ClassB(objectC);
            // ClassA objectA = new ClassA(objectB);
            //objectA.ActionA();
            // ==== cách làm thủ công
            // IClassE objectE = new ClassE();
            // IClassD objectD1 = new classD1(objectE);
            // classX objectX = new classX(objectD1);
            // objectX.ActionX();
            Horn horn = new Horn(3);
            Car car1 = new Car(horn);
            car1.Beep();
            // thông thường mình sẽ ko sử dụng toán tử new mà sử dụng DI CONTAINER 
            // - Dang Ky cac dich vu (lop)
            // - ServiceProvider -> Get Service (lấy ra các dịch vụ) sẽ tự động tạo ra và gán vào 
            // thời gian tồng tại
            // Singletion => tạo ra duy nhất 1 phiên bản thực thi đển hết vòng đời 
            // Transient => Mỗi khi đc yêu cầu lại tạo ra 1 phiên bản mới
            // Scoped => trong mỗi phạm vi của lớp Provider thì có 1 phiên bản của dịch vụ đó
            var services = new ServiceCollection(); // đổi tượng của lớp DI 
                                                    // Dang ki cac du vu .......
                                                    //  service.AddSingleton<IClassD, classD>();
                                                    // Tạo ra 1 lớp để đăng kí dịch vụ 
                                                    // var provider = service.BuildServiceProvider();
                                                    // Interface thì sẽ triển khai từ class D và classD1
                                                    // provider.GetService<TenService >:
                                                    // tạo ra kiểu singleton (InterFace,lớp cần triển khai)

            //var svIclassD = provider.GetService<IClassD>(); // lấy ra dịch vụ kiểu iterface class D
            // for (int i = 0; i < 5; i++)
            // {
            //     IClassD d = provider.GetService<IClassD>();
            //     Console.WriteLine(d.GetHashCode());
            // }
            //============
            //services.AddSingleton<IClassC, ClassC1>();
            //services.AddTransient<IClassC, ClassC1>();
            services.AddScoped<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
                // chung 1 Ma hashcode 
            }
            using (var scope = provider.CreateScope())
            {
                var provider1 = scope.ServiceProvider;
                for (int i = 0; i < 5; i++)
                {
                    var service = provider1.GetService<IClassC>();
                    Console.WriteLine(service.GetHashCode());
                    // chung 1 Ma hashcode 
                }
            }
            // ================== Tự động tạo ra dependency , tự động inject
            // class A 
            // IclasC  => classC1 / class C
            // IclassB => classB / Class B1
            var services1 = new ServiceCollection(); // đổi tượng của lớp DI 
            services1.AddSingleton<ClassA, ClassA>();
            // services1.AddSingleton<IClassB, ClassB2>(
            //     provider =>
            //     {
            //         var b2 = new ClassB2(
            //             provider.GetService<IClassC>(), // LẤY DỊCH VỤ ICLASSC
            //             "Thực hiện trong class B2"
            //         );
            //         return b2;
            //     }
            // );// có thể thay bằng factory / vd : 
            services1.AddSingleton<IClassB>(CreateB2);
            services1.AddSingleton<IClassC, ClassC1>();
            //services1.AddSingleton<string, string>();
            var provider2 = services1.BuildServiceProvider();
            ClassA a = provider2.GetService<ClassA>();
            a.ActionA();
            //================dang ki dịch vụ vào Service Collection
            var service2 = new ServiceCollection();
            service2.AddSingleton<MyService>();
            service2.Configure<MyServiceOptions>(
                (option) =>
                {
                    option.data1 = "Chao xin";
                    option.data2 = 321;
                }
                );
            var provider3 = service2.BuildServiceProvider();
            var myService = provider3.GetService<MyService>();
            myService.PrintData();
            // sử dụng biến file configs 
            var configBuilder12 = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                       .AddJsonFile("configs.json");                  // nạp config định dạng JSON
            var configurationroot = configBuilder12.Build();                            // Tạo configurationroot
            var cf1 = configurationroot.GetSection("section1").GetSection("key1").Value; // Test
            var cf2 = configurationroot.GetSection("section1").GetSection("key2").Value; // 789
            Console.WriteLine(cf1);
        }
    }
}

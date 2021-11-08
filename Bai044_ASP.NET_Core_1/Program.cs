using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bai044_ASP.NET_Core_1
{
    public class Program
    {
        /*
         step build app 
         Host (Ihost) object : 
            -  DI : IServiceProvider:lấy ra dịch vụ (ServiveCollection): đăng kí dịch vụ
            - Logging (ILoggging)
            - Configuration : cấu hình ứng dụng
            - IHostedService : =>StartAnsyn : => khởi chạy máy chủ HTTP Sever (Kestrel Http)
            1) tạo ra host từ iHostbuilder 
            dùng iHostBuilder cấu hình hfinh và dịch vụ ( Bằng cách sử dụng ConfigureWebHostDefaults )
            2)tạo Ihostbuilder.Build() => tạo ra Host(iHOST)
            3)chạy HOST.RUN();
            // nhận đc request => thì đoạn code nào sử lý (PineLine) (1 cấu tạo bởi midleware)
            Request trả về Respon

        */
        public static void Main(string[] args){
            Console.WriteLine("start app");
            IHostBuilder builder = Host.CreateDefaultBuilder(args); // nhậm mảng các chuỗi thiết lập truyền từ args 
            // cấu hình mặc định web
            builder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder)=>{
                // đăng kí sử dụng 
                // tùy biến thêm về host 
                // xây dựng pipeline 
                webBuilder.UseStartup<MyStartup>();
                // đổi nơi sử dụng tài nguyên 
               // webBuilder.UseWebRoot("PublicData");
            });
            IHost host = builder.Build();
            host.Run();
        }
        // public static void Main(string[] args)
        // {
        //     // xac nhan chung chi ssl
        //     //dotnet dev-certs https --clear
        //     // tu cap nhat 
        //     // dotnet watch run
        //     CreateHostBuilder(args).Build().Run();
        // }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
    }
}

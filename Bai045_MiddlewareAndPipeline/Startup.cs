using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bai045_MiddlewareAndPipeline
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SecondMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMiddleware<FMidFMiddleware>();
            app.UseMiddleware<SecondMiddleware>();
            app.UseRouting(); // EndpointRouting
            // sử dụng Endpont 
            app.UseEndpoints((Endpoint) =>
            {
                //E1
                Endpoint.MapGet("/about.html", async (contexnt) =>
                {
                    contexnt.Response.WriteAsync("trang about.html");
                });
                //E2
                Endpoint.MapGet("/sanpham.html", async (contexnt) =>
                {
                    contexnt.Response.WriteAsync("trang sp.html");
                });
                Endpoint.MapGet("/trangchu", async (contexnt) =>
                {
                    contexnt.Response.WriteAsync("trang chu.html");
                });
                app.Map("/admin", (app1) =>
                {
                    // tao nhanh con 
                    app1.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("trang admin");
                    });
                });
            });
            //app.UseMiddleware<FMidFMiddleware>();
            // app.UseFMiddleWareMethod();
            // trien khai tu giao dien IMiDware
            //terminate Middlewate m1 : không chuyển đếnh các middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Xin Chao ASP.NET core");
            });
        }
    }
}
/*
- staticfile 
- fri 
- sen
- enpoint
-m1


*/
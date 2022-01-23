using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace B45_2_Middleware_and_pipeline
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
            // sử dụng fristMiddleWare()
            // app.UseMiddleware<FirstMiddleWare>();
            app.UseFirstMiddleware(); // <=>  app.UseMiddleware<FirstMiddleWare>();
            app.UseSecondMiddleware();
            // app.UseMiddleware<SecondMiddleware>();
            //Terminate middleware M1;
            app.UseRouting(); // enption route middleware - dieu huowng theo handle  ( ddieemr re nhanh) // 
            app.UseEndpoints((Endpoint)=>{
                Endpoint.MapGet("/about.html",async (context)=>{
                   await context.Response.WriteAsync("ve chung toi");
                });
                Endpoint.MapGet("/home.html",async (context)=>{
                   await context.Response.WriteAsync("trang chu");
                });
            });
            // re nhanh - di ra first,sencond , va ko bi chan boi enpoint thi se re nhanh vao admin
            app.Map("/Admin",(app1)=>{
                app.Run(async (context) => {
                await context.Response.WriteAsync("trang admin");
            }); 
            });
            app.Run(async (context) => {
                await context.Response.WriteAsync("xin chào asp net core");
            }); 
            
        }
    }
}
/*
HttpContext
pipeline : FirstMiddleware - SecondMiddleWare - M1
*/
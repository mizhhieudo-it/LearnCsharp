using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Bai046_TichHopWebPack_ReadHttpRequest_Cookie_Json
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var menu = HtmlHelper.MenuTop(
                        new object[]{
                            new {
                                url = "/abc",
                                label = "menu abc"
                            },
                            new {
                                url = "/abc",
                                label = "menu xyz"
                            }
                        }, context.Request
                    );
                    var html = HtmlHelper.HtmlDocument("XinChào", menu + HtmlHelper.HtmlTrangchu());

                    await context.Response.WriteAsync(html);
                });
                endpoints.MapGet("/RequestInfo", async context =>
                {
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                    var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div", "container");
                    var html = HtmlHelper.HtmlDocument("Thông tin của request", menu + info);

                    await context.Response.WriteAsync(html);
                    await context.Response.WriteAsync("Request Info");
                });
                endpoints.MapGet("/Encoding", async context =>
                {
                    await context.Response.WriteAsync("Encoding!");
                });
                endpoints.MapGet("/Json", async context =>
                {
                    var p = new
                    {
                        TenSP = "DongHoABC",
                        Gia = 5000000,
                        NgaySX = new DateTime(2000, 12, 21)
                    };
                    context.Response.ContentType = "application/json";
                    var json = JsonConvert.SerializeObject(p);
                    await context.Response.WriteAsync(json);
                });
                endpoints.MapGet("/Cookie/{*action}", async context =>
                {
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                    var action = context.GetRouteValue("action") ?? "read"; // nếu có thì gán bằng action , còn ko gán bằng null 
                    var message = "";
                    if (action.ToString() == "write")
                    {
                        var option = new CookieOptions
                        {
                            Path = "/",
                            Expires = DateTime.Now.AddDays(1)
                        };
                        context.Response.Cookies.Append("masanpham", "123123", option);
                        message = "<h1>cookie đc ghi</h1>";

                    }
                    else
                    {
                        var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                        message = string.Join("", listcokie).HtmlTag("ul");

                    }
                    var hd = "<a href=\"Cookie/read\">Đọc Cookie</a>" + "<br/>" + " <a href=\"Cookie/write\">Ghi Cookie</a><br/>";

                    var html = HtmlHelper.HtmlDocument("Cookie :" + action, menu + message + hd);
                    await context.Response.WriteAsync(html);
                });
                // endpoints.MapGet("/Form", async context =>
                // {
                //     var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                //     var formhtml = RequestProcess.Processform(context.Request);
                //     var html = HtmlHelper.HtmlDocument("TEST SUBMIT FORM HTML", menu + formhtml);

                //     await context.Response.WriteAsync(html);
                // });
                endpoints.MapMethods("/Form", new string[] { "POST", "GET" }, async context =>
                {

                    var method = context.Request.Method;
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                    var formhtml = RequestProcess.FormProcess(context.Request);
                    var html = HtmlHelper.HtmlDocument("TEST SUBMIT FORM HTML", menu + formhtml);
                    await context.Response.WriteAsync(html);

                });
            });
        }
    }
}

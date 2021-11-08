using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class MyStartup{
    public void ConfigureServices(IServiceCollection service ){
        // add Singletion

    }
    // dùng để xây dựng pipeLine ( chuỗi MiddleWare)
    public void Configure(IApplicationBuilder app,IWebHostEnvironment env )
    {
        app.UseStaticFiles();// cho phép sử dụng file trong wwwroot // request đi qua middleware này thì nó return content và ko đc đi tiếp
        //Middleware : điều hướng url 
        app.UseRouting(); // đưa vào 1 điểm cuối ( định nghĩa useendpoit)
        app.UseEndpoints(endpoints=>{
            // map get đưa vào 1 điểm tải url , và 1 delegate để sử lý nó 
            endpoints.MapGet("/",async (context)=>{
                 string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
    ";
                await context.Response.WriteAsync(html);
                
            });
            endpoints.MapGet("/about.html",async (context)=>{
                await context.Response.WriteAsync("Trang about");
            });
            endpoints.MapGet("/contact",async (context)=>{
                await context.Response.WriteAsync("LienHe");
            });
        });
         // tạo Cmd Middleware
        app.Map("/abc",app1 => {
            app1.Run
            (
                async (HttpContext context)=>{
               await context.Response.WriteAsync("Xin Chào đây là Map");
            });
        });
        // // tạo Cmd Middleware
        // app.Run(
        //     async (HttpContext context)=>{
        //        await context.Response.WriteAsync("Xin Chào đây là MyStarup");
        // }
        // );
        app.UseStatusCodePages(); // trả về trang 404 nếu ko đc url ko đc pipe nào sử lý
        
        
        
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SecondMiddleware : IMiddleware
{
    /*
    Url : "/xx.html"
    - khong goi duoc middle phia sau
    - ban ko dc truy cap
    - Second Middleware : ban ko dc truy cap 
    url : =! : ""xxx.html"
    - Second Middleware : ban duoc truy cap


    */
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if(context.Request.Path == "/xxx.html")
        {
            context.Response.Headers.Add("SecondMiddlewware","Ban khong duoc truy cap");
            var datafromFirstMiddleware = context.Items["dataFMiddleware"]; // dùng dữ liệu đã khai báo ở middle ware frist
            if(datafromFirstMiddleware != null){
            await context.Response.WriteAsync((string)datafromFirstMiddleware);

            }
            await context.Response.WriteAsync("ban ko dc truy cap");
        }
        else{
            var datafromFirstMiddleware = context.Items["dataFMiddleware"]; // dùng dữ liệu đã khai báo ở middle ware frist
            if(datafromFirstMiddleware != null){
            await context.Response.WriteAsync((string)datafromFirstMiddleware);

            }
            context.Response.Headers.Add("SecondMiddlewware","Ban duoc truy cap");
            await next(context);

        }
    }
}
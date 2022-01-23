// cách thứ 2 định nghĩa 1 middle ware - triển khai từ interface IMiddleware 

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SecondMiddleware : IMiddleware
{
    /**
     NHIEM VU CUA MIDDLE WARE 
    nếu đúng Url : "/xxx.html"
     - không gọi midlleware phía sau 
     - trả về 1 respon bạn ko được truy cập 
     - thiết lập header là : - SencondMiddleware : Bạn không được truy cập
    nếu sai thì 
     - header : - secondMiddleware : Bạn được truy cập 
     - chuyển httpCOntext cho MiddleWare phía sau xử lý 
    */
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if(context.Request.Path == "/xxx.html"){
            context.Response.Headers.Add("SencondMiddleWare","you can't access");
            var dataFromFirstMiddleware = context.Items["DataFirstMIddleWare"]; 
            if(dataFromFirstMiddleware != null){
                await context.Response.WriteAsync(dataFromFirstMiddleware.ToString());
            }
            await context.Response.WriteAsync("Bạn không được phép truy cập vào trang này");
        }else{
            context.Response.Headers.Add("SencondMiddleWare","you can access");
            await next(context);
        }
        
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class FirstMiddleWare{
    //RequestDelegate ~ async (HttpContext context)=>{}
    private readonly RequestDelegate _next ;
    public FirstMiddleWare(RequestDelegate next){
        _next = next ;
    }
    // HttpContext di qua Middleware trong pipeline 
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine(context.Request.Path); // làm nhiệm vụ in ra request ; 
        // gửi dữ liệu giữa các middleware < key , value > ( đọc qua key)
        context.Items.Add("DataFirstMIddleWare",$"<p> Url:{context.Request.Path} </p>");
        // context.Response.WriteAsync("Url truy van"+context.Request.Path);
        await _next(context); // chuyển thằng này cho thằng sau
    }
}
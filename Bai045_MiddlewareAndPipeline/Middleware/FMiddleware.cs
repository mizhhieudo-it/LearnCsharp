using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class FMidFMiddleware
{
    private readonly RequestDelegate _next ; 
    // RequestDelegate ~ async HttpContext = > {}
    public FMidFMiddleware(RequestDelegate next){
        _next = next;
    }
    // HttpContext ddi qua Middleware trong pipeline
    public async Task InvokeAsync(HttpContext context){
        Console.WriteLine($"URL:{ context.Request.Path}");
        context.Items.Add("dataFMiddleware",$"<h1>{context.Request.Path}</h1>");
        //await context.Response.WriteAsync($"<h1>{context.Request.Path}</h1>");
        await _next(context);
         

    }
}
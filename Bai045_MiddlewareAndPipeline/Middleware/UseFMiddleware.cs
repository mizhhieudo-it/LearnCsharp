using Microsoft.AspNetCore.Builder;

public static class UseMiddleWareMethod 
{
    public static void UseFMiddleWareMethod(this IApplicationBuilder app){
        app.UseMiddleware<FMidFMiddleware>();
    }
}
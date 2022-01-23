using Microsoft.AspNetCore.Builder;

public static class UseMiddlewareMethod{
    public static void UseFirstMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<FirstMiddleWare>();
    }
    public static void UseSecondMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<SecondMiddleware>();
    }
}
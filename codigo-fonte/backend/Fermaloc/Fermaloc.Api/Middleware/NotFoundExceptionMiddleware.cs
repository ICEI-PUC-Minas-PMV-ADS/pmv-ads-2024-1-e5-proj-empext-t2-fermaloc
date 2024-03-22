using System.Net;
using System.Text.Json;

namespace Fermaloc.Api;

public class NotFoundExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<NotFoundExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public NotFoundExceptionMiddleware(RequestDelegate next, ILogger<NotFoundExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync (HttpContext context){
        try{
            await _next(context);
        }catch (Application.NotFoundException ex){
            var type = ex.GetType();
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = _env.IsDevelopment() ? 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) : 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, "Not found data"); 
            
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
            return;
        }
    }

    //     private static string JsonResponse(ILogger logger, HttpContext context, Exception ex, IHostEnvironment env){
    //         logger.LogError(ex, ex.Message);
    //         context.Response.ContentType = "application/json";
    //         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    //         var response = env.IsDevelopment() ? 
    //             new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) : 
    //             new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, "Internal server error"); 
            
    //         var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
    //         return JsonSerializer.Serialize(response, options);
    // } 
}
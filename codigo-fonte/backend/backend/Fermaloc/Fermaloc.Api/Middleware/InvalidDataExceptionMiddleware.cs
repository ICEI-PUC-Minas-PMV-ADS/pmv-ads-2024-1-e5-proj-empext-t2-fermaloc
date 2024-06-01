using System.Net;
using System.Text.Json;

namespace Fermaloc.Api;

public class InvalidDataExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<InvalidDataExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public InvalidDataExceptionMiddleware(RequestDelegate next, ILogger<InvalidDataExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync (HttpContext context){
        try{
            await _next(context);
        }catch (Application.InvalidDataException ex){
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = _env.IsDevelopment() ? 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) : 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, "Invalid data"); 
            
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
            return;
        }
    }
}

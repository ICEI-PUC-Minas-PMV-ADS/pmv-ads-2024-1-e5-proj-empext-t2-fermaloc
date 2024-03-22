using System.Net;
using System.Text.Json;

namespace Fermaloc.Api;

public class LoginExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoginExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public LoginExceptionMiddleware(RequestDelegate next, ILogger<LoginExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync (HttpContext context){
        try{
            await _next(context);
        }catch (Application.LoginException ex){
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = _env.IsDevelopment() ? 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) : 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, "Login invalid"); 
            
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
            return;
        }
    }
}

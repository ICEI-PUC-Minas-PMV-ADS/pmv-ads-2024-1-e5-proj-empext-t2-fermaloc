using System.Net;
using System.Net.Mail;
using System.Text.Json;
using Fermaloc.Api;

public class SmtpExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<SmtpExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public SmtpExceptionMiddleware(RequestDelegate next, ILogger<SmtpExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync (HttpContext context){
        try{
            await _next(context);
        }catch (SmtpException ex){
            var type = ex.GetType();
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = _env.IsDevelopment() ? 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace.ToString()) : 
                new ApiExeption(context.Response.StatusCode.ToString(), ex.Message, "Send email error"); 
            
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
            return;
        }
    }
}
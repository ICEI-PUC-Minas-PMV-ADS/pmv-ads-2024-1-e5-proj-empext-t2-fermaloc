using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Fermaloc.Application;

public class EmailService : IEmailService
{

    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ResetPassword(string destinatario, string newPassword){
        var email = _configuration.GetValue<string>("EmailConfig:EmailAddress");
        var key = _configuration.GetValue<string>("EmailConfig:Key");
        try{
            var client = new SmtpClient ("smtp.gmail.com", 587){
                Credentials = new NetworkCredential(email, key),
                EnableSsl = true,
            };
                
            var mail = new MailMessage(from: email, to: destinatario, subject: "Redefinição de senha", body: $"Sua nova senha é {newPassword}");
            await client.SendMailAsync(mail);
            
        }catch (SmtpException ex){
            throw new SmtpException(ex.Message);
        }
    }

    public async Task SendContactMail(string text, string? emailContact, string? phoneNumber1, string? phoneNumber2)
    {
        var email = _configuration.GetValue<string>("EmailConfig:EmailAddress");
        var key = _configuration.GetValue<string>("EmailConfig:Key");
        try{
            var client = new SmtpClient ("smtp.gmail.com", 587){
                Credentials = new NetworkCredential(email, key),
                EnableSsl = true,
            };
                
            var mail = new MailMessage(from: email, to: email, subject: "Cliente entrou em contato", body: $"{text}\nEmail para contato: " +
                $"{emailContact}\nCelular: {phoneNumber1} \nTelefone Fixo: {phoneNumber2}");
            await client.SendMailAsync(mail);
            
        }catch (SmtpException ex){
            throw new SmtpException(ex.Message);
        }
    }
}

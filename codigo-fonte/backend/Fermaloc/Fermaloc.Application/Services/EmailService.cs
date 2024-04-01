using System.Net;
using System.Net.Mail;

namespace Fermaloc.Application;

public class EmailService : IEmailService
{
    public async Task ResetPassword(string destinatario, string newPassword){
        var email = "gustavofermaloc@gmail.com";
        var password = "eage edeo vdjk dvba";
        try{
            var client = new SmtpClient ("smtp.gmail.com", 587){
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true,
            };
                
            var mail = new MailMessage(from: email, to: destinatario, subject: "Redefinição de senha", body: $"Sua nova senha é {newPassword}");
            await client.SendMailAsync(mail);
            
        }catch (SmtpException ex){
            throw new SmtpException(ex.Message);
        }
    }
}

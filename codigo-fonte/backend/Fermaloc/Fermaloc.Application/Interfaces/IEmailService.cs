namespace Fermaloc.Application;

public interface IEmailService
{
    Task ResetPassword(string destinatario, string newPassword);
    Task SendContactMail(string message, string? emailContact, string? phoneNumber1, string? phoneNumber2);
}

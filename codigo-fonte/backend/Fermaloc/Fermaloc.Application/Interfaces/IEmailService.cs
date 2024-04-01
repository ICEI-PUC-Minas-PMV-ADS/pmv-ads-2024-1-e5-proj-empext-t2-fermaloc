namespace Fermaloc.Application;

public interface IEmailService
{
    Task ResetPassword(string destinatario, string newPassword);
}

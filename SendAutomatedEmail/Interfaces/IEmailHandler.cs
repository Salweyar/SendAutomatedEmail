using SendAutomatedEmail.Models;

namespace SendAutomatedEmail.Interfaces
{
    public interface IEmailHandler
    {
        Task SendEmail(EmailModel model, string username, string password);
    }
}

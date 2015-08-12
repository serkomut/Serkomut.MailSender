using System.Net.Mail;

namespace Serkomut.MailSender
{
    public interface IEmailSender
    {
        IEmailSender FromHost(string host);
        IEmailSender Credential(string username, string password);
        IEmailSender FromTo(Message message);
        IEmailSender Subject(string subject);
        IEmailSender Body(string message);
        IEmailSender RazorTemplate<T>(string template, T model, bool isHtml = true);
        IEmailSender Attachment(Attachment attachment);
        string Send();
    }
}

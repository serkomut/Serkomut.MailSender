namespace Serkomut.MailSender
{
    public interface IRazorTemplate
    {
        string Parse<T>(string template, T model, bool isHtml = true);
    }
}
using RazorEngine;

namespace Serkomut.MailSender
{
    public class RazorTemplate : IRazorTemplate
    {
        public string Parse<T>(string template, T model, bool isHtml = true)
        {
            return Razor.Parse(template, model, template.GetHashCode().ToString());
        }
    }
}
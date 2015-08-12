using System;
using System.Net;
using System.Net.Mail;

namespace Serkomut.MailSender
{
    public class EmailSender : IEmailSender
    {
        public IEmailSender Subject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public IEmailSender Body(string body)
        {
            this.body = body;
            return this;
        }

        public IEmailSender RazorTemplate<T>(string template, T model, bool isHtml = true)
        {
            razorTemplate = new RazorTemplate();
            var parse = razorTemplate.Parse(template, model, isHtml);
            this.body = parse;
            return this;
        }

        public IEmailSender Attachment(Attachment attachment)
        {
            this.attachment = attachment;
            return this;
        }

        public IEmailSender FromTo(Message message)
        {
            this.message = message;
            return this;
        }

        public IEmailSender FromHost(string host)
        {
            this.host = host;
            return this;
        }

        public IEmailSender Credential(string username, string password)
        {
            this.username = username;
            this.password = password;
            return this;
        }

        public string Send()
        {
            try
            {
                var mail = new MailMessage();
                mail.To.Add(message.To);
                mail.From = new MailAddress(message.From);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                
                if (attachment != null)
                {
                    mail.Attachments.Add(attachment);
                }

                var smtp = new SmtpClient(host, 587)
                {
                    Credentials = new NetworkCredential(username, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                };
                smtp.Send(mail);
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        Message message;
        string host;
        string username;
        string password;
        string subject;
        string body;
        Attachment attachment;
        IRazorTemplate razorTemplate;
    }
}

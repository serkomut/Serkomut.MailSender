using System.IO;
using System.Net.Mail;
using NUnit.Framework;

namespace Serkomut.MailSender.Test
{
    [TestFixture]
    public class EmailSenderFixture
    {
        [Test]
        public void Send_Mail()
        {
            var result = new EmailSender()
                        .FromHost("smtp.gmail.com")
                        .Credential("senderemail@gmail.com", "***")
                        .FromTo(new Message
                        {
                            From = "senderemail@gmail.com",
                            To = "toemail@domain.com"
                        })
                        .Subject("Subject")
                        .Attachment(new Attachment(new MemoryStream(), "filename.***", "mediaType"))
                        .Body("Content text...").Send();
        }
    }

    
}

using System;
using System.IO;
using System.Net.Mail;
using NUnit.Framework;

namespace Serkomut.MailSender.Test
{
    [TestFixture]
    public class EmailSenderFixture
    {
        const string smtp = "smtp.gmail.com";
        const string sender = "sendermail@gmail.com";
        const string senderPass = "***";
        const string toMail = "toMail@gmail.com";

        [Test]
        public void Send_Mail()
        {
            var result = new EmailSender()
                        .FromHost(smtp)
                        .Credential(sender, senderPass)
                        .FromTo(new Message
                        {
                            From = sender,
                            To = toMail
                        })
                        .Subject("Subject")
                        .Attachment(new Attachment(new MemoryStream(), "filename.***", "mediaType"))
                        .Send();
        }

        [Test]
        public void Send_RazorTemplate_Mail()
        {
            const string template = "Hi @Model.Name @Model.Surname <br/>" +
                                    "Cities list: @foreach(var city in Model.Cities) {<p> @city.Name</p> <p> @city.Code</p>}";
            var model = new
            {
                Name = "Name",
                Surname = "Surname",
                Cities = new[]
                {
                    new
                    {
                        Name = "Adana",
                        Code = "01"
                    },
                    new
                    {
                        Name = "Istanbul",
                        Code = "34"
                    },
                    new
                    {
                        Name = "Izmir",
                        Code = "35"
                    }
                }
            };

            var result = new EmailSender()
                    .FromHost(smtp)
                    .Credential(sender, senderPass)
                    .FromTo(new Message
                    {
                        From = sender,
                        To = toMail
                    })
                    .Subject("Subject")
                    .RazorTemplate(template, model)
                    .Send();

            Console.WriteLine(result);
        }
    }

    
}

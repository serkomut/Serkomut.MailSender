# Serkomut.MailSender

Fluent email sender.
###Example usage from:

```csharp
var result = new EmailSender()
            .FromHost("smtp.gmail.com")
            .Credential("senderemail@gmail.com", "***")
            .FromTo(new Message
            {
                From = "senderemail@gmail.com",
                To = "toemail@domain.com"
            })
            .Subject("Subject")
            .Body("Content text...")
			.Attachment(new Attachment(new MemoryStream(), "filename.***", "mediaType"))
            .Send();
```

###Example usage from razor template:
```csharp
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
```

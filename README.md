# Serkomut.MailSender

Fluent email sender.
##Example usage from:

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Utils;

namespace Postman.Models
{
    public class MailkitMessage : IMessageImplementation
    {
        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get { return Message.Headers.Select(x => new KeyValuePair<string, string>(x.Field, x.Value)); }
        }

        public IEnumerable<string> From
        {
            get { return Message.From.OfType<MailboxAddress>().Select(x => x.Address); }
        }

        public IEnumerable<string> To
        {
            get { return Message.To.OfType<MailboxAddress>().Select(x => x.Address); }
        }

        public string Subject
        {
            get { return Message.Subject; }
        }

        public string TextBody
        {
            get { return Message.TextBody; }
        }

        public string HtmlBody
        {
            get { return Message.HtmlBody; }
        }

        private MimeMessage Message { get; set; }

        public void WriteTo(Stream stream)
        {
            Message.WriteTo(stream);
        }

        public static IMessageImplementation CreateFromStream(Stream stream)
        {
            return new MailkitMessage { Message = MimeMessage.Load(stream) };
        }

        public static IMessageImplementation CreateFromImplementation(MimeMessage message)
        {
            if (message == null)
                return null;

            return new MailkitMessage { Message = message };
        }

        public class MessageBuilder : IMessageBuilderImplementation
        {
            private MimeMessage _message = new MimeMessage();
            private MailkitMessage _result = new MailkitMessage();
            private BodyBuilder _bodyBuilder = new BodyBuilder();

            public IMessageImplementation Result
            {
                get
                {
                    _message.Body = _bodyBuilder.ToMessageBody();
                    return _result;
                }
            }

            public MessageBuilder()
            {
                _result.Message = _message;
            }

            public void Reset()
            {
                _message = new MimeMessage();
                _result = new MailkitMessage {Message = _message};
                _bodyBuilder = new BodyBuilder();
            }

            public void SetTextBody(string textBody)
            {
                _bodyBuilder.TextBody = textBody;
            }

            public void SetHtmlBody(string htmlBody)
            {
                _bodyBuilder.HtmlBody = htmlBody;
            }

            public void AddFrom(string email)
            {
                _message.From.Add(new MailboxAddress(email));
            }

            public void RemoveFrom(string email)
            {
                var address = _message.From.OfType<MailboxAddress>().FirstOrDefault(x => x.Address == email);
                if (address != null)
                    _message.From.Remove(address);
            }

            public void AddTo(string email)
            {
                _message.To.Add(new MailboxAddress(email));
            }

            public void RemoveTo(string email)
            {
                var address = _message.To.OfType<MailboxAddress>().FirstOrDefault(x => x.Address == email);
                if (address != null)
                    _message.To.Remove(address);
            }

            public string AddResource(string filePath)
            {
                var resource = _bodyBuilder.LinkedResources.Add(filePath);
                resource.ContentId = MimeUtils.GenerateMessageId();

                return resource.ContentId;
            }

            public void AddAttachment(string filePath)
            {
                _bodyBuilder.Attachments.Add(filePath);
            }
        }
    }
}

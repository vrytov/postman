using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class MessageBuilder
    {
        private readonly IMessageBuilderImplementation _builder;

        public MessageBuilder(IMessageBuilderImplementation builder)
        {
            _builder = builder;
        }

        public Message Result
        {
            get
            {
                return new Message(_builder.Result);
            }
        }

        public void Reset()
        {
            _builder.Reset();
        }

        public void SetTextBody(string textBody)
        {
            _builder.SetTextBody(textBody);
        }

        public void SetHtmlBody(string htmlBody)
        {
            _builder.SetHtmlBody(htmlBody);
        }

        public void AddFrom(string email)
        {
            _builder.AddFrom(email);
        }

        public void RemoveFrom(string email)
        {
            _builder.RemoveFrom(email);
        }

        public void AddTo(string email)
        {
            _builder.AddTo(email);
        }

        public void RemoveTo(string email)
        {
            _builder.RemoveTo(email);
        }

        public string AddResource(string filePath)
        {
            return _builder.AddResource(filePath);
        }

        public void AddAttachment(string filePath)
        {
            _builder.AddAttachment(filePath);
        }
    }
}

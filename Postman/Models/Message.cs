using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace Postman.Models
{
    public class Message
    {
        private readonly IMessageImplementation _message;

        public Message(IMessageImplementation message)
        {
            _message = message;
        }

        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get { return _message.Headers; }
        }

        public IEnumerable<string> From
        {
            get { return _message.From; }
        }

        public IEnumerable<string> To
        {
            get { return _message.To; }
        }

        public string Subject
        {
            get { return _message.Subject; }
        }

        public string TextBody
        {
            get { return _message.TextBody; }
        }

        public string HtmlBody
        {
            get { return _message.HtmlBody; }
        }

        public void WriteTo(Stream stream)
        {
            _message.WriteTo(stream);
        }
    }
}

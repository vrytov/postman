using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace Postman.Models
{
    internal class MailkitMessage : IMessage
    {
        public IEnumerable<KeyValuePair<string, string>> Headers
        {
            get { return Message.Headers.Select(x => new KeyValuePair<string, string>(x.Field, x.Value)); }

            set
            {                
                Message.Headers.Clear();

                if (value == null)
                    return;

                foreach (var pair in value)
                {
                    Message.Headers.Add(pair.Key, pair.Value);
                }
            }
        }

        public IEnumerable<string> From
        {
            get
            {
                return Message.From.Select(x => x.Name);
            }

            set
            {
                Message.From.Clear();

                if (value == null)
                    return;

                foreach (var address in value)
                {
                    //Message.From.Add(new );
                }
            }
        }

        public IEnumerable<string> To { get; set; }

        public string Subject { get; set; }
        public string Content { get; set; }
        public string Html { get; set; }

        public MimeMessage Message { get; set; } = new MimeMessage();

        public void WriteTo(Stream stream)
        {
            Message.WriteTo(stream);
        }

        public static IMessage CreateFromStream(Stream stream)
        {
            return new MailkitMessage{ Message = MimeMessage.Load(stream) };
        }
    }
}

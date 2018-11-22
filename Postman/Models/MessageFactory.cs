using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace Postman.Models
{
    public static class MessageFactory
    {
        public static Type MessageImplementationType { get; } = typeof(MailkitMessage);
        public static Type MessageBuilderType { get; } = typeof(MailkitMessage.MessageBuilder);

        public static MessageBuilder GetMessageBuilder()
        {
            return new MessageBuilder(Activator.CreateInstance(MessageBuilderType) as IMessageBuilderImplementation);
        }

        public static Message CreateMessageFromStream(Stream stream)
        {
            return new Message(MailkitMessage.CreateFromStream(stream));
        }

        public static Message CreateMessageFromImplementation(object message)
        {
            var messageImp = message as MimeMessage;
            if (messageImp == null)
                throw new ArgumentException("Invalid type of message implementation.", nameof(message));

            return new Message(MailkitMessage.CreateFromImplementation(messageImp));
        }
    }
}

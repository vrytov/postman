using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class ServerCredentials
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseEncryption { get; set; }
    }

    public enum InboxEmailProtocol
    {
        Imap,
        Pop3
    }

    public class EmailServerConfiguration
    {
        public string Name { get; set; }
        public InboxEmailProtocol DefaultInboxEmailProtocol { get; set; } = InboxEmailProtocol.Pop3;

        public ServerCredentials SmtpCredentials { get; } = new ServerCredentials();
        public ServerCredentials Pop3Credentials { get; } = new ServerCredentials();
        public ServerCredentials ImapCredentials { get; } = new ServerCredentials();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Postman.Models
{
    public class ServerCredentials
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSslEncryption { get; set; } = true;
        public bool UseTlsEncryption { get; set; } = false;        
    }

    public enum InboxEmailProtocol
    {
        Imap,
        Pop3
    }

    public class EmailServerConfiguration
    {        
        public InboxEmailProtocol DefaultInboxEmailProtocol { get; set; } = InboxEmailProtocol.Pop3;

        [JsonIgnore]
        public EmailServerCredentials ServerCredentials
        {
            get
            {
                if (ServerCredentialsId <= AppStorage.Instance.EmailServers.Count)
                    return null;

                return AppStorage.Instance.EmailServers[ServerCredentialsId];
            }
        }

        public int ServerCredentialsId { get; set; }        
    }

    public class EmailServerCredentials
    {
        public string IconPath { get; set; }
        public string Name { get; set; }

        public ServerCredentials Smtp { get; } = new ServerCredentials();
        public ServerCredentials Pop3 { get; } = new ServerCredentials();
        public ServerCredentials Imap { get; } = new ServerCredentials();
    }
}

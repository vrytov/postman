using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Postman.Models
{
    public enum InboxEmailProtocol
    {
        Imap,
        Pop3
    }

    public class AuthCredentials
    {
        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        
        public string EncryptedPassword { get; set; }

        public InboxEmailProtocol DefaultInboxEmailProtocol { get; set; } = InboxEmailProtocol.Pop3;

        [JsonIgnore]
        public EmailServerCredentials ServerCredentials
        {
            get
            {
                if (ServerCredentialsId >= AppStorage.Instance.EmailServers.Count)
                    return null;

                return AppStorage.Instance.EmailServers[ServerCredentialsId];
            }
        }

        public int ServerCredentialsId { get; set; }
    }
}

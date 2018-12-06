using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class EmailServerCredentials
    {        
        public string Name { get; set; }

        public ServerCredentials Smtp { get; } = new ServerCredentials();
        public ServerCredentials Pop3 { get; } = new ServerCredentials();
        public ServerCredentials Imap { get; } = new ServerCredentials();
    }

    public class ServerCredentials
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool UseSslEncryption { get; set; } = true;
        public bool UseTlsEncryption { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Postman.Models
{
    public class AuthCredentials
    {
        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        
        public string EncryptedPassword { get; set; }

        public EmailServerConfiguration ServerConfiguration { get; set; }
    }
}

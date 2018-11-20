using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class AuthCredentials
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public EmailServerConfiguration ServerConfiguration { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class AppStorage
    {
        public List<User> Users { get; set; }
        public List<EmailServerConfiguration> EmailServers { get; set; }

        public List<Message> Messages { get; set; }
    }
}

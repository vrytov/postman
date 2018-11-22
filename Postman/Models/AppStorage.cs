using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class AppStorage
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<EmailServerConfiguration> EmailServers { get; set; } = new List<EmailServerConfiguration>();
    }
}

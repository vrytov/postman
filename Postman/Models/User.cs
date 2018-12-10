using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postman.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<AuthCredentials> CredentialsList { get; } = new List<AuthCredentials>();
    }
}

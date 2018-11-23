using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Postman.Models
{
    public class AppStorage
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<EmailServerConfiguration> EmailServers { get; set; } = new List<EmailServerConfiguration>();

        private AppStorage()
        {

        }

        private static AppStorage _instance;

        public static AppStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = JsonConvert.DeserializeObject()
            }
        }

        public static AppStorage getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}

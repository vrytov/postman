using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows;
using Newtonsoft.Json;

namespace Postman.Models
{
    public class AppStorage
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<EmailServerCredentials> EmailServers { get; set; } = new List<EmailServerCredentials>();

        private AppStorage()
        {

        }

        private static AppStorage _instance;

        private const string _storageFileName = "data.json";

        private static void InitializeDefaultEmailServers(List<EmailServerCredentials> servers)
        {
            var preset = new EmailServerCredentials
            {
                Name = "Gmail",
                Pop3 = { Address = "pop.gmail.com", Port = 995, UseSslEncryption = true},
                Smtp = { Address = "smtp.gmail.com", Port = 465, UseSslEncryption = true, UseTlsEncryption = false},
                Imap = { Address = "imap.gmail.com", Port = 993, UseSslEncryption = true}
            };

            servers.Add(preset);
        }

        public static AppStorage Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + _storageFileName;
                if (!File.Exists(path))
                {
                    _instance = new AppStorage();
                    InitializeDefaultEmailServers(_instance.EmailServers);
                }
                else
                {
                    var json = File.ReadAllText(path);
                    _instance = JsonConvert.DeserializeObject(json) as AppStorage;
                }

                return _instance;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using Newtonsoft.Json;
using Postman.Entities;
using Postman.Models;
using Postman.Views;

namespace Postman
{
    public partial class MainWindow : Window
    {
        private ImapClient client = new ImapClient();

        public MainWindow()
        {
            InitializeComponent();

            var storage = new AppStorage();
            var server = new EmailServerConfiguration()
                {DefaultInboxEmailProtocol = InboxEmailProtocol.Imap, Name = "testserver"};

            server.ImapCredentials.Address = "test@test.ru";
            server.ImapCredentials.Port = 1111;
            server.ImapCredentials.UseEncryption = false;

            server.Pop3Credentials.Address = "pop2@mail.com";
            server.Pop3Credentials.Port = 101;
            server.Pop3Credentials.UseEncryption = true;

            storage.EmailServers.Add(server);

            var user = new User() { Name = "testuser"};
            var auth = new AuthCredentials() { Login = "login", Password = "password", ServerConfiguration = server};

            user.CredentialsList.Add(auth);

            storage.Users.Add(user);

            var json = JsonConvert.SerializeObject(storage);

            var st2 = JsonConvert.DeserializeObject<AppStorage>(json);


            
            // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect("imap.mail.ru", 993, true);
            
            client.Authenticate("test@mail.ru", "test");

            client.Inbox.Open(FolderAccess.ReadOnly);

            var test = client.GetFolder(client.PersonalNamespaces[0]);

            for (int i = 0; i < 1; i++)
            {
                var m = client.Inbox.GetMessage(i);
                var message = MessageFactory.CreateMessageFromImplementation(m);
                var tb = new TextBlock();
                tb.Text = message.From.ToList()[0] + ": " + message.TextBody;
                StackPanel.Children.Add(tb);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new UserSettingsWindow().ShowDialog();
        }
    }
}

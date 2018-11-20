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

namespace Postman
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///
    
    public partial class MainWindow : Window
    {
        private ImapClient client = new ImapClient();

        public MainWindow()
        {
            InitializeComponent();            
            
            // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect("imap.mail.ru", 993, true);

            client.Authenticate("stalker_liss@mail.ru", "324umdFPT2103_");

            client.Inbox.Open(FolderAccess.ReadOnly);

            var test = client.GetFolder(client.PersonalNamespaces[0]);

            var context = new MessageContext();

            foreach (var message in context.Messages)
            {
                var str = new MemoryStream(message.Content);
                var m = MimeMessage.Load(str);

            }

            for (int i = 0; i < 0; i++)
            {
                var m = client.Inbox.GetMessage(i);
                var str = new MemoryStream();
                m.WriteTo(str);

                context.Messages.Add(new Entities.Message() {Content = str.ToArray()});
            }

            context.SaveChanges();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

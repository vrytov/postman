using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Postman.Models;

namespace Postman.ViewModels
{
    public class AuthCredentialsViewModel : ViewModelBase
    {
        private readonly AuthCredentials _credentials;

        public AuthCredentialsViewModel(AuthCredentials credentials)
        {
            _credentials = credentials;
            ServerCredentials = new EmailServerCredentialsViewModel()
            {
                Model = _credentials.ServerCredentials,
                Icon = new BitmapImage(new Uri(@"/Resources/google.png", UriKind.Relative))            
            };
        }

        public string Login
        {
            get { return _credentials.Login; }
            set
            {
                _credentials.Login = value;                

                OnPropertyChanged(nameof(Login));
            }
        }

        public string EncryptedPassword
        {
            get { return _credentials.EncryptedPassword; }
            set
            {
                _credentials.EncryptedPassword = value;

                OnPropertyChanged(nameof(EncryptedPassword));
            }
        }

        public EmailServerCredentialsViewModel ServerCredentials { get; set; }
    }
}

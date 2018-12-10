using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MahApps.Metro.Controls.Dialogs;
using Postman.Common;
using Postman.Models;
using Postman.Properties;
using Postman.Views;

namespace Postman.ViewModels
{
    public class UserSettingsViewModel : ViewModelBase
    {
        private UserViewModel _selectedUser;
        public UserViewModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public ObservableCollection<UserViewModel> Users { get; set; } = new ObservableCollection<UserViewModel>();

        private RelayCommand _addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return _addUserCommand ??
                       (_addUserCommand = new RelayCommand(x => AddUser()));
            }
        }

        private void AddUser()
        {
            var d = new EditUserView(new UserViewModel(new User() { Name = "test" }));
            d.ShowDialog();
        }

        public UserSettingsViewModel()
        {
            var user = new User() {Name = "User"};
            var auth = new AuthCredentials();
            auth.Login = "login@mail.ru";
            auth.Password = "test";
            auth.ServerCredentialsId = 0;
            user.CredentialsList.Add(auth);

            var z = auth.ServerCredentials;
            
            Users.Add(new UserViewModel(user));
            AppStorage.Instance.Users.ForEach(x => Users.Add(new UserViewModel(x)));
        }
    }
}

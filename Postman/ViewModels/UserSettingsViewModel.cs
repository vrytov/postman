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
using Postman.Properties;

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

        public ObservableCollection<UserViewModel> Users { get; set; }

        public UserSettingsViewModel()
        {
            Users = new ObservableCollection<UserViewModel>()
            {
                new UserViewModel() { Name = "t2est", Description = "descr \r\n test \r\n test 2"},
                new UserViewModel() { Name = "tzest", Description = "descr"},
                new UserViewModel() { Name = "tpest", Description = "descr"},
                new UserViewModel() { Name = "toest", Description = "descr"},
                new UserViewModel() { Name = "tkest", Description = "descr"},
            };
        }
    }
}

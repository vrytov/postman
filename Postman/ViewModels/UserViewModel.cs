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
using Postman.Models;

namespace Postman.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _user;

        public UserViewModel(User user)
        {
            _user = user;
            _color = GetColorFromName(_user.Name);
            AuthCredentials = new ObservableCollection<AuthCredentialsViewModel>(
                _user.CredentialsList.Select(x => new AuthCredentialsViewModel(x)));
        }

        private static readonly List<SolidColorBrush> _colors = new List<SolidColorBrush>
        {
            new SolidColorBrush(Colors.Chocolate),
            new SolidColorBrush(Colors.Brown),
            new SolidColorBrush(Colors.Coral),
            new SolidColorBrush(Colors.BlueViolet),
            new SolidColorBrush(Colors.CadetBlue),
            new SolidColorBrush(Colors.Crimson),
            new SolidColorBrush(Colors.DarkSlateBlue),
            new SolidColorBrush(Colors.DarkOliveGreen),
            new SolidColorBrush(Colors.ForestGreen),
            new SolidColorBrush(Colors.DimGray),
            new SolidColorBrush(Colors.Fuchsia),
            new SolidColorBrush(Colors.HotPink),
            new SolidColorBrush(Colors.MediumOrchid),
        };
        
        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;

                if (value != null)
                    _color = GetColorFromName(value);

                OnPropertyChanged(nameof(Name));
            }
        }

        public ObservableCollection<AuthCredentialsViewModel> AuthCredentials { get; set; }

        public string ShortName
        {
            get { return Name.Substring(0, 2); }
        }

        private SolidColorBrush _color;

        public SolidColorBrush Color
        {
            get { return _color; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private SolidColorBrush GetColorFromName(string name)
        {
            using (var md5Hasher = MD5.Create())
            {
                var strippedName = name.Replace(" ", "");
                var hashed = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strippedName));
                var intval = Math.Abs(BitConverter.ToInt32(hashed, 0));

                return _colors[intval % _colors.Count];
            }
        }
    }
}

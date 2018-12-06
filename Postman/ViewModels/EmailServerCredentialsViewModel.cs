using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Postman.Models;

namespace Postman.ViewModels
{
    public class EmailServerCredentialsViewModel
    {
        public ImageSource IconPath { get; set; }
        public EmailServerCredentials Model { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Postman.Models;
using Postman.ViewModels;

namespace Postman.Views
{
    /// <summary>
    /// Логика взаимодействия для EditUserView.xaml
    /// </summary>
    public partial class EditUserView : MetroWindow
    {
        public EditUserView(UserViewModel user)
        {
            InitializeComponent();

            DataContext = user;
        }
    }
}

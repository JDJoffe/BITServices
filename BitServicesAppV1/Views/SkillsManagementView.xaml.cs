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
//add
using BitServicesDesktopApp.ViewModels;

namespace BitServicesDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for SkillsManagementView.xaml
    /// </summary>
    public partial class SkillsManagementView : Page
    {
        public SkillsManagementView()
        {
            InitializeComponent();
            DataContext = new SkillsManagementViewModel();
        }
    }
}

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

namespace BitServicesDesktopApp
{
    /// <summary>
    /// Interaction logic for ContractorManagementView.xaml
    /// </summary>
    public partial class ContractorManagementView : Page
    {
        public ContractorManagementView()
        {
            InitializeComponent();
            DataContext = new ContractorManagementViewModel();
        }
    }
}

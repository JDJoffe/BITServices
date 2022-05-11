
using System;
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
namespace BitServicesDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new ClientManagementView());
            minimizeBtn.Click += (s, e) => WindowState = WindowState.Minimized;
            maximizeBtn.Click += (s, e) => WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            closeBtn.Click += (s, e) => Close();
        }

        private void ClientManagementBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ClientManagementView());
        }
        private void ContractorManagementBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ContractorManagementView());
        }

        private void JobManagementBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new JobManagementView());
        }

        private void CoordinatorManagementBtn_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new CoordinatorManagementView());
        }
    }
}
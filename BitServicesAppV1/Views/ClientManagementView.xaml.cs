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
//add
using BitServicesDesktopApp.ViewModels;
using BitServicesDesktopApp.Logging;

namespace BitServicesDesktopApp
{
    /// <summary>
    /// Interaction logic for ClientManagementView.xaml
    /// </summary>
    public partial class ClientManagementView : Page
    {
       
        public ClientManagementView()
        {
            InitializeComponent();
            DataContext = new ClientManagementViewModel();

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            

           // LogSwitch.Log(LogType.File,$"A new client  of the name {cliNameTxt.Text} has been added");
        }
    }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.ComponentModel;
using System.Collections.ObjectModel;
using BitServicesDesktopApp.Models;

namespace BitServicesDesktopApp.ViewModels
{
    class ClientManagementViewModel : INotifyPropertyChanged
    {
        #region Priv Var
        private Job _selectedClient;
        private ObservableCollection<Client> _allClients;
        private RelayCommand _updateCommand;
        #endregion
        #region Pub Var
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Onprop
        public Job SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }    
        public ObservableCollection<Client> AllClients
        {
            get { return _allClients; }
            set
            {
                _allClients = value;
                OnPropertyChanged("AllClients");
            }
        }
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(UpdateMethod, true);
                }
                return _updateCommand;
            }
            set { _updateCommand = value; }
        }
        #endregion

        public ClientManagementViewModel()
        {
            Clients allClients = new Clients();
            AllClients = new ObservableCollection<Client>(allClients);
        }
        public void UpdateMethod()
        {

        }

        void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}

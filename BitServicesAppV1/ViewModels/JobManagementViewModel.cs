using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//add
using System.ComponentModel;
using System.Collections.ObjectModel;
using BitServicesDesktopApp.Models;

namespace BitServicesDesktopApp.ViewModels
{
    class JobManagementViewModel : INotifyPropertyChanged
    {
        #region Priv Var
        private Job _selectedJob;
        private ObservableCollection<Job> _allUnassignedJobs;
        private ObservableCollection<Job> _allCompletedJobs;
        private RelayCommand _updateCommand;
        #endregion
        #region Pub Var
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Onprop
        public Job SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                _selectedJob = value;
                OnPropertyChanged("SelectedJob");
            }
        }
        public ObservableCollection<Job> AllUnassignedJobs
        {
            get { return _allUnassignedJobs; }
            set
            {
                _allUnassignedJobs = value;
                OnPropertyChanged("AllUnassignedJobs");
            }
        }
        public ObservableCollection<Job> AllCompletedJobs
        {
            get { return _allCompletedJobs; }
            set
            {
                _allCompletedJobs = value;
                OnPropertyChanged("AllCompletedJobs");
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

        #region Constructor
        public JobManagementViewModel()
        {
            AllUnassignedJobs allUnJobs = new AllUnassignedJobs();
            AllUnassignedJobs = new ObservableCollection<Job>(allUnJobs);
            AllCompletedJobs allComJobs = new AllCompletedJobs();
            AllCompletedJobs = new ObservableCollection<Job>(allComJobs);
        }
        #endregion


        public void UpdateMethod()
        {
            // int returnVal = SelectedBooking.ChangePaymentStatus(SelectedPayment.PaymentstatusId);
            //if (returnVal > 0)
            //{
            //    MessageBox.Show("Payment Status updated");
            //}
            //else
            //{
            //    MessageBox.Show("Payment Status was not updated");
            //}
            //UpdateCompletedBookings();
        }
        private void UpdateCompletedBookings()
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

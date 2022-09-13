using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using BitServicesDesktopApp.DAL;

namespace BitServicesDesktopApp.Models
{
    public class Client
    {

        private int _clientId;
        private string _name;
        private string _phone;
        private string _email;
        private string _password;
        private bool _isActive;
        private SQLDAL _db;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("ClientId");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("ClientId");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("ClientId");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("ClientId");
            }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged("ClientId");
            }
        }

        public Client()
        {
            _db = new SQLDAL();
        }

        public Client(DataRow dr)
        {
            ClientId = Convert.ToInt32(dr["Client_Id"].ToString());
            Name = dr["Name"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            Password = dr["Password"].ToString();
            IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}

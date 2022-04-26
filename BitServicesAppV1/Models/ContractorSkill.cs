using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.Data;
using BitServicesDesktopApp.DAL;
using System.ComponentModel;

namespace BitServicesDesktopApp.Models
{
   public class ContractorSkill : INotifyPropertyChanged
    {
        private string _Skill;
        private SQLDAL _Db;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Skill
        {
            get { return _Skill; }
            set
            {
                _Skill = value;
                OnPropertyChanged("skill");
            }
        }

        public ContractorSkill()
        {
            _Db = new SQLDAL();
        }

        public ContractorSkill(DataRow dr)
        {
            _Skill = dr["skill"].ToString();
            _Db = new SQLDAL();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//add
using System.Windows.Input;

namespace BitServicesDesktopApp
{
    internal class RelayCommand : ICommand
    {
        #region Priv Var
        private Action _whatToExecute;
        #endregion

        #region Pub Var
        public event EventHandler CanExecuteChanged;
        private bool _canExecute;
        #endregion
        #region Constructor
        public RelayCommand(Action what, bool canExecute)
        {
            _whatToExecute = what;
            _canExecute = canExecute;
        }
        #endregion
        #region Pub Method
        public bool CanExecute(object param)
        {
            return _canExecute;
        }
        public void Execute(object param)
        {
            _whatToExecute.Invoke();
        }
        #endregion
    }
}

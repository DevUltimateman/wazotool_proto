using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wazotool_proto.Core
{
    class RelayCommand : ICommand
    {

        private Action<object> _execute;
        private Func<object, bool> _canExecute;



        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;

            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }   

        public bool CanExecute( object pa )
        {
            return _canExecute == null || _canExecute(pa);

        }

        public void Execute ( object pa )
        {
            _execute(pa);
        }
    }
}

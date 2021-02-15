using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTestApp.Commands
{
    class RelayCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        public RelayCommands(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}

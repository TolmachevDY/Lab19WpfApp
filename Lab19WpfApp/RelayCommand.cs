using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19WpfApp
{
    internal class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object,bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action<object> Execut, Func<object,bool> CanExecute=null)
        {
            execute = Execut ?? throw new ArgumentNullException(nameof(Execut));
            canExecute = CanExecute;
        }
        public bool CanExecute(object parameter)=> canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)=> execute(parameter);
    }
}

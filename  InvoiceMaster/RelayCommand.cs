using System;
using System.Windows.Input;

namespace InvoiceMaster
{
    public class RelayCommand : ICommand
    {
        readonly Predicate<object> _canExecute;
        readonly Action<object> _execute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute,
            Predicate<object> canExecute)
        {
            _execute = execute ?? throw new NullReferenceException("execute");
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute(parameter);

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
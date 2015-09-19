using System;
using System.Windows.Input;

namespace IstarWindows.ViewModels
{

    /// <summary>
    /// ActionCommand Class.
    /// </summary>
    public sealed class ActionCommand : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object> _predicate;

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

        public void CanExecuteChanged_RaiseEvent(object sender, EventArgs e)
        {
            CanExecute(sender);
        }

        public ActionCommand(Action<object> action) : this(action, null)
        {
        }

        public ActionCommand(Action<object> action, Predicate<object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>");
            }

            _action = action;
            _predicate = predicate;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }

    }
}
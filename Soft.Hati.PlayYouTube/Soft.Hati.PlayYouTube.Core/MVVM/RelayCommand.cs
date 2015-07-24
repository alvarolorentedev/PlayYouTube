using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Soft.Hati.PlayYouTube.Core.MVVM
{
    // Josh Smith's relay command 
    // reference: http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
    public class RelayCommand : ICommand
    {
        private static Dispatcher dispatcher = null;
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public static void Invalidate()
        {
            if ((dispatcher == null) && (Application.Current != null))
                dispatcher = Application.Current.Dispatcher;

            if (dispatcher != null && !dispatcher.CheckAccess())
                dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)CommandManager.InvalidateRequerySuggested);
        }
    }
}
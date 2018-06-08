using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PicDB.ViewModels
{
    public class RelayCommandViewModel : CommandViewModel
    {
        public RelayCommandViewModel(string label, string toolTip, Action<object> execute)
            : this(label, toolTip, execute, null)
        {
        }

        public RelayCommandViewModel(string label, string toolTip, Action<object> execute, Func<bool> canExecute = null)
            : base(label, toolTip)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            this._execute = execute;
            this._canExecute = canExecute;
        }

        private Action<object> _execute;
        private Func<bool> _canExecute;

        public override bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute();
            }
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

}

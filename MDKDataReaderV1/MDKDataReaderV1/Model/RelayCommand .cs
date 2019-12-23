using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MDKDataReaderV1.Model
{
    public class RelayCommand : ICommand
    {
        private Action _noarghandler = null;
        private Action<object> _handler = null;
        private Func<object, bool> _canhandler = null;
        private bool executeable = true;

        public RelayCommand(Action handler)
        {
            _noarghandler = handler;
        }

        public RelayCommand(Action<object> handler)
        {
            _handler = handler;
        }

        public RelayCommand(Action handler, Func<object, bool> canhandler)
        {
            _noarghandler = handler;
            _canhandler = canhandler;
        }

        public RelayCommand(Action<object> handler, Func<object, bool> canhandler)
        {
            _handler = handler;
            _canhandler = canhandler;
        }

        public bool CanExecute(object parameter)
        {
            if (_canhandler != null)
            {
                bool result = _canhandler(parameter);
                //if (executeable != result)
                //{
                    executeable = result;

                //    if (CanExecuteChanged != null)
                //        CanExecuteChanged(parameter, null);
                //}
                //上面的代码为什么需要，忘记了，不过，如果启用的话会导致死循环 2017-9-27
            }
            return executeable;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_noarghandler != null)
                _noarghandler();
            else if (_handler != null)
                _handler(parameter);
        }

        public void RaisCanExecuteChanded()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(null, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1_Snigur.Variant20.NET1.Invoker
{
    class Command : ICommand
    {
        private Action _command;

        public Command(Action command)
        {
            this._command = command;
        }

        public void Execute()
        {
            _command();
        }
    }
}

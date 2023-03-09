using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET1_Snigur.Variant20.NET1;

namespace NET1_Snigur.Variant20.NET1.Invoker
{
    class Invoker
    {
        private ICommand _action;
        
        public void SetAction(ICommand action)
        {
            this._action = action;
        }

        public void StartDoingAction()
        {
            if (this._action is ICommand)
            {
                this._action.Execute();
            }
        }
    }
}

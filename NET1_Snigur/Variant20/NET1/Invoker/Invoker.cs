using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOTNET.Variant20.NET1;
using DOTNET.Variant20.NET2;

namespace DOTNET.Variant20.NET1.Invoker
{
    class Invoker
    {
        private ICommand _action;
        private LinkedList<ICommand> _actions;

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

        public void SetBlockOfAction(Dictionary<GeneralTaskNumber, OutputHelper> actions)
        {
            this._actions = new LinkedList<ICommand>();

            foreach (var action in actions)
            {
                Command command = new Command(action.Value.Output());
                this._actions.AddLast(command);
            }
        }
        public void StartDoingBlockOfAction()
        {
            foreach (var action in _actions)
            {
                SetAction(action);
                StartDoingAction();
            }
        }
    }
}

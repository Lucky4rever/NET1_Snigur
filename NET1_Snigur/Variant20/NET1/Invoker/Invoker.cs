using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOTNET.Variant20.NET1;

namespace DOTNET.Variant20.NET1.Invoker
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

        public void StartDoingBlockOfAction(Dictionary<GeneralTaskNumber, Action> actions)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Start doing action block of action...");
            Console.ResetColor();
            Console.WriteLine();

            foreach (var action in actions)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Start doing action {action.Key}...");
                Console.ResetColor();
                Console.WriteLine();

                Command command = new Command(action.Value);
                SetAction(command);
                StartDoingAction();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Done!");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

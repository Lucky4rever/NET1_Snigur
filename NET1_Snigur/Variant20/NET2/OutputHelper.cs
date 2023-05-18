using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2
{
    class OutputHelper
    {
        private readonly string _description;
        private readonly Func<IEnumerable<object>> _action;

        public OutputHelper(string description, Func<IEnumerable<object>> action)
        {
            this._description = description;
            this._action = action;
        }

        public Action Output()
        {
            return () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(this._description);
                Console.ResetColor();

                var actionResult = this._action();
                if (actionResult != null)
                {
                    foreach (var property in actionResult)
                    {
                        Console.WriteLine(property);
                    }
                }

                Console.WriteLine();
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET3
{
    abstract class CustomShape
    {
        public virtual void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shape info:");
            Console.ResetColor();
        }

        public virtual void PrintAllPerimeters()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shape perimeter(s):");
            Console.ResetColor();
        }

        public virtual void PrintAllAreas()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shape area(s):");
            Console.ResetColor();
        }
    }
}

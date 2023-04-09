using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2.ComponentCreator
{
    class CovenantComponentCreator : IComponentCreator
    {
        public void NewComponent()
        {
            Console.WriteLine("Creating new covenant...");

            Console.Write("Set the client ID: ");
            int clientId = int.Parse(Console.ReadLine());

            Console.Write("Set the car ID: ");
            int carId = int.Parse(Console.ReadLine());

            Console.Write("Set client phone: ");
            string phone = Console.ReadLine();

            Console.Write("Set issue date: ");
            DateTime issueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Set return date: ");
            DateTime returnDate = DateTime.Parse(Console.ReadLine());

            Data.Covenants.Add(new Covenant(Data.Covenants.Count, clientId, carId, issueDate, returnDate));
            Console.WriteLine("A new covenant has been added!");
        }
    }
}

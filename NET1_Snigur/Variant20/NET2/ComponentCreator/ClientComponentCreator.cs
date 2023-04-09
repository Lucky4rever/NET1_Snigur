using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2.ComponentCreator
{
    class ClientComponentCreator : IComponentCreator
    {
        public void NewComponent()
        {
            Console.WriteLine("Creating new client...");

            Console.Write("Set client name: ");
            string name = Console.ReadLine();

            Console.Write("Set client address: ");
            string address = Console.ReadLine();

            Console.Write("Set client phone: ");
            string phone = Console.ReadLine();

            Data.Clients.Add(new Client(Data.Clients.Count, name, address, phone));
            Console.WriteLine("A new client has been added!");
        }
    }
}

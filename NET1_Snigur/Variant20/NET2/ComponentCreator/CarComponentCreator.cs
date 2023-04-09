using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2.ComponentCreator
{
    class CarComponentCreator : IComponentCreator
    {
        public void NewComponent()
        {
            Console.WriteLine("Creating new car...");

            Console.Write("Set car brand: ");
            string brand = Console.ReadLine();

            Console.Write("Set car name: ");
            string name = Console.ReadLine();

            Console.Write("Set car class (A, B, C, D, E, S, J, M): ");
            char carClass = Console.ReadLine()[0];

            Console.Write("Set car price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Set car year: ");
            int year = int.Parse(Console.ReadLine());

            Data.Cars.Add(new Car(Data.Cars.Count, brand, name, (Car.CarClasses)carClass, price, year));
            Console.WriteLine("A new car has been added!");
        }
    }
}

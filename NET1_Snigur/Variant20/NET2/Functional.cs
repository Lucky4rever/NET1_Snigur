using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DOTNET.Variant20.NET2
{
    public sealed class TaskNumber : GeneralTaskNumber
    {
        public static readonly GeneralTaskNumber PrintFiles = new TaskNumber(0);
        public static readonly GeneralTaskNumber Task1 = new TaskNumber(1);
        public static readonly GeneralTaskNumber Task2 = new TaskNumber(2);
        public static readonly GeneralTaskNumber Task3 = new TaskNumber(3);
        public static readonly GeneralTaskNumber Task4 = new TaskNumber(4);
        public static readonly GeneralTaskNumber Task5 = new TaskNumber(5);
        public static readonly GeneralTaskNumber Task6 = new TaskNumber(6);
        public static readonly GeneralTaskNumber Task7 = new TaskNumber(7);
        public static readonly GeneralTaskNumber Task8 = new TaskNumber(8);
        public static readonly GeneralTaskNumber Task9 = new TaskNumber(9);
        public static readonly GeneralTaskNumber Task10 = new TaskNumber(10);
        public static readonly GeneralTaskNumber Task11 = new TaskNumber(11);
        public static readonly GeneralTaskNumber Task12 = new TaskNumber(12);
        public static readonly GeneralTaskNumber Task13 = new TaskNumber(13);
        public static readonly GeneralTaskNumber Task14 = new TaskNumber(14);
        public static readonly GeneralTaskNumber Task15 = new TaskNumber(15);

        public static Dictionary<int, GeneralTaskNumber> TaskNumberMap = new Dictionary<int, GeneralTaskNumber>
        {
            {1, Task1 }, {2, Task2 }, {3, Task3 }, {4, Task4 }, {5, Task5 },
            {6, Task6 }, {7, Task7 }, {8, Task8 }, {9, Task9 }, {10, Task10 },
            {11, Task11 }, {12, Task12 }, {13, Task13 }, {14, Task14 }, {15, Task15 },
            {100, PrintFiles }
        };

        private TaskNumber(int value) : base(value) { }
        public static new GeneralTaskNumber GetGeneralTaskNumber(int key)
        {
            foreach (var task in TaskNumberMap)
            {
                if (task.Key == key)
                {
                    return task.Value;
                }
            }
            return Empty;
        }
    }

    class Functional
    {
        public Dictionary<GeneralTaskNumber, Action> TaskMap;

        public Functional()
        {
            TaskMap = new Dictionary<GeneralTaskNumber, Action>
            {
                [TaskNumber.PrintFiles] = PrintFiles,
                [TaskNumber.Task1] = UniqueCarBrand,
                [TaskNumber.Task2] = delegate () { CovenantsAfter(new DateTime(2023, 1, 1)); },
                [TaskNumber.Task3] = ClientsWithCovenants,
                [TaskNumber.Task4] = SortedClients,
                [TaskNumber.Task5] = delegate () { PhoneNumberContains("096"); },
                [TaskNumber.Task6] = SortedCars,
                [TaskNumber.Task7] = delegate () { SortedXClassCars(Car.CarClasses.B); },
                [TaskNumber.Task8] = delegate () { ContractWithCar("Audi", "A6"); },
                [TaskNumber.Task9] = delegate () { ClientWithCar("Audi", "A6"); },
                [TaskNumber.Task10] = NeverTakenCars,
                [TaskNumber.Task11] = ClientsWithOver2Request,
                [TaskNumber.Task12] = SortedClientsWithMoreThen1Car,
                [TaskNumber.Task13] = UniqueClientWithCarsNames,
                [TaskNumber.Task14] = AllNames,
                [TaskNumber.Task15] = SortedClientsWithNewAndLuxuryCars
            };
        }

        //=======================Start of the task=======================

        public void PrintFiles()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Print all files using LINQ to XML.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("clients.xml");

            var clients = from c in doc.Descendants("client")
                          select new Client(
                              (int)c.Element("id"),
                              (string)c.Element("name"),
                              (string)c.Element("address"),
                              (string)c.Element("phone")
                          );

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine();

            doc = XDocument.Load("cars.xml");

            var cars = from c in doc.Descendants("car")
                       select new Car(
                           (int)c.Element("id"),
                           (string)c.Element("brand"),
                           (string)c.Element("name"),
                           (Car.CarClasses)(int)c.Element("car-class"),
                           (decimal)c.Element("price"),
                           (int)c.Element("year")
                       );
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            Console.WriteLine();

            doc = XDocument.Load("covenants.xml");

            var covenants = from c in doc.Descendants("covenant")
                       select new Covenant(
                           int.Parse(c.Element("id").Value),
                           int.Parse(c.Element("client-id").Value),
                           int.Parse(c.Element("car-id").Value),
                           DateTime.Parse(c.Element("issue-date").Value),
                           DateTime.Parse(c.Element("return-date").Value)
                       );
            foreach (var covenant in covenants)
            {
                Console.WriteLine(covenant);
            }

            Console.WriteLine();
        }

        public void UniqueCarBrand()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Print unique car brands.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("cars.xml");

            var brands = doc.Descendants("car").Select(c => c.Element("brand").Value).Distinct();

            foreach (var brand in brands)
            {
                Console.WriteLine(brand);
            }

            Console.WriteLine();
        }

        public void CovenantsAfter(DateTime date)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Print all deal ids dated from date and later.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("covenants.xml");
            var covenants = doc.Descendants("covenant")
                           .Where(c => DateTime.Parse(c.Element("issue-date").Value) >= date)
                           .Select(c => new { c.Element("id").Value });

            foreach (var covenant in covenants)
            {
                Console.WriteLine(covenant);
            }

            Console.WriteLine();
        }

        public void ClientsWithCovenants()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3. Print all clients who took cars.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("clients.xml");

            var clients = from c in doc.Descendants("client")
                          where (from cov in XDocument.Load("covenants.xml").Descendants("covenant")
                                 where (int)c.Element("id") == (int)cov.Element("client-id")
                                 select cov).Any()
                          select new
                          {
                              Id = (int)c.Element("id"),
                              Name = (string)c.Element("name"),
                              Address = (string)c.Element("address"),
                              Phone = (string)c.Element("phone")
                          };

            foreach (var c in clients)
            {
                Console.WriteLine($"Id: {c.Id}, Name: {c.Name}, Address: {c.Address}, Phone: {c.Phone}");
            }

            Console.WriteLine();
        }

        public void SortedClients()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. Print all clients sorted alphabetically.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("clients.xml");

            var clients = doc.Descendants("client")
                            .OrderBy(client => client.Element("name").Value)
                            .Select(client => new
                            {
                                Id = client.Element("id").Value,
                                Name = client.Element("name").Value,
                                Address = client.Element("address").Value,
                                Phone = client.Element("phone").Value
                            });

            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} {client.Name} {client.Address} {client.Phone}");
            }

            Console.WriteLine();
        }

        public void PhoneNumberContains(string property)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"5. Print all customers who have a phone number containing {property}.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("clients.xml");

            var clients = doc.Descendants("client")
                            .Where(client => client.Element("phone").Value.Contains(property))
                            .Select(client => new
                            {
                                Id = client.Element("id").Value,
                                Name = client.Element("name").Value,
                                Address = client.Element("address").Value,
                                Phone = client.Element("phone").Value
                            });

            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} {client.Name} {client.Address} {client.Phone}");
            }

            Console.WriteLine();
        }

        public void SortedCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Print all car names, sorted by price.");
            Console.ResetColor();

            XDocument doc = XDocument.Load("cars.xml");

            var carsName = doc.Descendants("car")
                            .OrderBy(car => decimal.Parse(car.Element("price").Value))
                            .Select(car => car.Element("name").Value);

            foreach (var carName in carsName)
            {
                Console.WriteLine(carName);
            }

            Console.WriteLine();
        }

        public void SortedXClassCars(Car.CarClasses carClass)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"7. Print all covenants with cars of class {carClass}, sorted by increasing price.");
            Console.ResetColor();

            var XClassCars = XElement.Load("cars.xml").Descendants("car")
                    .Where(x => (int)x.Element("car-class") == (int)carClass)
                    .Select(x => int.Parse(x.Element("id").Value))
                    .ToList();

            var covenants = XElement.Load("covenants.xml").Descendants("covenant")
                            .Where(x => XClassCars.Contains(int.Parse(x.Element("car-id").Value)))
                            .Select(x => new Covenant(int.Parse(x.Element("id").Value),
                                                       int.Parse(x.Element("client-id").Value),
                                                       int.Parse(x.Element("car-id").Value),
                                                       DateTime.Parse(x.Element("issue-date").Value),
                                                       DateTime.Parse(x.Element("return-date").Value)));

            foreach (var covenant in covenants)
            {
                Console.WriteLine(covenant);
            }

            Console.WriteLine();
        }

        public void ContractWithCar(string brand, string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"8. Print a list of all contracts with the car {brand} {name}.");
            Console.ResetColor();

            var car = XElement.Load("cars.xml").Descendants("car")
                    .Where(x => x.Element("brand").Value == brand && x.Element("name").Value == name)
                    .Select(x => int.Parse(x.Element("id").Value))
                    .ToList();

            var covenants = XElement.Load("covenants.xml").Descendants("covenant")
                            .Where(x => car.Contains(int.Parse(x.Element("car-id").Value)))
                            .Select(x => new Covenant(int.Parse(x.Element("id").Value),
                                                       int.Parse(x.Element("client-id").Value),
                                                       int.Parse(x.Element("car-id").Value),
                                                       DateTime.Parse(x.Element("issue-date").Value),
                                                       DateTime.Parse(x.Element("return-date").Value)));

            foreach (var covenant in covenants)
            {
                Console.WriteLine(covenant);
            }

            Console.WriteLine();
        }

        public void ClientWithCar(string brand, string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"9. Print all customers who have orders for {brand} {name}.");
            Console.ResetColor();

            var cars = XElement.Load("cars.xml").Descendants("car")
                    .Where(x => x.Element("brand").Value == brand && x.Element("name").Value == name)
                    .Select(x => int.Parse(x.Element("id").Value))
                    .ToList();

            var clients = XElement.Load("covenants.xml").Descendants("covenant")
                            .Where(x => cars.Contains(int.Parse(x.Element("car-id").Value)))
                            .Join(XElement.Load("clients.xml").Descendants("client"),
                              covenant => (int)covenant.Element("client-id"),
                              client => (int)client.Element("id"),
                              (covenant, client) => new {
                                  client,
                                  covenant
                              }).Select(x => x.client.Element("name").Value);

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine();
        }

        public void NeverTakenCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("10. Print all cars that have not been registered for rental.");
            Console.ResetColor();

            XDocument cars = XDocument.Load("cars.xml");
            XDocument covenants = XDocument.Load("covenants.xml");

            var query = from car in cars.Descendants("car")
                        join covenant in covenants.Descendants("covenant")
                            on (int)car.Element("id") equals (int)covenant.Element("car-id") into covenantsGroup
                        where !covenantsGroup.Any()
                        select new { Brand = car.Element("brand").Value, Name = car.Element("name").Value };

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Brand} {car.Name}");
            }

            Console.WriteLine();
        }

        public void ClientsWithOver2Request()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("11. Print all customers who have more than two orders.");
            Console.ResetColor();

            XDocument covenants = XDocument.Load("covenants.xml");
            XDocument clients = XDocument.Load("clients.xml");

            var query = from covenant in covenants.Descendants("covenant")
                        group covenant by (int)covenant.Element("client-id") into covenantsGroup
                        where covenantsGroup.Count() > 2
                        join client in clients.Descendants("client")
                            on covenantsGroup.Key equals (int)client.Element("id")
                        select new { Name = client.Element("name").Value };

            foreach (var client in query)
            {
                Console.WriteLine(client.Name);
            }

            Console.WriteLine();
        }

        public void SortedClientsWithMoreThen1Car()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("12. Get a list of customers who have rented at least one car and sort them in ascending order of name.");
            Console.ResetColor();

            XDocument clients = XDocument.Load("clients.xml");
            XDocument cars = XDocument.Load("cars.xml");
            XDocument covenants = XDocument.Load("covenants.xml");

            var clientsWithCars = clients.Descendants("client")
                                         .Select(c => new {
                                              Id = c.Element("id").Value,
                                              Name = c.Element("name").Value,
                                              Cars = covenants.Descendants("covenant")
                                         .Where(x => x.Element("client-id").Value == c.Element("id").Value)
                                         .Join(cars.Descendants("car"),
                                              cov => cov.Element("car-id").Value,
                                              car => car.Element("id").Value,
                                              (cov, car) => new {
                                                  Brand = car.Element("brand").Value,
                                                  Name = car.Element("name").Value
                                              })
                                         });

            foreach (var clientWithCars in clientsWithCars)
            {
                Console.WriteLine(clientWithCars.Name);
                foreach (var car in clientWithCars.Cars)
                {
                    Console.WriteLine($" - {car.Brand} {car.Name}");
                }
            }

            Console.WriteLine();
        }

        public void UniqueClientWithCarsNames()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("13. Print a list of all covenant numbers with the names of the customers who made them and the date of deal.");
            Console.ResetColor();

            XDocument covenants = XDocument.Load("covenants.xml");
            XDocument clients = XDocument.Load("clients.xml");

            var uniqueClients = clients.Descendants("client")
                                        .Join(covenants.Descendants("covenant"),
                                              client => client.Element("id").Value,
                                              covenant => covenant.Element("client-id").Value,
                                              (client, covenant) => new
                                              {
                                                  Name = client.Element("name").Value,
                                                  CovenantId = covenant.Element("id").Value,
                                                  Date = DateTime.Parse(covenant.Element("issue-date").Value).ToString("dd.MM.yyyy")
                                              });

            foreach (var client in uniqueClients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine();
        }

        public void AllNames()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("14. Print a list of all customer and car names.");
            Console.ResetColor();

            XDocument cars = XDocument.Load("cars.xml");
            XDocument clients = XDocument.Load("clients.xml");

            var allNames = clients.Descendants("client").Select(x => x.Element("name").Value)
                                        .Union(cars.Descendants("car")
                                        .Select(x => x.Element("brand").Value + " " + x.Element("name").Value));

            foreach (var name in allNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();
        }

        public void SortedClientsWithNewAndLuxuryCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("15. Print all customers who took cars older than 2010 and all customers who took cars of the \"Luxury\" class, and display them in alphabetical order by customer name.");
            Console.ResetColor();

            XDocument covenants = XDocument.Load("covenants.xml");
            XDocument cars = XDocument.Load("cars.xml");
            XDocument clients = XDocument.Load("clients.xml");

            var olderCarsClients = from covenant in covenants.Descendants("covenant")
                                   join car in cars.Descendants("car")
                                   on (int)covenant.Element("car-id") equals (int)car.Element("id")
                                   where (int)car.Element("year") < 2010
                                   select (int)covenant.Element("client-id");

            var luxuryCarsClients = from covenant in covenants.Descendants("covenant")
                                    join car in cars.Descendants("car")
                                    on (int)covenant.Element("car-id") equals (int)car.Element("id")
                                    where (int)car.Element("car-class") == (int)Car.CarClasses.E
                                    select (int)covenant.Element("client-id");

            var allClients = from client in clients.Descendants("client")
                          where olderCarsClients.Concat(luxuryCarsClients).Contains((int)client.Element("id"))
                          orderby (string)client.Element("name")
                          select new Client((int)client.Element("id"), (string)client.Element("name"), (string)client.Element("address"), (string)client.Element("phone"));

            foreach (var client in allClients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine();
        }
    }
}

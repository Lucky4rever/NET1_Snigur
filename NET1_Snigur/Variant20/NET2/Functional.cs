using DOTNET.Variant20.NET1;
using DOTNET.Variant20.NET2.XMLConverter;
using DOTNET.Variant20.NET2.XMLConverter.VariableNames;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Dictionary<GeneralTaskNumber, OutputHelper> TaskMap;

        internal XDocument _docCars = null;
        internal XDocument _docCovenants = null;
        internal XDocument _docClients = null;

        public Functional()
        {
            TaskMap = new Dictionary<GeneralTaskNumber, OutputHelper>
            {
                [TaskNumber.PrintFiles] = new OutputHelper("Print all files using LINQ to XML.", () => { return PrintFiles(); }),
                [TaskNumber.Task1] = new OutputHelper("1. Print unique car brands.", () => { return UniqueCarBrand(); }),
                [TaskNumber.Task2] = new OutputHelper("2. Print all deal ids dated from date and later.", () => { return CovenantsAfter(new DateTime(2023, 1, 1)); }),
                [TaskNumber.Task3] = new OutputHelper("3. Print all clients who took cars.", () => { return ClientsWithCovenants(); }),
                [TaskNumber.Task4] = new OutputHelper("4. Print all clients sorted alphabetically.", () => { return SortedClients(); }),
                [TaskNumber.Task5] = new OutputHelper("5. Print all customers who have a Phone number containing 096.", () => { return PhoneNumberContains("096"); }),
                [TaskNumber.Task6] = new OutputHelper("6. Print all car names, sorted by Price.", () => { return SortedCars(); }),
                [TaskNumber.Task7] = new OutputHelper("7. Print all covenants with cars of class B, sorted by increasing Price.", () => { return SortedXClassCars(Car.CarClasses.B); }),
                [TaskNumber.Task8] = new OutputHelper("8. Print a list of all contracts with the Audi A6.", () => { return ContractWithCar("Audi", "A6"); }),
                [TaskNumber.Task9] = new OutputHelper("9. Print all customers who have orders for Audi A6.", () => { return ClientWithCar("Audi", "A6"); }),
                [TaskNumber.Task10] = new OutputHelper("10. Print all cars that have not been registered for rental.", () => { return NeverTakenCars(); }),
                [TaskNumber.Task11] = new OutputHelper("11. Print all customers who have more than two orders.", () => { return ClientsWithOver2Request(); }),
                [TaskNumber.Task12] = new OutputHelper("12. Get a list of customers who have rented at least one car and sort them in ascending order of Name.", () => { return SortedClientsWithMoreThen1Car(); }),
                [TaskNumber.Task13] = new OutputHelper("13. Print a list of all covenant numbers with the names of the customers who made them and the date of deal.", () => { return UniqueClientWithCarsNames(); }),
                [TaskNumber.Task14] = new OutputHelper("14. Print a list of all customer and car names.", () => { return AllNames(); }),
                [TaskNumber.Task15] = new OutputHelper("15. Print all customers who took cars older than 2010 and all customers who took cars of the \"Luxury\" class, and display them in alphabetical order by customer Name.", () => { return SortedClientsWithNewAndLuxuryCars(); })
            };
        }

        //=======================Start of the task=======================

        //`Для файлу, створеного в п.2 розробити` як мінімум 15 різних запитів, використовуючи різні дії над отриманими даними

        public IEnumerable<object> PrintFiles()
        {
            IEnumerable<object> result = Enumerable.Empty<object>();
            IEnumerable<object> clients = Enumerable.Empty<object>();
            IEnumerable<object> cars = Enumerable.Empty<object>();
            IEnumerable<object> covenants = Enumerable.Empty<object>();

            if (this._docClients != null)
            {
                clients = from c in this._docClients.Root.Elements(ClientVariableNames.BaseName)
                          select new Client(
                              (int)c.Element(ClientVariableNames.Id),
                              (string)c.Element(ClientVariableNames.Name),
                              (string)c.Element(ClientVariableNames.Address),
                              (string)c.Element(ClientVariableNames.Phone)
                          );
            }

            if (this._docCars != null)
            {
                cars = from c in this._docCars.Root.Elements(CarVariableNames.BaseName)
                       select new Car(
                           int.Parse(c.Element(CarVariableNames.Id).Value),
                           c.Element(CarVariableNames.Brand).Value,
                           c.Element(CarVariableNames.Name).Value,
                           (Car.CarClasses)char.Parse(c.Element(CarVariableNames.CarClass).Value),
                           decimal.Parse(c.Element(CarVariableNames.Price).Value),
                           int.Parse(c.Element(CarVariableNames.Year).Value)
                       );
            }

            if (this._docCovenants != null)
            {
                covenants = from c in this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                            select new Covenant(
                                int.Parse(c.Element(CovenantVariableNames.Id).Value),
                                int.Parse(c.Element(CovenantVariableNames.ClientId).Value),
                                int.Parse(c.Element(CovenantVariableNames.CarId).Value),
                                DateTime.Parse(c.Element(CovenantVariableNames.IssueDate).Value),
                                DateTime.Parse(c.Element(CovenantVariableNames.ReturnDate).Value)
                            );
            }

            return clients.Cast<object>()
                          .Concat(cars.Cast<object>())
                          .Concat(covenants.Cast<object>());
        }

        public IEnumerable<object> UniqueCarBrand()
        {
            IEnumerable<object> brands = null;

            if (this._docCars != null)
            {
                brands = this._docCars.Root.Elements(CarVariableNames.BaseName)
                        .Select(c => new { c.Element(CarVariableNames.Brand).Value })
                        .Distinct();
            }

            return brands;
        }

        public IEnumerable<object> CovenantsAfter(DateTime date)
        {
            IEnumerable<object> covenants = null;

            if (this._docCovenants != null)
            {
                covenants = this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                                .Where(c => DateTime.Parse(c.Element(CovenantVariableNames.IssueDate).Value) >= date)
                                .Select(c => new { Id = c.Element(CovenantVariableNames.Id).Value });
            }

            return covenants;
        }

        public IEnumerable<object> ClientsWithCovenants()
        {
            IEnumerable<object> clients = null;

            if (this._docCovenants != null && this._docClients != null)
            {
                clients = this._docClients.Root.Elements(ClientVariableNames.BaseName)
                                .Where(c => this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                                .Any(co => (int)co.Element(CovenantVariableNames.ClientId) == (int)c.Element(ClientVariableNames.Id)))
                                .Select(c => new
                                {
                                    Id = (int)c.Element(ClientVariableNames.Id),
                                    Name = (string)c.Element(ClientVariableNames.Name),
                                    Address = (string)c.Element(ClientVariableNames.Address),
                                    Phone = (string)c.Element(ClientVariableNames.Phone)
                                });
            }

            return clients;
        }

        public IEnumerable<object> SortedClients()
        {
            IEnumerable<object> clients = null;

            if (this._docClients != null)
            {
                clients = this._docClients.Root.Elements(ClientVariableNames.BaseName)
                                .OrderBy(Client => Client.Element(ClientVariableNames.Name).Value)
                                .Select(Client => new
                                {
                                    Id = Client.Element(ClientVariableNames.Id).Value,
                                    Name = Client.Element(ClientVariableNames.Name).Value,
                                    Address = Client.Element(ClientVariableNames.Address).Value,
                                    Phone = Client.Element(ClientVariableNames.Phone).Value
                                });
            }

            return clients;
        }

        public IEnumerable<object> PhoneNumberContains(string property)
        {
            IEnumerable<object> clients = null;

            if (this._docClients != null)
            {
                clients = this._docClients.Root.Elements(ClientVariableNames.BaseName)
                        .Where(Client => Client.Element(ClientVariableNames.Phone).Value.Contains(property))
                        .Select(Client => new
                        {
                            Id = Client.Element(ClientVariableNames.Id).Value,
                            Name = Client.Element(ClientVariableNames.Name).Value,
                            Address = Client.Element(ClientVariableNames.Address).Value,
                            Phone = Client.Element(ClientVariableNames.Phone).Value
                        });
            }

            return clients;
        }

        public IEnumerable<object> SortedCars()
        {
            IEnumerable<object> carsName = null;

            if (this._docCars != null)
            {
                carsName = this._docCars.Root.Elements(CarVariableNames.BaseName)
                            .OrderBy(car => decimal.Parse(car.Element(CarVariableNames.Price).Value))
                            .Select(car => new { Name = car.Element(CarVariableNames.Name).Value });
            }

            return carsName;
        }

        public IEnumerable<object> SortedXClassCars(Car.CarClasses carClass)
        {
            IEnumerable<object> covenants = null;

            if (this._docCars != null && this._docCovenants != null)
            {
                var XClassCars = this._docCars.Root.Elements(CarVariableNames.BaseName)
                            .Where(x => char.Parse(x.Element(CarVariableNames.CarClass).Value) == (int)carClass)
                            .Select(x => int.Parse(x.Element(CarVariableNames.Id).Value))
                            .ToList();

                covenants = this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                            .Where(x => XClassCars.Contains(int.Parse(x.Element(CovenantVariableNames.CarId).Value)))
                            .Select(x => new Covenant(int.Parse(x.Element(CovenantVariableNames.Id).Value),
                                                        int.Parse(x.Element(CovenantVariableNames.ClientId).Value),
                                                        int.Parse(x.Element(CovenantVariableNames.CarId).Value),
                                                        DateTime.Parse(x.Element(CovenantVariableNames.IssueDate).Value),
                                                        DateTime.Parse(x.Element(CovenantVariableNames.ReturnDate).Value)));
            }

            return covenants;
        }

        public IEnumerable<object> ContractWithCar(string Brand, string Name)
        {
            IEnumerable<object> covenants = null;

            if (this._docCars != null && this._docCovenants != null)
            {
                var car = this._docCars.Descendants(CarVariableNames.BaseName)
                    .Where(x => x.Element(CarVariableNames.Brand).Value == Brand && x.Element(CarVariableNames.Name).Value == Name)
                    .Select(x => int.Parse(x.Element(CarVariableNames.Id).Value))
                    .ToList();

                covenants = this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                        .Where(x => car.Contains(int.Parse(x.Element(CovenantVariableNames.CarId).Value)))
                        .Select(x => new Covenant(int.Parse(x.Element(CovenantVariableNames.Id).Value),
                                                    int.Parse(x.Element(CovenantVariableNames.ClientId).Value),
                                                    int.Parse(x.Element(CovenantVariableNames.CarId).Value),
                                                    DateTime.Parse(x.Element(CovenantVariableNames.IssueDate).Value),
                                                    DateTime.Parse(x.Element(CovenantVariableNames.ReturnDate).Value)));
            }

            return covenants;
        }

        public IEnumerable<object> ClientWithCar(string Brand, string Name)
        {
            IEnumerable<object> clients = null;

            if (this._docCars != null && this._docCovenants != null && this._docClients != null)
            {
                var cars = this._docCars.Root.Elements(CarVariableNames.BaseName)
                        .Where(x => x.Element(CarVariableNames.Brand).Value == Brand && x.Element(CarVariableNames.Name).Value == Name)
                        .Select(x => int.Parse(x.Element(CarVariableNames.Id).Value))
                        .ToList();

                clients = this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                        .Where(x => cars.Contains(int.Parse(x.Element(CovenantVariableNames.CarId).Value)))
                        .Join(this._docClients.Descendants(ClientVariableNames.BaseName),
                            covenant => (int)covenant.Element(CovenantVariableNames.ClientId),
                            Client => (int)Client.Element(ClientVariableNames.Id),
                            (covenant, Client) => new { Client })
                        .Select(x => x.Client.Element(ClientVariableNames.Name).Value);
            }

            return clients;
        }

        public IEnumerable<object> NeverTakenCars()
        {
            IEnumerable<object> cars = null;

            if (this._docCars != null && this._docCovenants != null)
            {
                cars = from car in this._docCars.Root.Elements(CarVariableNames.BaseName)
                           join covenant in this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                               on (int)car.Element(CarVariableNames.Id) equals (int)covenant.Element(CovenantVariableNames.CarId) into covenantsGroup
                           where !covenantsGroup.Any()
                           select new { Brand = car.Element(CarVariableNames.Brand).Value, Name = car.Element(CarVariableNames.Name).Value };
            }

            return cars;
        }

        public IEnumerable<object> ClientsWithOver2Request()
        {
            IEnumerable<object> clients = null;

            if (this._docCovenants != null && this._docClients != null)
            {
                clients = from covenant in this._docCovenants.Root.Elements(CovenantVariableNames.BaseName)
                              group covenant by (int)covenant.Element(CovenantVariableNames.ClientId) into covenantsGroup
                              where covenantsGroup.Count() > 2
                              join Client in this._docClients.Root.Elements(ClientVariableNames.BaseName)
                                  on covenantsGroup.Key equals (int)Client.Element(ClientVariableNames.Id)
                              select new { Name = Client.Element(ClientVariableNames.Name).Value };
            }

            return clients;
        }

        public IEnumerable<object> SortedClientsWithMoreThen1Car()
        {
            IEnumerable<object> clientsWithCars = null;

            if (this._docCovenants != null && this._docCars != null && this._docClients != null)
            {
                clientsWithCars = this._docClients.Descendants(ClientVariableNames.BaseName)
                    .Select(c => new
                    {
                        Id = c.Element(ClientVariableNames.Id).Value,
                        Name = c.Element(ClientVariableNames.Name).Value,
                        Cars = this._docCovenants.Descendants(CovenantVariableNames.BaseName)
                                .Where(x => x.Element(CovenantVariableNames.ClientId).Value == c.Element(ClientVariableNames.Id).Value)
                                .Join(this._docCars.Descendants(CarVariableNames.BaseName),
                                    cov => cov.Element(CovenantVariableNames.CarId).Value,
                                    car => car.Element(CarVariableNames.Id).Value,
                                    (cov, car) => new
                                    {
                                        Brand = car.Element(CarVariableNames.Brand).Value,
                                        Name = car.Element(CarVariableNames.Name).Value
                                    })
                    });
            }

            return clientsWithCars;
        }

        public IEnumerable<object> UniqueClientWithCarsNames()
        {
            if (this._docClients != null && this._docCovenants != null)
            {
                var uniqueClients = this._docClients.Descendants(ClientVariableNames.BaseName)
                    .Join(this._docCovenants.Descendants(CovenantVariableNames.BaseName),
                            Client => Client.Element(ClientVariableNames.Id).Value,
                            covenant => covenant.Element(CovenantVariableNames.ClientId).Value,
                            (Client, covenant) => new
                            {
                                Name = Client.Element(ClientVariableNames.Name).Value,
                                CovenantId = covenant.Element(CovenantVariableNames.Id).Value,
                                Date = DateTime.Parse(covenant.Element(CovenantVariableNames.IssueDate).Value).ToString("dd.MM.yyyy")
                            });
                return uniqueClients;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> AllNames()
        {
            IEnumerable<object> allNames = null;

            if (this._docClients != null && this._docCars != null)
            {
                allNames = this._docClients.Descendants(ClientVariableNames.BaseName)
                        .Select(x => x.Element(ClientVariableNames.Name).Value)
                        .Union(this._docCars.Descendants(CarVariableNames.BaseName)
                        .Select(x => x.Element(CarVariableNames.Brand).Value + " " + x.Element(CarVariableNames.Name).Value));
            }

            return allNames;
        }

        public IEnumerable<object> SortedClientsWithNewAndLuxuryCars()
        {
            IEnumerable<object> allClients = null;

            if (this._docClients != null && this._docCars != null && this._docCovenants != null)
            {
                var olderCarsClients = from covenant in this._docCovenants.Descendants(CovenantVariableNames.BaseName)
                                       join car in this._docCars.Descendants(CarVariableNames.BaseName)
                                       on (int)covenant.Element(CovenantVariableNames.CarId) equals (int)car.Element(CarVariableNames.Id)
                                       where (int)car.Element(CarVariableNames.Year) < 2010
                                       select (int)covenant.Element(CovenantVariableNames.ClientId);

                var luxuryCarsClients = from covenant in this._docCovenants.Descendants(CovenantVariableNames.BaseName)
                                        join car in this._docCars.Descendants(CarVariableNames.BaseName)
                                        on (int)covenant.Element(CovenantVariableNames.CarId) equals (int)car.Element(CarVariableNames.Id)
                                        where (int)char.Parse(car.Element(CarVariableNames.CarClass).Value) == (int)Car.CarClasses.E
                                        select (int)covenant.Element(CovenantVariableNames.ClientId);

                allClients = from Client in this._docClients.Descendants(ClientVariableNames.BaseName)
                                 where olderCarsClients.Concat(luxuryCarsClients).Contains((int)Client.Element(ClientVariableNames.Id))
                                 orderby (string)Client.Element(ClientVariableNames.Name)
                                 select new Client(
                                     (int)Client.Element(ClientVariableNames.Id), 
                                     (string)Client.Element(ClientVariableNames.Name), 
                                     (string)Client.Element(ClientVariableNames.Address), 
                                     (string)Client.Element(ClientVariableNames.Phone)
                                 );
            }

            return allClients;
        }
    }
}

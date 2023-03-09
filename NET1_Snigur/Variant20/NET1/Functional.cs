using System;
using System.Collections.Generic;
using System.Linq;

namespace NET1_Snigur.Variant20.NET1
{
    class Functional
    {   
        public enum TaskNumber
        {
            Task1, Task2, Task3, Task4, Task5, 
            Task6, Task7, Task8, Task9, Task10,
            Task11, Task12, Task13, Task14, Task15, 
            Task16, Task17, Task18, Task19, Task20
        }

        public Dictionary<TaskNumber, Action> TaskMap;

        public Functional()
        {
            TaskMap = new Dictionary<TaskNumber, Action>
            {
                [TaskNumber.Task1] = Cars,
                [TaskNumber.Task2] = CovenantsAsObjects,
                [TaskNumber.Task3] = delegate () { GetCarsByClass(Car.CarClasses.B); },
                [TaskNumber.Task4] = AvailableCars,
                [TaskNumber.Task5] = Profit,
                [TaskNumber.Task6] = Names,
                [TaskNumber.Task7] = Requests,
                [TaskNumber.Task8] = NeverRenderedCars,
                [TaskNumber.Task9] = ClientsWithCars,
                [TaskNumber.Task10] = FrequentClients,
                [TaskNumber.Task11] = IncreasingValue,
                [TaskNumber.Task12] = CarsWithRentalCost,
                [TaskNumber.Task13] = delegate () { RequestsInPeriod(new DateTime(2023, 03, 1), new DateTime(2023, 03, 5)); },
                [TaskNumber.Task14] = Cheapest,
                [TaskNumber.Task15] = AverageCost,
                [TaskNumber.Task16] = delegate () { MoreThanCertain(new Money<decimal>(5000m)); },
                [TaskNumber.Task17] = PhoneByComma,
                [TaskNumber.Task18] = ClientsWhoСontact,
                [TaskNumber.Task19] = CarsConcate,
                [TaskNumber.Task20] = NeverRentedCars
            };
        }

        //=======================Start of the task=======================

        public void Cars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Print all cars.");
            Console.ResetColor();

            var answer = from car in Data.Cars
                         select car;

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public void CovenantsAsObjects()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Print all covenants as objects.");
            Console.ResetColor();

            //TODO return instatces of classes
            var answer = from covenant in Data.Covenants
                         select new { covenant.Id, covenant.IssueDate, covenant.ReturnDate };

            foreach (var covenant in answer)
            {
                Console.WriteLine(covenant);
            }
            Console.WriteLine();
        }

        //TODO move class as a argument method should be universal 

        //public void GetCarsByClass(string class)
        //public void GetCarsByClass(CarClassEnum class) // B = 68 -> (ASCII)68-> 'B' -> move to another one navigation dictionary table and use 3 normal form 
        public void GetCarsByClass(Car.CarClasses carClass)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"3. Print all {(char)(int)carClass}-class cars.");
            Console.ResetColor();

            var answer = from car in Data.Cars
                         where car.CarClass == carClass
                         select car;

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        //ByDate DateTime.Today as parameter 
        public void AvailableCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. Print all cars that are currently available for rental today.");
            Console.ResetColor();

            var answer = from covenant in Data.Covenants
                         join car in Data.Cars on covenant.CarId equals car.Id
                         where covenant.ReturnDate < DateTime.Today
                         select new { car.Brand, car.Name, car.Year };

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public void Profit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Print profit.");
            Console.ResetColor();

            decimal fullPrice = Data.Covenants.Sum(p => p.Price.Amount + p.Deposit.Amount);
            //TODO use agregate function 
            var prices = from covenant in Data.Covenants
                         select covenant.Price.Amount;

            //Data.Covenants.Sum(p => p.Price.Amount)
            //TODO use sum
            foreach (var price in prices)
            {
                fullPrice += price;
            }

            prices = from covenant in Data.Covenants
                     where covenant.ReturnDate >= DateTime.Today
                     select covenant.Deposit.Amount;

            foreach (var price in prices)
            {
                fullPrice += price;
            }

            Console.WriteLine(fullPrice);
            Console.WriteLine();
        }

        public void Names()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Print all names.");
            Console.ResetColor();

            var answer = from name in (from car in Data.Cars
                                       select car.Name).Union(
                         from client in Data.Clients
                         select client.Name)
                         orderby name
                         select name;

            foreach (var name in answer)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        public void Requests()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("7. Print all clients with their requests to the rental.");
            Console.ResetColor();

            var answer = from client in Data.Clients
                         join covenant in Data.Covenants on client.Id equals covenant.ClientId
                         select new { client.Name, client.Address, client.Phone, covenant.IssueDate, covenant.ReturnDate.Date };

            foreach (var name in answer)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        public void NeverRenderedCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("8. Print all amounts received by the company and the clients who deposited them.");
            Console.ResetColor();

            var answer = from covenant in Data.Covenants
                         join client in Data.Clients on new { Id = covenant.ClientId }
                         equals new { client.Id }
                         orderby covenant.Price.Amount
                         select new { covenant.Price.Amount, client.Name, Date = covenant.IssueDate };

            foreach (var client in answer)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine();
        }

        public void ClientsWithCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("9. Print all clients with the cars they have taken.");
            Console.ResetColor();

            var answer = from covenant in Data.Covenants
                         join client in Data.Clients on covenant.ClientCovenant.ClientId equals client.Id
                         join car in Data.Cars on covenant.CarCovenant.CarId equals car.Id
                         select new { client.Name, car };

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public void FrequentClients()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("10. Print all clients who have contacted the rental point more than once.");
            Console.ResetColor();

            var answer = from covenant in Data.Covenants
                         join client in Data.Clients on covenant.ClientCovenant.ClientId equals client.Id
                         group covenant by covenant.ClientId into rentalGroup
                         where rentalGroup.Count() > 1
                         select Data.Clients.FirstOrDefault(c => c.Id == rentalGroup.Key);

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public void IncreasingValue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("11. Print all cars in order of increasing value.");
            Console.ResetColor();

            var answer = Data.Cars.OrderBy(car => car.Price.Amount);

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public void CarsWithRentalCost()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("12. Print all cars with their rental cost.");
            Console.ResetColor();

            var answer = Data.Covenants
                .Join(Data.Cars, covenant => covenant.CarId, car => car.Id,
                (covenant, car) => new { Covenant = covenant, Car = car } )
                .Select((CarCovenant) => new { 
                    CarCovenant.Car.Brand,
                    CarCovenant.Car.Name, 
                    Price = CarCovenant.Covenant.Price.Amount } );

            foreach (var car in answer)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();
        }

        public void RequestsInPeriod(DateTime startDate, DateTime endDate)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("13. Print number of requests made to the rental point for a certain period of time.");
            Console.ResetColor();

            var answer = Data.Covenants.Where(covenant => covenant.IssueDate >= startDate && covenant.ReturnDate <= endDate).Count();

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void Cheapest()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("14. Print cheapest car.");
            Console.ResetColor();

            Car answer = null;
            if (Data.Cars.Count > 0)
            {
                var MaxPrise = Data.Cars.Max(car => car.Price.Amount);
                answer = Data.Cars.FirstOrDefault(car => car.Price.Amount == MaxPrise);
            }

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void AverageCost()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("15. Print the average cost of a car.");
            Console.ResetColor();

            float answer = 0;
            if (Data.Cars.Count > 0)
            {
                answer = Data.Cars.Average(car => (float)car.Price.Amount);
            }

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void MoreThanCertain(Money<decimal> minRentalPrice)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("16. Print all clients who have rented Data.Cars worth more than a certain amount.");
            Console.ResetColor();

            var answer = Data.Clients.Join(Data.Covenants, client => client.Id, covenant => covenant.ClientId,
                    (client, covenant) => new { Client = client, Covenant = covenant })
                    .Where(clientCovenant => clientCovenant.Covenant.Price.Amount > minRentalPrice.Amount)
                    .Select(clientCovenant => clientCovenant.Client);

            foreach (var client in answer)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine();
        }

        public void PhoneByComma()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("17. Print list of client's phones, joined by a comma.");
            Console.ResetColor();

            var answer = "none";
            if (Data.Clients.Count > 0)
            {
                answer = Data.Clients.Select(client => client.Phone).Aggregate((phone1, phone2) => phone1 + ", " + phone2);
            }

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void ClientsWhoСontact()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("18. Print all clients and their requests, excluding clients who did not contact the rental office.");
            Console.ResetColor();

            var answer = Data.Clients.GroupJoin(Data.Covenants, client => client.Id, covenant => covenant.ClientId,
                (client, Covenants) => new { Client = client, Data.Covenants })
                .Where(clientCovenants => clientCovenants.Covenants.Any())
                .Select(clientCovenants => new { clientCovenants.Client, Covenants = clientCovenants.Covenants.OrderBy(date => date.IssueDate) });

            foreach (var client in answer)
            {
                Console.WriteLine(client.Client);
                foreach (var covenant in client.Covenants)
                {
                    Console.WriteLine($" - {covenant}");
                }
            }
            Console.WriteLine();
        }

        public void CarsConcate()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("19. Print all car names by concatenating their parts.");
            Console.ResetColor();

            var answer = Data.Cars.Select(car => car.Brand.Concat(car.Name.Concat(car.Year.ToString())));

            foreach (var car in answer)
            {
                foreach (var c in car)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void NeverRentedCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("20. Print all cars that have never been rented.");
            Console.ResetColor();

            var answer = Data.Cars.GroupJoin(Data.Covenants, car => car.Id, covenant => covenant.CarId,
                (car, Covenants) => new { Car = car, Data.Covenants })
                .Where(clientCovenants => !clientCovenants.Covenants.Any());

            foreach (var car in answer)
            {
                Console.WriteLine(car.Car);
            }
            Console.WriteLine();
        }
    }
}

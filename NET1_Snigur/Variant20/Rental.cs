using System;
using System.Collections.Generic;
using System.Linq;

namespace NET1_Snigur.Variant20
{
    class Rental : IFunctional
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Covenant> covenants = new List<Covenant>();
        public List<Car> cars = new List<Car>();
        public List<Client> clients = new List<Client>();
        public Rental SetName(string name)
        {
            this.name = name;
            return this;
        }
        public Rental()
        {
            NET1.covenants.ForEach(covenant => { NewCovenant(covenant); });
        }
        public Rental SetCars(List<Car> cars)
        {
            this.cars = cars;
            return this;
        }
        public Rental SetClients(List<Client> clients)
        {
            this.clients = clients;
            return this;
        }

        public void NewCovenant(Covenant covenant)
        {
            bool isFree = true;
            foreach (var thisCovenant in covenants)
            {
                if (thisCovenant.carId == covenant.carId)
                    if (thisCovenant.returnDate >= covenant.issueDate)
                    {
                        isFree = false;
                        break;
                    }
            }
            if (isFree)
            {
                covenants.Add(covenant);
            }
        }

        //=======================Start of the task=======================

        public void Cars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Print all cars.");
            Console.ResetColor();

            var answer = from car in cars
                            select car;
            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void ClientsAsObjects()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Print all covenants as objects.");
            Console.ResetColor();

            var answer = from covenant in covenants
                         select new { covenant = covenant.ToString() };
            foreach (var covenant in answer)
                Console.WriteLine(covenant);
            Console.WriteLine();
        }

        public void BClassCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3. Print all B-class cars.");
            Console.ResetColor();

            var answer = from car in cars
                         where car.carClass == 'B'
                         select car;
            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void AvailableCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. Print all cars that are currently available for rental today.");
            Console.ResetColor();

            var answer = from covenant in covenants
                         where covenant.returnDate < DateTime.Today
                         select new { covenant.car.car };
            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void Profit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Print profit.");
            Console.ResetColor();

            float fullPrice = 0;
            var prices = from covenant in covenants
                         select covenant.price;
            foreach (var price in prices)
                fullPrice += price;

            prices = from covenant in covenants
                     where covenant.returnDate >= DateTime.Today
                     select covenant.deposit;
            foreach (var price in prices)
                fullPrice += price;

            Console.WriteLine(fullPrice);
            Console.WriteLine();
        }

        public void Names()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Print all names.");
            Console.ResetColor();

            var answer = from name in (from car in cars
                         select car.name).Union(
                         from client in clients
                         select client.name)
                         orderby name
                         select name;
            foreach (var name in answer)
                Console.WriteLine(name);
            Console.WriteLine();
        }

        public void Requests()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("7. Print all clients with their requests to the rental.");
            Console.ResetColor();

            var answer = from client in clients
                         join covenant in covenants on client.id equals covenant.clientId
                         select new { client.name, client.address, client.phone, covenant.issueDate, covenant.returnDate.Date };
            foreach (var name in answer)
                Console.WriteLine(name);
            Console.WriteLine();
        }

        public void NeverRenderedCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("8. Print all amounts received by the company and the clients who deposited them.");
            Console.ResetColor();

            var answer = from covenant in covenants
                         join client in clients on new { id = covenant.clientId, covenant.client.client }
                         equals new { id = client.id, client }
                         orderby covenant.price
                         select new { covenant.price, client.name, Date = covenant.issueDate };
            foreach (var client in answer)
                Console.WriteLine(client);
            Console.WriteLine();
        }

        public void ClientsWithCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("9. Print all clients with the cars they have taken.");
            Console.ResetColor();

            var answer = from covenant in covenants
                         join client in clients on covenant.client.clientId equals client.id
                         join car in cars on covenant.car.carId equals car.id
                         select new { client.name, car };
            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void FrequentClients()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("10. Print all clients who have contacted the rental point more than once.");
            Console.ResetColor();

            var answer = from covenant in covenants
                         join client in clients on covenant.client.clientId equals client.id
                         group covenant by covenant.clientId into rentalGroup
                         where rentalGroup.Count() > 1
                         select clients.FirstOrDefault(c => c.id == rentalGroup.Key);
            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void IncreasingValue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("11. Print all cars in order of increasing value.");
            Console.ResetColor();

            var answer = cars.OrderBy(car => car.price);

            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void CarsWithRentalCost()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("12. Print all cars with their rental cost.");
            Console.ResetColor();

            var answer = covenants.Select(covenant => new { covenant.car.car.brand, covenant.car.car.name, covenant.price });

            foreach (var car in answer)
                Console.WriteLine(car);
            Console.WriteLine();
        }

        public void RequestsInPeriod(DateTime startDate, DateTime endDate)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("13. Print number of requests made to the rental point for a certain period of time.");
            Console.ResetColor();

            var answer = covenants.Where(covenant => covenant.issueDate >= startDate && covenant.returnDate <= endDate).Count();

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void Cheapest()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("14. Print cheapest car.");
            Console.ResetColor();

            Car answer = null;
            if (cars.Count > 0)
            {
                var MaxPrise = cars.Max(car => car.price);
                answer = cars.FirstOrDefault(car => car.price == MaxPrise);
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
            if (cars.Count > 0)
            {
                answer = cars.Average(car => car.price);
            }

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void MoreThanCertain(float minRentalPrice)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("16. Print all clients who have rented cars worth more than a certain amount.");
            Console.ResetColor();

            var answer = clients.Join(covenants, client => client.id, covenant => covenant.clientId, 
                    (client, covenant) => new { Client = client, Covenant = covenant })
                    .Where(clientCovenant => clientCovenant.Covenant.price > minRentalPrice)
                    .Select(clientCovenant => clientCovenant.Client);

            foreach (var client in answer)
                Console.WriteLine(client);
            Console.WriteLine();
        }

        public void PhoneByComma()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("17. Print list of their phones, joined by a comma.");
            Console.ResetColor();

            var answer = "none";
            if (clients.Count > 0)
                answer = clients.Select(client => client.phone).Aggregate((phone1, phone2) => phone1 + ", " + phone2);

            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public void ClientsWhoСontact()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("18. Print all clients and their requests, excluding clients who did not contact the rental office.");
            Console.ResetColor();

            var answer = clients.GroupJoin(covenants, client => client.id, covenant => covenant.clientId, 
                (client, covenants) => new { Client = client, Covenants = covenants })
                .Where(clientCovenants => clientCovenants.Covenants.Any())
                .Select(clientCovenants => new { clientCovenants.Client, Covenants = clientCovenants.Covenants.OrderBy(date => date.issueDate) });

            foreach (var client in answer)
            {
                Console.WriteLine(client.Client);
                foreach (var covenant in client.Covenants)
                    Console.WriteLine(" - {0}", covenant);
            }
            Console.WriteLine();
        }

        public void CarsConcate()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("19. Print all car names by concatenating their parts.");
            Console.ResetColor();

            var answer = cars.Select(car => car.brand.Concat(car.name.Concat(car.year.ToString())));

            foreach (var car in answer)
            {
                foreach (var c in car)
                    Console.Write(c);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void NeverRentedCars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("20. Print all cars that have never been rented.");
            Console.ResetColor();

            var answer = cars.GroupJoin(covenants, car => car.id, covenant => covenant.carId,
                (car, covenants) => new { Car = car, Covenants = covenants })
                .Where(clientCovenants => !clientCovenants.Covenants.Any());

            foreach (var car in answer)
                Console.WriteLine(car.Car);
            Console.WriteLine();
        }
    }
}

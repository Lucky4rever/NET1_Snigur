using System;
using System.Collections.Generic;

namespace NET1_Snigur.Variant20
{
    class NET1
    {
        public static List<Client> clients = new List<Client>()
        {
            new Client(0, "Pleshko Artem Ihorovich", "A, X street 12", "+38 (097)-321-64-23"),
            new Client(1, "Grishanov Myhaylo Volodimirovich", "B, C street 73", "+38 (096)-146-00-55"),
            new Client(2, "Petrenko Maksim Ihorovich", "B, V street 114", "+38 (067)-632-12-09"),
            new Client(3, "Dumavoy Petro Oleksandrovich", "A, V street 15", "+38 (097)-423-13-92"),
            new Client(4, "Babich Myhaylo Volodimirovich", "A, X street 7", "+38 (096)-321-10-10")
        };
        public static List<Car> cars = new List<Car>()
        {
            new Car(0, "Mercedes", "Benz", 'B', 5000F, 1985),
            new Car(1, "Audi", "A6", 'D', 175000F, 2014),
            new Car(2, "Seat", "Altea XL", 'B', 35000F, 2019),
            new Car(3, "Honda", "Accord", 'E', 25000F, 2008),
            new Car(4, "Mazda", "CX-5", 'C', 15118F, 2022),
            new Car(5, "Daewoo", "Nexia 1", 'C', 4000, 1999)
        };
        public static List<Covenant> covenants = new List<Covenant>() 
        {
            new Covenant(0, 0, 1, new DateTime(2023, 2, 28), new DateTime(2023, 3, 1)),
            new Covenant(1, 1, 4, new DateTime(2023, 2, 24), new DateTime(2023, 2, 28)),
            new Covenant(2, 4, 2, new DateTime(2023, 3, 2), new DateTime(2023, 3, 3)),
            new Covenant(3, 2, 3, new DateTime(2023, 3, 2), new DateTime(2023, 3, 9)),
            new Covenant(4, 1, 2, new DateTime(2023, 3, 4), new DateTime(2023, 3, 6)),
            new Covenant(5, 2, 1, new DateTime(2023, 3, 3), new DateTime(2023, 3, 8)),
            new Covenant(6, 2, 4, new DateTime(2023, 3, 2), new DateTime(2023, 3, 4))
        };

        public static void StartProgram()
        {
            Rental rental = new Rental()
                .SetName("New rental")
                .SetCars(cars)
                .SetClients(clients);

            rental.Cars();
            rental.ClientsAsObjects();
            rental.BClassCars();
            rental.AvailableCars();
            rental.Profit();
            rental.Names();
            rental.Requests();
            rental.NeverRenderedCars();
            rental.ClientsWithCars();
            rental.FrequentClients();

            rental.IncreasingValue();
            rental.CarsWithRentalCost();
            rental.RequestsInPeriod(new DateTime(2023, 03, 1), new DateTime(2023, 03, 5));
            rental.Cheapest();
            rental.AverageCost();
            rental.MoreThanCertain(5000F);
            rental.PhoneByComma();
            rental.ClientsWhoСontact();
            rental.CarsConcate();
            rental.NeverRentedCars();
        }
    }
}

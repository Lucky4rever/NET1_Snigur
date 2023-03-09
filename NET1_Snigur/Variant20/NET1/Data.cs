using System;
using System.Collections.Generic;

namespace NET1_Snigur.Variant20.NET1
{
    internal struct Data
    {
        public static readonly List<Client> Clients = new List<Client>()
        {
            new Client(0, "Pleshko Artem Ihorovich", "A, X street 12", "+38 (097)-321-64-23"),
            new Client(1, "Grishanov Myhaylo Volodimirovich", "B, C street 73", "+38 (096)-146-00-55"),
            new Client(2, "Petrenko Maksim Ihorovich", "B, V street 114", "+38 (067)-632-12-09"),
            new Client(3, "Dumavoy Petro Oleksandrovich", "A, V street 15", "+38 (097)-423-13-92"),
            new Client(4, "Babich Myhaylo Volodimirovich", "A, X street 7", "+38 (096)-321-10-10")
        };

        public static readonly List<Car> Cars = new List<Car>()
        {
            new Car(0, "Mercedes", "Benz",  Car.CarClasses.B, 5000m, 1985),
            new Car(1, "Audi", "A6", Car.CarClasses.D, 175000m, 2014),
            new Car(2, "Seat", "Altea XL", Car.CarClasses.B, 35000m, 2019),
            new Car(3, "Honda", "Accord", Car.CarClasses.E, 25000m, 2008),
            new Car(4, "Mazda", "CX-5", Car.CarClasses.C, 15118m, 2022),
            new Car(5, "Daewoo", "Nexia 1", Car.CarClasses.C, 4000m, 1999)
        };

        public static readonly List<Covenant> Covenants = new List<Covenant>()
        {
            new Covenant(0, 0, 1, new DateTime(2023, 2, 28), new DateTime(2023, 3, 1)),
            new Covenant(1, 1, 4, new DateTime(2023, 2, 24), new DateTime(2023, 2, 28)),
            new Covenant(2, 4, 2, new DateTime(2023, 3, 2), new DateTime(2023, 3, 3)),
            new Covenant(3, 2, 3, new DateTime(2023, 3, 2), new DateTime(2023, 3, 9)),
            new Covenant(4, 1, 2, new DateTime(2023, 3, 4), new DateTime(2023, 3, 6)),
            new Covenant(5, 2, 1, new DateTime(2023, 3, 3), new DateTime(2023, 3, 8)),
            new Covenant(6, 2, 4, new DateTime(2023, 3, 2), new DateTime(2023, 3, 4)),
            new Covenant(6, 2, 4, new DateTime(2023, 3, 10), new DateTime(2023, 3, 20))
        };

        public static void CheckCovenantDate()
        {
            foreach(Covenant covenant in Covenants)
            {
                covenant.Deposit.CheckDate();
            }
        }
    }
}

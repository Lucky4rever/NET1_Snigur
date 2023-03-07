using System;
//using NET1_Snigur.Example;
//using NET1_Snigur.Variant15;
using NET1_Snigur.Variant20;

namespace NET1_Snigur {
    class Program {
        private static void Main(string[] args) {
            //run test code for lab 1
            //TestCode.testProgram();

            Rental rental = new Rental()
                .SetName("New rental")
                .SetCars(TestData.cars)
                .SetClients(TestData.clients)
                .SetCovenants(TestData.covenants);

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

            Console.ReadLine();
        }
    }
}

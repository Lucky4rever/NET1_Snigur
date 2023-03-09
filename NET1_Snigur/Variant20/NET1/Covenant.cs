using System;

namespace NET1_Snigur.Variant20.NET1
{
    class Covenant
    {
        public int Id { get; }

        public Deposit<decimal> Deposit { get; }
        //TODO consistency
        private decimal IntermediatPrice { get; set; }
        public Money<decimal> Price 
        { 
            get 
            { 
                return new Money<decimal>(IntermediatPrice); 
            }
            set
            {
                Car car = Data.Cars[CarCovenant.CarId];

                IntermediatPrice = (ReturnDate - IssueDate).Days * 
                    (100 - (DateTime.Today.Year - car.Year)) *
                    car.Price.Amount / 250;
            }
        }

        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CarId { get; set; }
        //Code smell references 
        public CarCovenant CarCovenant
        {
            get
            {
                return new CarCovenant(CarId, Id);
            }
        }

        public int ClientId { get; set; }
        public ClientCovenant ClientCovenant
        {
            get
            {
                return new ClientCovenant(ClientId, Id);
            }
        }

        //Long parameter list 
        public Covenant(int Id, int ClientId, int CarId, DateTime IssueDate, DateTime ReturnDate)
        {
            this.Id = Id;
            this.ClientId = ClientId;
            this.CarId = CarId;
            this.IssueDate = IssueDate;
            this.ReturnDate = ReturnDate;

            Price = new Money<decimal>(IntermediatPrice);
            Deposit = new Deposit<decimal>(Data.Cars[CarId].Price.Amount / 50m, ReturnDate);
        }
        public override string ToString()
        {
            return "Client №" + ClientId + " took car №" + CarId + " from " + IssueDate.ToString("yyyy.MM.DD") + " to " + ReturnDate.ToString("yyyy.MM.DD");
        }
    }
}

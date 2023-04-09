using System;

namespace DOTNET.Variant20.NET1
{
    class Covenant
    {
        public int Id { get; }

        public decimal Deposit { get; set; }

        public void CheckDate()
        {
            try
            {
                if (ReturnDate <= DateTime.Today)
                {
                    Deposit = default;
                }
            }
            catch (ArgumentNullException) { };
        }

        private decimal IntermediatPrice { get; set; }
        public decimal Price 
        { 
            get 
            { 
                return IntermediatPrice; 
            }
            set
            {
                Car car = Data.Cars[CarCovenant.CarId];

                IntermediatPrice = (ReturnDate - IssueDate).Days * 
                    (100 - (DateTime.Today.Year - car.Year)) *
                    car.Price / 250;
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

            Price = IntermediatPrice;
            Deposit = Data.Cars[CarId].Price / 50m;
        }
        public override string ToString()
        {
            return "Client №" + ClientId + " took car №" + CarId + " from " + IssueDate.ToString("yyyy.MM.dd") + " to " + ReturnDate.ToString("yyyy.MM.dd");
        }
    }
}

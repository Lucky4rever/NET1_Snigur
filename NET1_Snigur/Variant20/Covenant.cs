using System;

namespace NET1_Snigur.Variant20
{
    class Covenant
    {
        public int id { get; set; }
        public float deposit { get { return car.car.price / 20; } }
        private float _price = 1;
        public float price 
        { 
            get { return _price; }
            set
            {
                float multiplier;
                if (car.car.year > 2018)
                    multiplier = 2;
                else if (car.car.year > 2013)
                    multiplier = 1.75F;
                else if (car.car.year > 2008)
                    multiplier = 1.5F;
                else if (car.car.year > 2000)
                    multiplier = 1.25F;
                else
                    multiplier = 1F;

                _price = (returnDate - issueDate).Days * multiplier * car.car.price / 50;
            }
        }

        public DateTime issueDate { get; set; }
        public DateTime returnDate { get; set; }

        public int carId { get; set; }
        public CarCovenant car
        {
            get
            {
                return new CarCovenant().AddCar(carId);
            }
        }

        public int clientId { get; set; }
        public ClientCovenant client
        {
            get
            {
                return new ClientCovenant().AddClient(clientId);
            }
        }

        public Covenant(int id, int clientId, int carId, DateTime issueDate, DateTime returnDate)
        {
            this.id = id;
            this.clientId = clientId;
            this.carId = carId;
            this.issueDate = issueDate;
            this.returnDate = returnDate;
            price = new float();
        }
        public override string ToString()
        {
            return "Client №" + clientId + " took car №" + carId + " from " + Date(issueDate) + " to " + Date(returnDate);
        }
        private string Date(DateTime date)
        {
            return (date.Day.ToString().Length == 1 ?
                ("0" + date.Day.ToString()) : date.Day.ToString()) +
                "." + (date.Month.ToString().Length == 1 ? 
                ("0" + date.Month.ToString()) : date.Month.ToString()) + 
                "." + date.Year;
        }
    }
}

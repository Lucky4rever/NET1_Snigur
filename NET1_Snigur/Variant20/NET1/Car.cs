namespace NET1_Snigur.Variant20.NET1
{
    class Car
    {
        public int Id { get; }
        public string Brand { get; }
        public string Name { get; }
        public Money<decimal> Price { get; }
        public CarClasses CarClass { get; }
        public int Year { get; }

        public enum CarClasses : int
        {
            A = 65,
            B = 66,
            C = 67,
            D = 68,
            E = 69,
            S = 83,
            M = 77,
            J = 74
        }

        public Car(int Id, string Brand, string Name, CarClasses CarClass, Money<decimal> Price, int Year)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Name = Name;
            this.CarClass = CarClass;
            this.Price = Price;
            this.Year = Year;
        }

        public Car(int Id, string Brand, string Name, CarClasses CarClass, decimal Price, int Year)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Name = Name;
            this.CarClass = CarClass;
            this.Price = new Money<decimal>(Price);
            this.Year = Year;
        }
        public override string ToString()
        {
            return "A " + Brand + " " + Name + " " + CarClass + "-class car for " + Price.Text;
        }
    }
}

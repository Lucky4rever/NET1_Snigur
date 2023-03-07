namespace NET1_Snigur.Variant20
{
    class Car
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public char carClass { get; set; }
        public int year { get; set; }
        public CarCovenant covenant = null;

        public Car(int id, string brand, string name, char carClass, float price, int year)
        {
            this.id = id;
            this.brand = brand;
            this.name = name;
            this.carClass = carClass;
            this.price = price;
            this.year = year;
        }
        public override string ToString()
        {
            return "A " + brand + " " + name + " " + carClass + "-class car for $" + price;
        }
    }
}

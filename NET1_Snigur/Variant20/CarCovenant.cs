namespace NET1_Snigur.Variant20
{
    class CarCovenant
    {
        public int carId { get; set; }
        public Car car { get; set; }

        public int covenantId { get; set; }
        public Covenant covenant { get; set; }

        internal CarCovenant AddCar(int carId)
        {
            this.carId = carId;
            car = NET1.cars[carId];
            return this;
        }
        internal CarCovenant AddCovenant(int covenantId)
        {
            this.covenantId = covenantId;
            covenant = NET1.covenants[covenantId];
            return this;
        }
    }
}

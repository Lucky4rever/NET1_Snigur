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
            car = TestData.cars[carId];
            return this;
        }
        internal CarCovenant AddCovenant(int covenantId)
        {
            this.covenantId = covenantId;
            covenant = TestData.covenants[covenantId];
            return this;
        }
    }
}

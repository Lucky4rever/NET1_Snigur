namespace DOTNET.Variant20.NET1
{
    class CarCovenant
    {
        public int CarId { get; set; }
        public int CovenantId { get; set; }

        public CarCovenant(int CarId, int CovenantId)
        {
            this.CarId = CarId;
            this.CovenantId = CovenantId;
        }
    }
}

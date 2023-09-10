namespace DOTNET.Variant13.NET3
{
    class ReinforcedConcreteSlabs : Material
    {
        public int Width;
        public int Lenght;

        public ReinforcedConcreteSlabs(int lenght, int width, int count) : base(count)
        {
            this.Lenght = lenght;
            this.Width = width;
        }

        public override string ToString()
        {
            return $"Reinforced concrete slabs {this.Width}x{this.Lenght}";
        }
    }
}

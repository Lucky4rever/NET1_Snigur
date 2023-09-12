namespace DOTNET.Variant13.NET3
{
    class Concrete : Material
    {
        public Concrete(int count) : base(count) { }

        public override string ToString()
        {
            return $"Concrete ({this.Count} bags)";
        }
    }
}

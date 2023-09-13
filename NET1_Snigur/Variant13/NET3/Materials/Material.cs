namespace DOTNET.Variant13.NET3.Materials
{
    abstract class Material
    {
        protected int Count { get; set; }

        public Material(int count)
        {
            this.Count = count;
        }

        public override string ToString()
        {
            return $"Material ({this.Count})";
        }
    }
}

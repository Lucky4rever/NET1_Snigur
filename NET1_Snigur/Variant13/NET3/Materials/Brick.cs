using DOTNET.Variant13.NET3.Materials;

namespace DOTNET.Variant13.NET3
{
    class Brick : Material
    {
        private BrickType Type { get; set; }

        public Brick(BrickType type, int count) : base(count)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"{this.Type} brick ({this.Count} pieces)";
        }
    }
}

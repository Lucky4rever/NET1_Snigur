namespace DOTNET.Variant13.NET3
{
    class Brick : Material
    {
        public enum BrickType
        {
            Ceramic,
            Clinker,
            Silicate
        }

        public BrickType Type;

        public Brick(BrickType type, int count) : base(count)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            return $"{this.Type} brick";
        }
    }
}

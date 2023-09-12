namespace DOTNET.Variant13.NET4
{
    class Doctor
    {
        public string Name { get; private set; }
        public DoctorPosition Position { get; private set; }

        public Doctor(string name, DoctorPosition position)
        {
            this.Name = name;
            this.Position = position;
        }

        public override string ToString()
        {
            return $"{this.Position} {this.Name}";
        }
    }
}

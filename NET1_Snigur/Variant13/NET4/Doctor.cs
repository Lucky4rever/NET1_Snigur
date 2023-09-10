namespace DOTNET.Variant13.NET4
{
    class Doctor
    {
        public string Name;
        public DoctorPosition Position;

        public enum DoctorPosition
        {
            Therapist,
            Surgeon,
            Intensivist
        }

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

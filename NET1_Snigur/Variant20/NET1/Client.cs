namespace DOTNET.Variant20.NET1
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Client(int Id, string Name, string Address, string Phone)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
        }
        public override string ToString()
        {
            return Name + " - " + Address + " - " + Phone;
        }
    }
}

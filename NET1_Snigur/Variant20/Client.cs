using System.Collections.Generic;

namespace NET1_Snigur.Variant20
{
    class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public List<ClientCovenant> covenants = null;

        public Client(int id, string name, string address, string phone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
        }
        public override string ToString()
        {
            return name + " - " + address + " - " + phone;
        }
    }
}

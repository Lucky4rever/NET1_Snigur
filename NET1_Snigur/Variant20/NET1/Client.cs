using DOTNET.Variant20.NET2.XMLConverter.VariableNames;
using System;
using System.Xml.Serialization;

namespace DOTNET.Variant20.NET1
{
    [Serializable, XmlRoot(ElementName = ClientVariableNames.BaseName)]
    public class Client
    {
        [XmlAttribute(AttributeName = ClientVariableNames.Id)]
        public int Id { get; set; }
        
        [XmlAttribute(AttributeName = ClientVariableNames.Name)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = ClientVariableNames.Address)]
        public string Address { get; set; }
        
        [XmlAttribute(AttributeName = ClientVariableNames.Phone)]
        public string Phone { get; set; }

        public Client() { }
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

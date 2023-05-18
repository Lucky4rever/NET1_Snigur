using DOTNET.Variant20.NET2.XMLConverter.VariableNames;
using System;
using System.Xml.Serialization;

namespace DOTNET.Variant20.NET1
{
    [Serializable, XmlRoot(ElementName = CarVariableNames.BaseName)]
    public class Car
    {
        [XmlAttribute(AttributeName = CarVariableNames.Id)]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = CarVariableNames.Brand)]
        public string Brand { get; set; }

        [XmlAttribute(AttributeName = CarVariableNames.Name)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = CarVariableNames.Price)]
        public decimal Price { get; set; }

        [XmlAttribute(AttributeName = CarVariableNames.CarClass)]
        public CarClasses CarClass { get; set; }

        [XmlAttribute(AttributeName = CarVariableNames.Year)]
        public int Year { get; set; }

        public enum CarClasses : int
        {
            A = 65,
            B = 66,
            C = 67,
            D = 68,
            E = 69,
            S = 83,
            M = 77,
            J = 74
        }

        public Car() { }
        public Car(int Id, string Brand, string Name, CarClasses CarClass, decimal Price, int Year)
        {
            this.Id = Id;
            this.Brand = Brand;
            this.Name = Name;
            this.CarClass = CarClass;
            this.Price = Price;
            this.Year = Year;
        }

        public override string ToString()
        {
            return "A " + Brand + " " + Name + " " + CarClass + "-class car for " + Price;
        }
    }
}

using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace DOTNET.Variant20.NET2.XMLConverter
{
    class CarsXMLConverter : IXMLConverter
    {
        private XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        public void ConvertToXML(string fileName, object variables)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
            {
                writer.WriteStartElement("cars");

                foreach (Car car in variables as List<Car>)
                {
                    writer.WriteStartElement("car");
                    writer.WriteElementString("id", car.Id.ToString());
                    writer.WriteElementString("brand", car.Brand);
                    writer.WriteElementString("name", car.Name);
                    writer.WriteElementString("car-class", ((int)car.CarClass).ToString());
                    writer.WriteElementString("price", car.Price.ToString());
                    writer.WriteElementString("year", car.Year.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        public object ConvertFromXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName + ".xml");
            List<Car> variables = new List<Car>();

            foreach (XmlNode node in doc.SelectNodes("cars/car"))
            {
                int id = int.Parse(node.SelectSingleNode("id").InnerText);
                string brand = node.SelectSingleNode("brand").InnerText;
                string name = node.SelectSingleNode("name").InnerText;
                Car.CarClasses carClass = (Car.CarClasses)int.Parse(node.SelectSingleNode("car-class").InnerText);
                decimal price = decimal.Parse(node.SelectSingleNode("price").InnerText);
                int year = int.Parse(node.SelectSingleNode("year").InnerText);

                Car car = new Car(id, brand, name, carClass, price, year);
                variables.Add(car);
            }

            return variables;
        }
    }
}

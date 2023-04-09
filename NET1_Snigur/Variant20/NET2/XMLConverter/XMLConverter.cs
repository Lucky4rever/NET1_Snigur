//using DOTNET.Variant20.NET1;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.IO;
//using System.Reflection;
//using System.Xml;

//namespace DOTNET.Variant20.NET2
//{
//    class XMLConverter //<T> where T : new()
//    {
//        private XmlWriterSettings settings = new XmlWriterSettings
//        {
//            Indent = true
//        };

//        public void ConvertToXML(string fileName, List<Client> clients)
//        {
//            using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
//            {
//                writer.WriteStartElement("clients");

//                foreach (Client client in clients)
//                {
//                    writer.WriteStartElement("client");
//                    writer.WriteElementString("id", client.Id.ToString());
//                    writer.WriteElementString("name", client.Name);
//                    writer.WriteElementString("address", client.Address);
//                    writer.WriteElementString("phone", client.Phone);
//                    writer.WriteEndElement();
//                }

//                writer.WriteEndElement();
//            }
//        }

//        public void ConvertToXML(string fileName, List<Car> cars)
//        {
//            using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
//            {
//                writer.WriteStartElement("cars");

//                foreach (Car car in cars)
//                {
//                    writer.WriteStartElement("car");
//                    writer.WriteElementString("id", car.Id.ToString());
//                    writer.WriteElementString("brand", car.Brand);
//                    writer.WriteElementString("name", car.Name);
//                    writer.WriteElementString("car-class", ((int)car.CarClass).ToString());
//                    writer.WriteElementString("price", car.Price.ToString());
//                    writer.WriteElementString("year", car.Year.ToString());
//                    writer.WriteEndElement();
//                }

//                writer.WriteEndElement();
//            }
//        }

//        public void ConvertToXML(string fileName, List<Covenant> covenants)
//        {
//            using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
//            {
//                writer.WriteStartElement("uscovenantsers");

//                foreach (Covenant covenant in covenants)
//                {
//                    writer.WriteStartElement("covenant");
//                    writer.WriteElementString("id", covenant.Id.ToString());
//                    writer.WriteElementString("client-id", covenant.ClientId.ToString());
//                    writer.WriteElementString("car-id", covenant.CarId.ToString());
//                    writer.WriteElementString("issue-date", covenant.IssueDate.ToString());
//                    writer.WriteElementString("return-date", covenant.ReturnDate.ToString());
//                    writer.WriteEndElement();
//                }

//                writer.WriteEndElement();
//            }
//        }

//        public List<Covenant> ConvertFromXML(string fileName)
//        {
//            XmlDocument doc = new XmlDocument();
//            doc.Load(fileName + ".xml");
//            List<Covenant> covenants = new List<Covenant>();

//            foreach (XmlNode covenantNode in doc.SelectNodes("uscovenantsers/covenant"))
//            {
//                int id = int.Parse(covenantNode.SelectSingleNode("id").InnerText);
//                int clientId = int.Parse(covenantNode.SelectSingleNode("client-id").InnerText);
//                int carId = int.Parse(covenantNode.SelectSingleNode("car-id").InnerText);
//                DateTime issueDate = DateTime.Parse(covenantNode.SelectSingleNode("issue-date").InnerText);
//                DateTime returnDate = DateTime.Parse(covenantNode.SelectSingleNode("return-date").InnerText);

//                Covenant covenant = new Covenant(id, clientId, carId, issueDate, returnDate);
//                covenants.Add(covenant);
//            }

//            return covenants;
//        }


//        //public void AutoConvertToXML(string name, List<T> properties)
//        //{
//        //    using (XmlWriter writer = XmlWriter.Create(name + ".xml", settings))
//        //    {
//        //        string propsName = typeof(T).Name;
//        //        writer.WriteStartElement(propsName + "s");
//        //        foreach (T prop in properties)
//        //        {
//        //            writer.WriteStartElement(propsName);
//        //            Variable[] variables = PropertyReader.getProperties(prop);
//        //            foreach (Variable variable in variables)
//        //            {
//        //                writer.WriteStartElement(variable.name);
//        //                writer.WriteAttributeString("Name", variable.name);
//        //                writer.WriteAttributeString("Type", variable.type.Name);
//        //                writer.WriteElementString("Value", variable.value.ToString());
//        //                writer.WriteEndElement();
//        //            }
//        //            writer.WriteEndElement();
//        //        }
//        //        writer.WriteEndElement();
//        //    }
//        //}

//        //public List<T> AutoConvertFromXML(string fileName)
//        //{
//        //    //XmlDocument doc = new XmlDocument();
//        //    //doc.Load(name + "s.xml");
//        //    //foreach (XmlNode node in doc.SelectSingleNode("//car"))
//        //    //{
//        //    //    string name = node.Attributes["Name"].Value;
//        //    //    string type = node.Attributes["Type"].Value;
//        //    //    string value = node.SelectSingleNode("Value").InnerText;

//        //    //    PropertyInfo propInfo = typeof(Car).GetProperty(name); // отримуємо відповідне свойство об'єкту Car
//        //    //    object propValue = Convert.ChangeType(value, Type.GetType(type)); // конвертуємо значення до потрібного типу
//        //    //    propInfo.SetValue(car, propValue);
//        //    //}
//        //    List<T> properties = new List<T>();

//        //    XmlDocument doc = new XmlDocument();
//        //    doc.Load(fileName + ".xml");
//        //    XmlNodeList carNodes = doc.DocumentElement.SelectNodes("/cars/car");

//        //    foreach (XmlNode carNode in carNodes)
//        //    {
//        //        T property = new T();
//        //        int iterator = 0;

//        //        foreach (XmlNode propNode in carNode.ChildNodes)
//        //        {
//        //            var propName = propNode.Attributes["Name"].Value;
//        //            var propType = propNode.Attributes["Type"].Value;
//        //            var propValue = propNode.SelectSingleNode("Value").InnerText;

//        //            try
//        //            {
//        //                var v = Type.GetType("System.Int32");
//        //                var converter = TypeDescriptor.GetConverter(propType);
//        //                var convertedValue = converter.ConvertFromString(propValue);
//        //                property.GetType().GetProperty(propName).SetValue(this, convertedValue);
//        //            }
//        //            catch (ArgumentNullException) { }

//        //            iterator++;
//        //            Console.WriteLine("{0} -> {1} -> {2}", propName, propType, propValue);
//        //        }

//        //        properties.Add(property);
//        //    }

//        //    return properties;
//        //}
//    }
//}

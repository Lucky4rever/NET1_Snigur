using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;

namespace DOTNET.Variant20.NET2.XMLConverter
{
    class CovenantsXMLConverter : IXMLConverter
    {
        private XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        public void ConvertToXML(string fileName, object variables)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
            {
                writer.WriteStartElement("covenants");

                foreach (Covenant covenant in variables as List<Covenant>)
                {
                    writer.WriteStartElement("covenant");
                    writer.WriteElementString("id", covenant.Id.ToString());
                    writer.WriteElementString("client-id", covenant.ClientId.ToString());
                    writer.WriteElementString("car-id", covenant.CarId.ToString());
                    writer.WriteElementString("issue-date", covenant.IssueDate.ToString());
                    writer.WriteElementString("return-date", covenant.ReturnDate.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        public object ConvertFromXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName + ".xml");
            List<Covenant> variables = new List<Covenant>();

            foreach (XmlNode node in doc.SelectNodes("covenants/covenant"))
            {
                int id = int.Parse(node.SelectSingleNode("id").InnerText);
                int clientId = int.Parse(node.SelectSingleNode("client-id").InnerText);
                int carId = int.Parse(node.SelectSingleNode("car-id").InnerText);
                DateTime issueDate = DateTime.Parse(node.SelectSingleNode("issue-date").InnerText);
                DateTime returnDate = DateTime.Parse(node.SelectSingleNode("return-date").InnerText);

                Covenant covenant = new Covenant(id, clientId, carId, issueDate, returnDate);
                variables.Add(covenant);
            }

            return variables;
        }
    }
}

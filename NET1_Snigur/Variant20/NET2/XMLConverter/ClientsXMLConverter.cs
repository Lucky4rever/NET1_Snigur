using DOTNET.Variant20.NET1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DOTNET.Variant20.NET2.XMLConverter
{
    class ClientsXMLConverter : IXMLConverter
    {
        public static readonly string xmlFileName = "clients.xml";
        public static readonly string xsdFileName = "clients.xsd";

        public void ConvertToXML(object variables)
        {
            using (XmlWriter writer = XmlWriter.Create(xmlFileName))
            {
                XmlSerializer serializer = new XmlSerializer(variables.GetType());
                serializer.Serialize(writer, variables);
            }
        }

        public object ConvertFromXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
            List<Client> variables = new List<Client>();

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, xsdFileName);

            using (FileStream fileStream = new FileStream(xmlFileName, FileMode.Open))
            {
                try
                {
                    variables = (List<Client>)serializer.Deserialize(fileStream);
                }
                catch (XmlSchemaValidationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return variables;
        }

        //private XmlWriterSettings settings = new XmlWriterSettings
        //{
        //    Indent = true
        //};

        //public void ConvertToXML(string fileName, object variables)
        //{
        //    using (XmlWriter writer = XmlWriter.Create(fileName + ".xml", settings))
        //    {
        //        writer.WriteStartElement("clients");

        //        foreach (Client client in variables as List<Client>)
        //        {
        //            writer.WriteStartElement("client");
        //            writer.WriteElementString("id", client.Id.ToString());
        //            writer.WriteElementString("name", client.Name);
        //            writer.WriteElementString("address", client.Address);
        //            writer.WriteElementString("phone", client.Phone);
        //            writer.WriteEndElement();
        //        }

        //        writer.WriteEndElement();
        //    }
        //}

        //public object ConvertFromXML(string fileName)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(fileName + ".xml");
        //    List<Client> variables = new List<Client>();

        //    foreach (XmlNode node in doc.SelectNodes("clients/client"))
        //    {
        //        int id = int.Parse(node.SelectSingleNode("id").InnerText);
        //        string name = node.SelectSingleNode("name").InnerText;
        //        string address = node.SelectSingleNode("address").InnerText;
        //        string phone = node.SelectSingleNode("phone").InnerText;

        //        Client client = new Client(id, name, address, phone);
        //        variables.Add(client);
        //    }

        //    return variables;
        //}
    }
}

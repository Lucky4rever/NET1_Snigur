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
    class CovenantsXMLConverter : IXMLConverter
    {
        public static readonly string xmlFileName = "covenants.xml";
        public static readonly string xsdFileName = "covenants.xsd";

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
            XmlSerializer serializer = new XmlSerializer(typeof(List<Covenant>));
            List<Covenant> variables = new List<Covenant>();

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, xsdFileName);

            using (FileStream fileStream = new FileStream(xmlFileName, FileMode.Open))
            {
                try
                {
                    variables = (List<Covenant>)serializer.Deserialize(fileStream);
                }
                catch (XmlSchemaValidationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return variables;
        }
    }
}

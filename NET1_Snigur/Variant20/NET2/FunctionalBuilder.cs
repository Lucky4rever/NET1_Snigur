using DOTNET.Variant20.NET2.XMLConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace DOTNET.Variant20.NET2
{
    class FunctionalBuilder : IBuilder
    {
        private Functional _functional;
        private XmlReaderSettings _settings;

        public FunctionalBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._functional = new Functional();
            this._settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
        }

        public void SetCarsDocument(string xmlFileName, string xsdFileName)
        {
            using (var streamCars = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read))
            using (var validateCars = new FileStream(xsdFileName, FileMode.Open, FileAccess.Read))
            {
                var doc = XDocument.Load(streamCars);

                this._settings.Schemas.Add(null, xsdFileName);

                bool errors = false;
                this._settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
                this._settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                doc.Validate(this._settings.Schemas, (o, e) => {
                    errors = true;
                    Console.WriteLine(e.Message);
                });

                if (errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"File {xmlFileName} is invalid");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"File {xmlFileName} is valid");
                    Console.ResetColor();
                    Console.WriteLine();

                    this._functional._docCars = doc;
                }
            }
        }

        public void SetCovenantsDocument(string xmlFileName, string xsdFileName)
        {

            using (var streamCovenants = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read))
            using (var validateCovenants = new FileStream(xsdFileName, FileMode.Open, FileAccess.Read))
            {
                var doc = XDocument.Load(streamCovenants);
                this._settings.Schemas.Add(null, xsdFileName);

                bool errors = false;
                this._settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
                this._settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                doc.Validate(this._settings.Schemas, (o, e) => {
                    errors = true;
                    Console.WriteLine(e.Message);
                });

                if (errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"File {xmlFileName} is invalid");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"File {xmlFileName} is valid");
                    Console.ResetColor();
                    Console.WriteLine();

                    this._functional._docCovenants = doc;
                }
            }
        }

        public void SetClientsDocument(string xmlFileName, string xsdFileName)
        {
            using (var streamClients = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read))
            using (var validateClients = new FileStream(xsdFileName, FileMode.Open, FileAccess.Read))
            {
                var doc = XDocument.Load(streamClients);
                this._settings.Schemas.Add(null, xsdFileName);

                bool errors = false;
                this._settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
                this._settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                doc.Validate(this._settings.Schemas, (o, e) => {
                    errors = true;
                    Console.WriteLine(e.Message);
                });

                if (errors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"File {xmlFileName} is invalid");
                    Console.ResetColor();
                    Console.WriteLine();
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"File {xmlFileName} is valid");
                    Console.ResetColor();
                    Console.WriteLine();

                    this._functional._docClients = doc;
                }
            }
        }

        public Functional Build()
        {
            return this._functional;
        }
    }
}

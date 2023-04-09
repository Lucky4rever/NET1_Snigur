using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2.XMLConverter
{
    class XMLConverterContext
    {
        private IXMLConverter _XMLConverter;

        public XMLConverterContext() { }

        public void SetStrategy(IXMLConverter XMLConverter)
        {
            this._XMLConverter = XMLConverter;
        }

        public void ConvertToXML(string fileName, object variables)
        {
            this._XMLConverter.ConvertToXML(fileName, variables);
        }

        public object ConvertFromXML(string fileName)
        {
            return this._XMLConverter.ConvertFromXML(fileName);
        }
    }
}

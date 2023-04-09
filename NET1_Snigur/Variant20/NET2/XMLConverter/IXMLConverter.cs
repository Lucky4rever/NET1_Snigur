using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2.XMLConverter
{
    interface IXMLConverter
    {
        void ConvertToXML(string fileName, object variables);
        object ConvertFromXML(string fileName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET2
{
    interface IBuilder
    {
        void SetCarsDocument(string xmlFileName, string xsdFileName);
        void SetCovenantsDocument(string xmlFileName, string xsdFileName);
        void SetClientsDocument(string xmlFileName, string xsdFileName);
    }
}

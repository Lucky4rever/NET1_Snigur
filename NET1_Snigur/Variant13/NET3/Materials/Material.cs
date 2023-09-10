using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET3
{
    abstract class Material
    {
        public int Count;

        public Material(int count)
        {
            this.Count = count;
        }

        public override string ToString()
        {
            return "Material";
        }
    }
}

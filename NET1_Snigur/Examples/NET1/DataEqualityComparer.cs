using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Examples.NET1
{
    public class DataEqualityComparer : IEqualityComparer<Data> {
        public bool Equals(Data x, Data y) {
            bool Result = false;
            if (x.id == y.id && x.grp == y.grp && x.value == y.value)
                Result = true;
            return Result;
        }
        public int GetHashCode(Data obj) {
            return obj.id;
        }
    }
}

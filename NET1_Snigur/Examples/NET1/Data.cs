using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1_Snigur.Example
{
    public class Data {
        public int id;
        public string grp;
        public string value;

        public Data(int i, string g, string v) {
            this.id = i;
            this.grp = g;
            this.value = v;
        }
        public override string ToString() {
            return string.Format($"(id={this.id}; grp={this.grp}; value={this.value})");
        }
    }
}

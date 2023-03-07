using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1_Snigur.Variant15 {
    class PublishingHouse {
        public PublishingHouse(string name) {
            this.name = name;
        }
        public string name { get; set; }
        public List<Book> books = new List<Book>();
        public override string ToString()
        {
            return "Publishing house '" + name + "'";
        }
    }
}

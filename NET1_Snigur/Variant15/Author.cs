using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant15 {
    class Author {
        public Author(string name) {
            this.name = name;
        }
        public string name { get; set; }
        public List<Book> books = new List<Book>();
    }
}

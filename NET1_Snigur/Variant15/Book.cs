using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant15 {
    class Book {
        public Book (
                string name, 
                double price, 
                DateTime date
            ) {
            this.name = name;
            this.price = price;
            this.date = date;
        }
        public string name { get; set; }
        public double price { get; set; }


        private DateTime _date;
        public DateTime date
        {
            get { return _date.Date; }
            set { _date = value; }
        }


        //public Author author;
        //public string authorName { get { return author.name; } set { } }
        public string authorName = null;
        public string publishingHouse = null;
        public string inventoryNumber = null;
        public virtual ICollection<Library> Libraries { get; set; }
        public override string ToString() {
            return "The book " + name +
                " by the author " + authorName +
                " was published " + date + " by '" + publishingHouse +
                "' publishing house.\nThe price is UAH " + price;
        }
    }
}

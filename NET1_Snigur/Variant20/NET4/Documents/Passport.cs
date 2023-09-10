using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET4.Documents
{
    class Passport : IDocument
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string IssuedBy { get; set; }
        public DateTime ExpiryDate { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"Passport {this.Series}-{this.Number} was issued to {this.Name} ({this.BirthDate:dd.MM.yyyy}) {this.Sex} by {this.IssuedBy} and expires {this.ExpiryDate:dd.MM.yyyy}");
        }
    }
}

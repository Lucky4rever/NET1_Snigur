using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET4.Documents
{
    class InsurancePolicy : IDocument
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
        public string Company { get; set; }
        public string Conditions { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"Insurance policy {this.Type}-{this.Number} in the amount of {this.Amount} was issued by {this.Company} for the period {this.Period} subject to conditions:\n{this.Conditions}");
        }
    }
}

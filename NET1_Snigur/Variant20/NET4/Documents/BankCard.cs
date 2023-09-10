using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET4.Documents
{
    class BankCard : IDocument
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"A bank card {this.Type} {this.Number} ({this.CVV}) was issued to {this.Name} until {this.ExpiryDate:dd.MM.yyyy}");
        }
    }
}

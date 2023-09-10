using DOTNET.Variant20.NET5.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET5
{
    class Grant
    {
        private GrantStatus Status { get; }
        public string Name { get; private set; }

        public Grant(string name)
        {
            this.Name = name;
            this.Status = new GrantStatus(new Created());
        }

        public string GetStatus()
        {
            return this.Status.GetStatus();
        }

        public void ChangeStatus(GrantStatusStrategy strategy)
        {
            this.Status.ChangeStatus(strategy);
        }

        public override string ToString()
        {
            return $"Name: {this.Name} | Status: {this.Status.GetStatus()}";
        }
    }
}

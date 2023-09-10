using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET3
{
    class SuppliersListBuilder
    {
        private SuppliersList List;

        public SuppliersListBuilder()
        {
            this.List = new SuppliersList();
        }

        public void AddSupplier(Supplier supplier)
        {
            this.List.Suppliers.Add(supplier);
        }

        public SuppliersList Build()
        {
            return this.List;
        }
    }
}

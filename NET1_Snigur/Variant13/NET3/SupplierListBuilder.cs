using System.Collections.Generic;

namespace DOTNET.Variant13.NET3
{
    class SupplierListBuilder
    {
        private readonly List<SupplierListItem> List;

        public SupplierListBuilder()
        {
            this.List = new List<SupplierListItem>();
        }

        public void AddNewPosition(SupplierListItem item)
        {
            this.List.Add(item);
        }

        public List<SupplierListItem> Build()
        {
            return this.List;
        }
    }
}

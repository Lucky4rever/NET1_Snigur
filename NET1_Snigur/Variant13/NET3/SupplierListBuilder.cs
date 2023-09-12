using System.Collections.Generic;

namespace DOTNET.Variant13.NET3
{
    class SupplierListBuilder
    {
        private readonly List<SupplierListItem> _list;

        public SupplierListBuilder()
        {
            this._list = new List<SupplierListItem>();
        }

        public void AddNewPosition(SupplierListItem item)
        {
            this._list.Add(item);
        }

        public List<SupplierListItem> Build()
        {
            return this._list;
        }
    }
}

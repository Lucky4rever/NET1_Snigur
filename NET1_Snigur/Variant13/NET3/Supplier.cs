using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET3
{
    class Supplier
    {
        public readonly string Name;
        private List<SupplierListItem> _itemList;

        public Supplier(string name)
        {
            this.Name = name;
            this._itemList = new List<SupplierListItem>();
        }

        public void SetItemList(List<SupplierListItem> list)
        {
            this._itemList = list;
        }

        public void AddItemToList(SupplierListItem item)
        {
            this._itemList.Add(item);
        }

        public List<SupplierListItem> GetItemList()
        {
            return this._itemList;
        }
    }
}

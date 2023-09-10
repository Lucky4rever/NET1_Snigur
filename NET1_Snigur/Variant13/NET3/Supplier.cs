using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET3
{
    class Supplier
    {
        public string Name;
        private List<SupplierListItem> ItemList;

        public Supplier(string name)
        {
            this.Name = name;
            this.ItemList = new List<SupplierListItem>();
        }

        public void SetItemList(List<SupplierListItem> list)
        {
            this.ItemList = list;
        }

        public void AddItemToList(SupplierListItem item)
        {
            this.ItemList.Add(item);
        }

        public List<SupplierListItem> GetItemList()
        {
            return this.ItemList;
        }
    }
}

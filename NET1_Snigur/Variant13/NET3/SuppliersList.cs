using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant13.NET3
{
    class SuppliersList
    {
        public List<Supplier> Suppliers;

        public SuppliersList()
        {
            this.Suppliers = new List<Supplier>();
        }

        public SupplierListItem FindBestItem(Material material, int count, int maxPrice)
        {
            List<SupplierListItem> list = Suppliers
                .SelectMany(supplier => supplier
                    .GetItemList()
                    .Where(item => 
                        item.Material == material
                        && item.MaxCount >= count
                        && item.PriceForSet <= maxPrice)
                )
                .ToList();


            SupplierListItem bestItem = list
                .First(x => x.PriceForSet == list.Min(item => item.PriceForSet));

            return bestItem;
        }

        public Supplier FindSupplier(Material material, int count, int maxPrice)
        {
            Supplier perfectSupplier = Suppliers.Find(
                    supplier => supplier.GetItemList().FindAll(
                            item => item.Material == material
                            && item.MaxCount >= count
                            && item.PriceForSet <= maxPrice
                        ) != null
                );

            return perfectSupplier;
        }
    }
}

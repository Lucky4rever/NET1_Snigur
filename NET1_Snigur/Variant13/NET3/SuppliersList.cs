using DOTNET.Variant13.NET3.Materials;
using System.Collections.Generic;
using System.Linq;

namespace DOTNET.Variant13.NET3
{
    class SuppliersList
    {
        private readonly List<Supplier> _suppliers;

        public SuppliersList()
        {
            this._suppliers = new List<Supplier>();
        }

        public void AddSupplier(Supplier supplier)
        {
            this._suppliers.Add(supplier);
        }

        public SupplierListItem FindBestItem(Material material, int count, int maxPrice)
        {
            List<SupplierListItem> list = _suppliers
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
            Supplier perfectSupplier = _suppliers.Find(
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

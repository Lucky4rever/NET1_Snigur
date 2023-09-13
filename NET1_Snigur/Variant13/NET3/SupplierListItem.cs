using DOTNET.Variant13.NET3.Materials;

namespace DOTNET.Variant13.NET3
{
    class SupplierListItem
    {
        public Material Material { get; set; }
        public int MaxCount { get; set; }
        public decimal PriceForSet { get; set; }

        public SupplierListItem(Material material, int count, int price)
        {
            this.Material = material;
            this.MaxCount = count;
            this.PriceForSet = price;
        }

        public override string ToString()
        {
            return $"{this.Material} for {this.PriceForSet} for 1 set and with max count {this.MaxCount}";
        }
    }
}

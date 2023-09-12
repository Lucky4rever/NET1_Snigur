namespace DOTNET.Variant13.NET3
{
    class SuppliersListBuilder
    {
        private readonly SuppliersList _list;

        public SuppliersListBuilder()
        {
            this._list = new SuppliersList();
        }

        public void AddSupplier(Supplier supplier)
        {
            this._list.AddSupplier(supplier);
        }

        public SuppliersList Build()
        {
            return this._list;
        }
    }
}

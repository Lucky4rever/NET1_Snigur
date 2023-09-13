using DOTNET.Variant13.NET3;
using DOTNET.Variant13.NET3.Materials;
using System;

namespace DOTNET
{
    partial class Labs
    {
        public void Var13_Lab3()
        {
            Console.WriteLine("Variant 13\nVariant 3\n");

            Material brick1 = new Brick(BrickType.Ceramic, 100);
            Material brick2 = new Brick(BrickType.Clinker, 100);
            Material brick3 = new Brick(BrickType.Silicate, 100);
            Material concrete = new Concrete(1);
            Material slabs = new ReinforcedConcreteSlabs(10, 10, 3);



            Supplier supplier1 = new Supplier("Контора");

            SupplierListBuilder builder = new SupplierListBuilder();

            builder.AddNewPosition(new SupplierListItem(brick1, 45, 100));
            builder.AddNewPosition(new SupplierListItem(brick2, 40, 140));
            builder.AddNewPosition(new SupplierListItem(brick3, 80, 90));

            supplier1.SetItemList(builder.Build());



            Supplier supplier2 = new Supplier("Буд-матеріали");

            builder = new SupplierListBuilder();

            builder.AddNewPosition(new SupplierListItem(brick2, 30, 110));
            builder.AddNewPosition(new SupplierListItem(concrete, 1, 5));
            builder.AddNewPosition(new SupplierListItem(slabs, 10, 500));

            supplier2.SetItemList(builder.Build());



            SuppliersListBuilder suppliersListBuilder = new SuppliersListBuilder();

            suppliersListBuilder.AddSupplier(supplier1);
            suppliersListBuilder.AddSupplier(supplier2);

            SuppliersList suppliersList = suppliersListBuilder.Build();

            Console.WriteLine(suppliersList.FindBestItem(brick2, 20, 150));

        }
    }
}

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

            MaterialFabric fabric = new MaterialFabric();

            Material brick1 = fabric.CreateBrick(BrickType.Ceramic, 100);
            Material brick2 = fabric.CreateBrick(BrickType.Clinker, 100);
            Material brick3 = fabric.CreateBrick(BrickType.Silicate, 100);
            Material concrete = fabric.CreateConcrete(1);
            Material slabs = fabric.CreateReinforcedConcreteSlabs(10, 10, 3);


            Supplier supplier1 = new Supplier("Grand Supplier");

            supplier1.AddItemToList(new SupplierListItem(brick1, 45, 100));
            supplier1.AddItemToList(new SupplierListItem(brick2, 40, 140));
            supplier1.AddItemToList(new SupplierListItem(brick3, 80, 90));


            Supplier supplier2 = new Supplier("Буд-матеріали");

            supplier1.AddItemToList(new SupplierListItem(brick2, 30, 110));
            supplier1.AddItemToList(new SupplierListItem(concrete, 1, 5));
            supplier1.AddItemToList(new SupplierListItem(slabs, 10, 500));


            SuppliersList suppliersList = new SuppliersList();

            suppliersList.AddSupplier(supplier1);
            suppliersList.AddSupplier(supplier2);

            Console.WriteLine(suppliersList.FindBestItem(brick2, 20, 150));
        }
    }
}

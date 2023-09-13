using DOTNET.Variant20.NET5;
using System;

namespace DOTNET
{
    partial class Labs
    {
        public void Var20_Lab5()
        {
            Console.WriteLine("Variant 20\nVariant 1\n");

            StatusManager manager = new StatusManager();

            Grant grant = new Grant("Cool grant");

            grant.ChangeStatus(manager.Postponed());
            Console.WriteLine(grant.ToString());

            Grant otherGrant = new Grant("Other cool grant");
            Console.WriteLine(otherGrant.ToString());


            grant.ChangeStatus(manager.Confirmed());
            otherGrant.ChangeStatus(manager.Confirmed());

            Console.WriteLine(grant.ToString());
            Console.WriteLine(otherGrant.ToString());
        }
    }
}

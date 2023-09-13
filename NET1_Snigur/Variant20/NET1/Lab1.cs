using DOTNET.Variant20.NET1;
using DOTNET.Variant20.NET1.Invoker;
using System;

namespace DOTNET
{
    partial class Labs
    {
        public void Var20_Lab1()
        {
            Console.WriteLine("Variant 20\nVariant 1\n");

            Data.CheckCovenantDate();

            Variant20.NET1.Functional functional = new Variant20.NET1.Functional();
            Invoker invoker = new Invoker();

            //foreach (var task in functional.TaskMap)
            //{
            //    invoker.SetAction(new Command(task.Value));

            //    invoker.StartDoingAction();
            //}

            Console.Write("Print number of task you want to do: ");
            int TaskNumber = int.Parse(Console.ReadLine());

            //OC S.(O).L.I.D.
            invoker.SetAction(new Command(functional.TaskMap[Variant20.NET1.TaskNumber.GetGeneralTaskNumber(TaskNumber)]));

            Console.WriteLine($"Running task №{TaskNumber}: ");
            invoker.StartDoingAction();

            //с# Code convention (name convention) 

            //decimal vs float (Why does decimal used for $) log2 vs 10  

            //TODO all of methods should return a selected values 

            // Main -> (UIController/Command/Dictionary<Enum,Action>)) ((Command initialization logic)) (know nothing about data storage) -> IDataManager(SELECT and return Entity) -> DataHolder/Context ((datagoler initializer)) storage collections of our model 

            // consistency 

            //-> DataContext : IDataContext 
            // DataManager::ctor(IDataContext) 
            //TODO: read about services collection as a way to implement DI 
        }
    }
}

using System;
//using NET1_Snigur.Example.NET1;
//using NET1_Snigur.Variant15;
using NET1_Snigur.Variant20.NET1;
using NET1_Snigur.Variant20.NET1.Invoker;

namespace NET1_Snigur {
    class Program {
        private static void Main() {

            Lab1();

            Console.ReadLine();
        }

        private static void Lab1()
        {
            Data.CheckCovenantDate();

            Functional functional = new Functional();
            Invoker invoker = new Invoker();

            //foreach (var task in functional.TaskMap)
            //{
            //    invoker.SetAction(new Command(task.Value));

            //    invoker.StartDoingAction();
            //}

            Console.Write("Print number of task you want to do: ");
            int TaskNumber = int.Parse(Console.ReadLine());

            invoker.SetAction(new Command(functional.TaskMap[(Functional.TaskNumber)(TaskNumber - 1)]));

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

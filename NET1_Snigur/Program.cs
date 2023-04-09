using System;
using System.Activities;
using System.Collections.Generic;
//using NET1_Snigur.Example.NET1;
//using NET1_Snigur.Variant15;
using DOTNET.Variant20.NET1;
using DOTNET.Variant20.NET1.Invoker;
using DOTNET.Variant20.NET2.XMLConverter;
using DOTNET.Variant20.NET2.ComponentCreator;

using NET1 = DOTNET.Variant20.NET1;
using NET2 = DOTNET.Variant20.NET2;

namespace DOTNET {
    class Program {
        private static void Main() {

            //Lab1();
            Lab2();

            Console.ReadLine();
        }

        private static void Lab1()
        {
            Data.CheckCovenantDate();

            NET1.Functional functional = new NET1.Functional();
            Invoker invoker = new Invoker();

            //foreach (var task in functional.TaskMap)
            //{
            //    invoker.SetAction(new Command(task.Value));

            //    invoker.StartDoingAction();
            //}

            Console.Write("Print number of task you want to do: ");
            int TaskNumber = int.Parse(Console.ReadLine());

            //OC S.(O).L.I.D.
            invoker.SetAction(new Command(functional.TaskMap[NET1.TaskNumber.GetGeneralTaskNumber(TaskNumber)]));

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

        private static void Lab2()
        {
            //  Example program:
            //Examples.NET2.TestProgram.StartProgram();

            //==================================Fill data======================================

            XMLConverterContext converter = new XMLConverterContext();

            converter.SetStrategy(new CarsXMLConverter());
            Data.Cars = (List<Car>)converter.ConvertFromXML("cars");

            converter.SetStrategy(new ClientsXMLConverter());
            Data.Clients = (List<Client>)converter.ConvertFromXML("clients");

            converter.SetStrategy(new CovenantsXMLConverter());
            Data.Covenants = (List<Covenant>)converter.ConvertFromXML("covenants");

            //converter.SetStrategy(new CarsXMLConverter());
            //converter.ConvertToXML("cars", Data.Cars);

            //ComponentCreatorContext componentCreator = new ComponentCreatorContext();
            //componentCreator.SetStrategy(new ClientComponentCreator());
            //componentCreator.NewComponent();
            //Console.WriteLine(Data.Clients[Data.Clients.Count - 1]);


            //====================================Program======================================

            NET2.Functional functional = new NET2.Functional();
            Invoker invoker = new Invoker();

            //Console.Write("Print number of task you want to do: ");
            //int TaskNumber = int.Parse(Console.ReadLine());
            //invoker.SetAction(new Command(functional.TaskMap[(NET2.Functional.TaskNumber)TaskNumber]));

            //Console.WriteLine($"Running action {TaskNumber}...");
            //invoker.StartDoingAction();


            invoker.StartDoingBlockOfAction(functional.TaskMap);
        }
    }
}

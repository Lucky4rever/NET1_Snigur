using DOTNET.Variant20.NET1;
using DOTNET.Variant20.NET1.Invoker;
using DOTNET.Variant20.NET2.XMLConverter;
using System;
using System.Collections.Generic;

namespace DOTNET
{
    partial class Labs
    {
        public void Var20_Lab2()
        {
            Console.WriteLine("Variant 20\nVariant 2\n");

            //  Example program:
            //Examples.NET2.TestProgram.StartProgram();

            //==================================Fill data======================================

            //==============Convert from XML:
            XMLConverterContext converter = new XMLConverterContext();

            converter.SetStrategy(new CarsXMLConverter());
            Data.Cars = (List<Car>)converter.ConvertFromXML();

            converter.SetStrategy(new ClientsXMLConverter());
            Data.Clients = (List<Client>)converter.ConvertFromXML();

            converter.SetStrategy(new CovenantsXMLConverter());
            Data.Covenants = (List<Covenant>)converter.ConvertFromXML();

            //============== Convert to XML:
            //XMLConverterContext converter = new XMLConverterContext();

            //converter.SetStrategy(new CarsXMLConverter());
            //converter.ConvertToXML(Data.Cars);

            //converter.SetStrategy(new ClientsXMLConverter());
            //converter.ConvertToXML(Data.Clients);

            //converter.SetStrategy(new CovenantsXMLConverter());
            //converter.ConvertToXML(Data.Covenants);


            //Create new member:
            //ComponentCreatorContext componentCreator = new ComponentCreatorContext();
            //componentCreator.SetStrategy(new ClientComponentCreator());
            //componentCreator.NewComponent();

            //Console.WriteLine(Data.Clients[Data.Clients.Count - 1]);


            //====================================Program======================================

            Variant20.NET2.FunctionalBuilder builder = new Variant20.NET2.FunctionalBuilder();
            builder.SetCarsDocument(CarsXMLConverter.xmlFileName, CarsXMLConverter.xsdFileName);
            builder.SetClientsDocument(ClientsXMLConverter.xmlFileName, ClientsXMLConverter.xsdFileName);
            builder.SetCovenantsDocument(CovenantsXMLConverter.xmlFileName, CovenantsXMLConverter.xsdFileName);

            Variant20.NET2.Functional functional = builder.Build();
            Invoker invoker = new Invoker();

            //Console.Write("Print number of task you want to do: ");
            //int TaskNumber = int.Parse(Console.ReadLine());
            //invoker.SetAction(new Command(functional.TaskMap[NET2.TaskNumber.GetGeneralTaskNumber(TaskNumber)].Output()));

            //Console.WriteLine($"Running action {TaskNumber}...");
            //invoker.StartDoingAction();


            invoker.SetBlockOfAction(functional.TaskMap);
            invoker.StartDoingBlockOfAction();
        }
    }
}

using DOTNET.Variant13.NET3;
using DOTNET.Variant13.NET3.Materials;
using DOTNET.Variant13.NET4;
using DOTNET.Variant13.NET5;

using DOTNET.Variant20.NET1;
using DOTNET.Variant20.NET1.Invoker;
using DOTNET.Variant20.NET2.XMLConverter;
using DOTNET.Variant20.NET3;
using DOTNET.Variant20.NET3.AbstractFactory;
using DOTNET.Variant20.NET3.Shape;
using DOTNET.Variant20.NET4;
using DOTNET.Variant20.NET4.Documents;
using DOTNET.Variant20.NET5;

using System;
using System.Collections.Generic;

namespace DOTNET {
    class Program {
        private static void Main() {

            //Var20_Lab1();
            //Var20_Lab2();
            //Var20_Lab3();
            //Var20_Lab4();
            //Var20_Lab5();

            //Var13_Lab3();
            Var13_Lab4();
            //Var13_Lab5();

            Console.ReadLine();
        }

        private static void Var13_Lab3()
        {
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

        private static void Var13_Lab4()
        {
            RecipeStorage storage = new RecipeStorage();

            Doctor doctor = new Doctor("Snigur Pavlo", DoctorPosition.Therapist);

            Patient patient1 = new Patient("Andrey Semko");
            Patient patient2 = new Patient("Dmitry Manov");
            Patient patient3 = new Patient("Grisha Mishanov");

            RecipeBuilder builder = new RecipeBuilder();

            builder.SetDescription("Antibiotics");
            builder.SetDoctor(doctor);
            builder.SetPatient(patient1);
            builder.SetEndDate(new DateTime(2023, 9, 9));

            storage.AddRecipe(builder.Build());

            builder = new RecipeBuilder();

            builder.SetDescription("Anti-inflammatory drug");
            builder.SetDoctor(doctor);
            builder.SetPatient(patient2);
            builder.SetEndDate(DateTime.Now.AddDays(14));

            storage.AddRecipe(builder.Build());

            builder = new RecipeBuilder();

            builder.SetDescription("Vitamins");
            builder.SetDoctor(doctor);
            builder.SetPatient(patient3);
            builder.SetEndDate(DateTime.Now.AddDays(30));

            storage.AddRecipe(builder.Build());

            Console.WriteLine("\nShow all recipes\n");

            storage.CheckDate();

            foreach (var recipe in storage.GetRecipes())
            {
                Console.WriteLine(recipe);
            }

            Console.WriteLine("Increase end date\n");

            storage.IncreaseEndDate(storage.GetPatientRecipe(patient2), 20);

            Console.WriteLine(storage.GetPatientRecipe(patient2));
        }

        private static void Var13_Lab5()
        {
            Student student1 = new Student("Снігур Павло");

            student1.GiveTask("Вивести інформацію про завдання.");



            student1.MakeSolution(action: () =>
            {
                throw new Exception();
            });

            student1.Resolve();

            Console.WriteLine("Atempt 1");
            Console.WriteLine(student1.ShowTask());



            student1.MakeSolution(action: () =>
            {
                Console.WriteLine(student1.ShowTask());
            });

            student1.Resolve();

            student1.SetAssessment(12);

            Console.WriteLine(student1.ShowTask());
        }

        private static void Var20_Lab1()
        {
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

        private static void Var20_Lab2()
        {
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

        private static void Var20_Lab3()
        {
            ShapeFactory factory = ShapeFactory.GetInstance();

            Cycle cycle1 = factory.CreateCycle(1);
            Cycle cycle2 = factory.CreateCycle(8);
            Rectangle rectangle = factory.CreateRectangle(8, 19);
            Triangle triangle = factory.CreateTriangle(3, 4, 5);

            PolygonBuilder builder = new PolygonBuilder();

            builder.AddCycle(cycle1);
            builder.AddCycle(cycle2);
            builder.AddRectangle(rectangle);
            builder.AddTriangle(triangle);

            Polygon shape = builder.Build();

            shape.PrintInfo();
            shape.PrintAllAreas();
            shape.PrintAllPerimeters();
        }

        private static void Var20_Lab4()
        {
            PassportBuilder passportBuilder = new PassportBuilder();
            passportBuilder.AddBirthDate(new DateTime(2004, 2, 9));
            passportBuilder.AddExpiryDate(new DateTime(2024, 5, 24));
            passportBuilder.AddIssuedBy("Vovk E. A.");
            passportBuilder.AddName("Snigur P. V.");
            passportBuilder.AddSex("man");
            passportBuilder.AddSeries("AA");
            passportBuilder.AddNumber("123456");

            Passport passport = passportBuilder.Build();

            BankCardBuilder bankCardBuilder = new BankCardBuilder();
            bankCardBuilder.AddExpiryDate(new DateTime(2004, 2, 9));
            bankCardBuilder.AddCVV("233");
            bankCardBuilder.AddName("Snigur P. V.");
            bankCardBuilder.AddNumber("1234-5678-9012-3456");
            bankCardBuilder.AddType("VISA");

            BankCard bankCard = bankCardBuilder.Build();

            UECFacade uec = new UECFacade();
            uec.AddDocument(DocumentType.Passport, passport);
            uec.GetDocument(DocumentType.Passport)?.GetInfo();

            uec.AddDocument(DocumentType.BankCard, bankCard);

            passportBuilder.AddExpiryDate(new DateTime(2029, 5, 24));
            Passport newPassport = passportBuilder.Build();

            uec.AddDocument(DocumentType.Passport, newPassport);
            uec.GetDocument(DocumentType.BankCard)?.GetInfo();
            uec.GetDocument(DocumentType.Passport)?.GetInfo();
        }

        private static void Var20_Lab5()
        {
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

using DOTNET.Variant13.NET5;
using System;

namespace DOTNET
{
    partial class Labs
    {
        public void Var13_Lab5()
        {
            Console.WriteLine("Variant 13\nVariant 5\n");

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
    }
}

using System;

namespace DOTNET.Variant13.NET5
{
    class Lab5
    {
        private static Lab5 _instance;

        private Lab5() { }

        public static Lab5 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Lab5();
            }

            return _instance;
        }

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

            Console.WriteLine();
        }
    }
}

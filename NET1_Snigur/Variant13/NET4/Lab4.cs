using System;

namespace DOTNET.Variant13.NET4
{
    class Lab4
    {
        private static Lab4 _instance;

        private Lab4() { }

        public static Lab4 GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Lab4();
            }

            return _instance;
        }

        public void Var13_Lab4()
        {
            Console.WriteLine("Variant 13\nVariant 4\n");

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

            Console.WriteLine();
        }
    }
}

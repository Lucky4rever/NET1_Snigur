using System;

namespace DOTNET.Variant13.NET4
{
    class RecipeBuilder
    {
        private readonly Recipe Recipe;

        public RecipeBuilder()
        {
            this.Recipe = new Recipe();
        }

        public void SetDescription(string description)
        {
            this.Recipe.Description = description;
        }

        public void SetDoctor(Doctor doctor)
        {
            this.Recipe.Doctor = doctor;
        }

        public void SetPatient(Patient patient)
        {
            this.Recipe.Patient = patient;
        }

        public void SetEndDate(DateTime endDate)
        {
            this.Recipe.EndDate = endDate.Date;
        }

        public Recipe Build()
        {
            return this.Recipe;
        }
    }
}

using System;

namespace DOTNET.Variant13.NET4
{
    class RecipeBuilder
    {
        private readonly Recipe _recipe;

        public RecipeBuilder()
        {
            this._recipe = new Recipe();
        }

        public void SetDescription(string description)
        {
            this._recipe.Description = description;
        }

        public void SetDoctor(Doctor doctor)
        {
            this._recipe.Doctor = doctor;
        }

        public void SetPatient(Patient patient)
        {
            this._recipe.Patient = patient;
        }

        public void SetEndDate(DateTime endDate)
        {
            this._recipe.EndDate = endDate.Date;
        }

        public Recipe Build()
        {
            return this._recipe;
        }
    }
}

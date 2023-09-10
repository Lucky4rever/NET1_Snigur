using System;
using System.Text;

namespace DOTNET.Variant13.NET4
{
    class Recipe
    {
        public string Description;
        public Doctor Doctor;
        public Patient Patient;
        public DateTime EndDate;

        public Recipe() { }

        public Recipe(string description, Doctor doctor, Patient patient, DateTime endDate)
        {
            this.Description = description;
            this.Doctor = doctor;
            this.Patient = patient;
            this.EndDate = endDate.Date;
        }

        public void IncreaseEndDate(double days)
        {
            this.EndDate = this.EndDate.AddDays(days);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Description: {this.Description}");
            builder.AppendLine($"Doctor: {this.Doctor.Name} ({this.Doctor.Position})");
            builder.AppendLine($"Patient: {this.Patient.Name}");
            builder.AppendLine($"End date: {this.EndDate:dd.MM.yyyy}");

            return builder.ToString();
        }
    }
}

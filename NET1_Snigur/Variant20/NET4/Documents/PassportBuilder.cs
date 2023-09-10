using System;

namespace DOTNET.Variant20.NET4.Documents
{
    class PassportBuilder
    {
        private readonly Passport _passport;

        public PassportBuilder()
        {
            this._passport = new Passport();
        }

        public void AddName(string Name)
        {
            this._passport.Name = Name;
        }

        public void AddBirthDate(DateTime BirthDate)
        {
            this._passport.BirthDate = BirthDate;
        }

        public void AddSex(string Sex)
        {
            this._passport.Sex = Sex;
        }

        public void AddSeries(string Series)
        {
            this._passport.Series = Series;
        }

        public void AddNumber(string Number)
        {
            this._passport.Number = Number;
        }

        public void AddIssuedBy(string IssuedBy)
        {
            this._passport.IssuedBy = IssuedBy;
        }

        public void AddExpiryDate(DateTime ExpiryDate)
        {
            this._passport.ExpiryDate = ExpiryDate;
        }

        public Passport Build()
        {
            return this._passport;
        }
    }
}

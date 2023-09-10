using System;

namespace DOTNET.Variant20.NET4.Documents
{
    class InsurancePolicyBuilder
    {
        private readonly InsurancePolicy _insurancePolicy;

        public InsurancePolicyBuilder()
        {
            this._insurancePolicy = new InsurancePolicy();
        }

        public void AddNumber(string Number)
        {
            this._insurancePolicy.Number = Number;
        }

        public void AddType(string Type)
        {
            this._insurancePolicy.Type = Type;
        }

        public void AddPeriod(string Period)
        {
            this._insurancePolicy.Period = Period;
        }

        public void AddAmount(decimal Amount)
        {
            this._insurancePolicy.Amount = Amount;
        }

        public void AddCompany(string Company)
        {
            this._insurancePolicy.Company = Company;
        }

        public void AddConditions(string Conditions)
        {
            this._insurancePolicy.Conditions = Conditions;
        }

        public InsurancePolicy Build()
        {
            return this._insurancePolicy;
        }
    }
}

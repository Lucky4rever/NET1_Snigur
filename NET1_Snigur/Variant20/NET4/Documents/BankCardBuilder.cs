using System;

namespace DOTNET.Variant20.NET4.Documents
{
    class BankCardBuilder
    {
        private readonly BankCard _bankCard;

        public BankCardBuilder()
        {
            this._bankCard = new BankCard();
        }

        public void AddNumber(string Number)
        {
            this._bankCard.Number = Number;
        }

        public void AddType(string Type)
        {
            this._bankCard.Type = Type;
        }

        public void AddName(string Name)
        {
            this._bankCard.Name = Name;
        }

        public void AddExpiryDate(DateTime ExpiryDate)
        {
            this._bankCard.ExpiryDate = ExpiryDate;
        }

        public void AddCVV(string CVV)
        {
            this._bankCard.CVV = CVV;
        }

        public BankCard Build()
        {
            return this._bankCard;
        }
    }
}

using System;

namespace NET1_Snigur.Variant20.NET1
{
    internal class Deposit<T> : Money<T>
    {
        public new T Amount { get; set; }
        public DateTime ReturnDate { get; }

        public Deposit(T amount, DateTime returnDate) : base(amount, 0)
        {
            Amount = amount;
            SelectedCurrency = Currency.USD;
            ReturnDate = returnDate;
        }

        public Deposit(T amount, Currency currency, DateTime returnDate) : base(amount, currency)
        {
            Amount = amount;
            SelectedCurrency = currency;
            ReturnDate = returnDate;
        }

        public void CheckDate()
        {
            try
            {
                if (ReturnDate <= DateTime.Today)
                {
                    Amount = default;
                }
            }
            catch (ArgumentNullException) { };
        }
    }
}

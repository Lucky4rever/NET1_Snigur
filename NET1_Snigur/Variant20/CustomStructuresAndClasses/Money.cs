using System;

namespace NET1_Snigur.Variant20
{
    public class Money<T> : IMoney<T>
    {
        public T Amount { get; }

        public Currency SelectedCurrency { get; set; }
        public enum Currency
        {
            UKR, USD, EUR
        }

        public string Text
        {
            get
            {
                return AmountToText();
            }
        }

        public Money(T amount)
        {
            Amount = amount;
            SelectedCurrency = Currency.USD;
        }

        public Money(T amount, Currency currency)
        {
            Amount = amount;
            SelectedCurrency = currency;
        }

        //public void ChangeCurrency(Currency currency)
        //{
        //    SelectedCurrency = currency;
        //}

        private string AmountToText()
        {
            string sumText;
            switch (SelectedCurrency)
            {
                case Currency.UKR:
                    sumText = $"{Amount} UKR";
                    break;
                case Currency.USD:
                    sumText = $"$ {Amount}";
                    break;
                case Currency.EUR:
                    sumText = $"€ {Amount}";
                    break;

                default: throw new NotImplementedException("There is no text representation converter for this currency!");
            }
            return sumText.Trim();
        }
    }
}
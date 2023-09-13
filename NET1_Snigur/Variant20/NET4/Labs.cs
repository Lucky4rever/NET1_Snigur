using DOTNET.Variant20.NET4;
using DOTNET.Variant20.NET4.Documents;
using System;

namespace DOTNET
{
    partial class Labs
    {
        public void Var20_Lab4()
        {
            Console.WriteLine("Variant 20\nVariant 1\n");

            PassportBuilder passportBuilder = new PassportBuilder();
            passportBuilder.AddBirthDate(new DateTime(2004, 2, 9));
            passportBuilder.AddExpiryDate(new DateTime(2024, 5, 24));
            passportBuilder.AddIssuedBy("Vovk E. A.");
            passportBuilder.AddName("Snigur P. V.");
            passportBuilder.AddSex("man");
            passportBuilder.AddSeries("AA");
            passportBuilder.AddNumber("123456");

            Passport passport = passportBuilder.Build();

            BankCardBuilder bankCardBuilder = new BankCardBuilder();
            bankCardBuilder.AddExpiryDate(new DateTime(2004, 2, 9));
            bankCardBuilder.AddCVV("233");
            bankCardBuilder.AddName("Snigur P. V.");
            bankCardBuilder.AddNumber("1234-5678-9012-3456");
            bankCardBuilder.AddType("VISA");

            BankCard bankCard = bankCardBuilder.Build();

            UECFacade uec = new UECFacade();
            uec.AddDocument(DocumentType.Passport, passport);
            uec.GetDocument(DocumentType.Passport)?.GetInfo();

            uec.AddDocument(DocumentType.BankCard, bankCard);

            passportBuilder.AddExpiryDate(new DateTime(2029, 5, 24));
            Passport newPassport = passportBuilder.Build();

            uec.AddDocument(DocumentType.Passport, newPassport);
            uec.GetDocument(DocumentType.BankCard)?.GetInfo();
            uec.GetDocument(DocumentType.Passport)?.GetInfo();
        }
    }
}

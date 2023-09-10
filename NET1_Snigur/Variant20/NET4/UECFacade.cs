using DOTNET.Variant20.NET4.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET4
{
    class UECFacade : IUniversalCard
    {
        private readonly UEC _uec;

        public UECFacade()
        {
            this._uec = new UEC();
        }

        public void AddDocument(DocumentType type, IDocument document)
        {
            _uec.AddDocument(type, document);
        }

        public void AddDocument(InsurancePolicyBuilder insurancePolicyBuilder)
        {
            InsurancePolicy insurancePolicy = insurancePolicyBuilder.Build();
            _uec.AddDocument(DocumentType.InstancePolicy, insurancePolicy);
        }

        public void AddDocument(PassportBuilder passportBuilder)
        {
            Passport passport = passportBuilder.Build();
            _uec.AddDocument(DocumentType.Passport, passport);
        }

        public void AddDocument(BankCardBuilder bankCardBuilder)
        {
            BankCard bankCard = bankCardBuilder.Build();
            _uec.AddDocument(DocumentType.BankCard, bankCard);
        }

        public void RemoveDocument(DocumentType type)
        {
            _uec.RemoveDocument(type);
        }

        public IDocument GetDocument(DocumentType type)
        {
            return _uec.GetDocument(type);
        }
    }
}

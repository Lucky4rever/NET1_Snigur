using DOTNET.Variant20.NET4.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant20.NET4
{
    public enum DocumentType
    {
        Passport,
        BankCard,
        InstancePolicy,
        BirthCertificate
        //...
    }

    class UEC : IUniversalCard
    {
        private readonly Dictionary<DocumentType, IDocument> _documents;

        public UEC()
        {
            this._documents = new Dictionary<DocumentType, IDocument>();
        }

        public void AddDocument(DocumentType type, IDocument document)
        {
            this._documents[type] = document;
        }

        public void RemoveDocument(DocumentType type)
        {
            this._documents.Remove(type);
        }

        public IDocument GetDocument(DocumentType type)
        {
            return this._documents[type];
        }
    }
}

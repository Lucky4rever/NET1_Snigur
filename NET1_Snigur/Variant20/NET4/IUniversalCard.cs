using DOTNET.Variant20.NET4.Documents;

namespace DOTNET.Variant20.NET4
{
    interface IUniversalCard
    {
        void AddDocument(DocumentType type, IDocument document);
        void RemoveDocument(DocumentType type);
        IDocument GetDocument(DocumentType type);
    }
}

using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document
    {
        public string Number { get; private set; }
        public EDocumentType DocumentType { get; private set; }

        public Document(string number, EDocumentType documentType)
        {
            Number = number;
            DocumentType = documentType;
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCPNJIsInvalid()
        {
            var document = new Document("7047", EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid); 
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPNJIsValid()
        {
            var document = new Document("70471156000136", EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid); 
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("2473", EDocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsValid()
        {
            var document = new Document("24730190025", EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}
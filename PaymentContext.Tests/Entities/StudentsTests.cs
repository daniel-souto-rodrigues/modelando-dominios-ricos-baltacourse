using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void AddAssinatura()
        {
            var subscription = new Subscription(null);

            var student = new Student
            (
                new Name("Daniel", "Rodrigues"),
                new Document("13164094012", EDocumentType.CPF),
                new Email("testmail@gmail.com")
            );

            student.AddSubscription(subscription);
        }
    }
}
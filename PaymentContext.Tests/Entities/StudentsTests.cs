using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{


    [TestClass]
    public class StudentsTests
    {
        private readonly Name _name = new Name("Bruce", "Wayne");
        private readonly Document _document = new Document("23343072036", EDocumentType.CPF);
        private readonly Email _email = new Email("validMail@mail.com");
        private readonly Subscription _sub = new Subscription(null);
        private readonly Address _address = new Address("Rua 1", "234", "bairro legal", "rio de janeiro", "RJ", "BR", "15444845");
        private readonly Payment _payment;
        private readonly Student _student;

        public StudentsTests()
        {
            _student = new Student(_name, _document, _email);
            _payment = new PayPalPayment("1214545", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "WAYNE CORP.", _email);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {    
            _sub.AddPayment(_payment);
            _student.AddSubscription(_sub);
            _student.AddSubscription(_sub);

            Assert.IsTrue(_student.Invalid);
        }


        // [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_sub);
            Assert.IsTrue(_student.Invalid);
        }
        
        // [TestMethod]
        public void ShouldReturnSucessWhenAddSubscription()
        {
            _sub.AddPayment(_payment);
            _student.AddSubscription(_sub);
            Assert.IsTrue(_student.Valid);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void AddAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Daniel", "Rodrigues", "12345674408", "emailexample@gmail.com");
            student.AddSubscription(subscription);
        }

    }
}
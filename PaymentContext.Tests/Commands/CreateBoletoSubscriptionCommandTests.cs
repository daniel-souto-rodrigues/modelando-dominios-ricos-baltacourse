using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var command = new CreateBoletoSubscriptionCommand{
                FirstName = ""
            };

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }

    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using Acme.Common;

namespace ACM.BLTest
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void PlaceOrder_Test()
        {
            // Arrange
            var orderController = new OrderController();
            var customer = new Customer() {EmailAddress = "fbaggins@hobbiton.me" };
            var order = new Order();
            var payment = new Payment() { PaymentType = PaymentType.CreditCard };

            // Act
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders:true, getEmailReceipt:true);

            // Assert
            Assert.AreEqual(true, op.Success);
            Assert.AreEqual(0, op.MessageList.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_Test_NullCustomer()
        {
            // Arrange
            var orderController = new OrderController();
            Customer customer = null;
            var order = new Order();
            var payment = new Payment() { PaymentType = PaymentType.CreditCard };

            // Act
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true, getEmailReceipt: true);

            // Assert
            // since we are expecting an exception, we don't need any asserts
        }

        [TestMethod]
        public void PlaceOrder_Test_InvalidEmail()
        {
            // Arrange
            var orderController = new OrderController();
            var customer = new Customer() { EmailAddress = "" };
            var order = new Order();
            var payment = new Payment() { PaymentType = PaymentType.CreditCard };

            // Act
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true, getEmailReceipt: true);

            // Assert
            Assert.AreEqual(true, op.Success);
            Assert.AreEqual(1, op.MessageList.Count);
            Assert.AreEqual("Email address is empty or null", op.MessageList[0]);
        }
    }
}

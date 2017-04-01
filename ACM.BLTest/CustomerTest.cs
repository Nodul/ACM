using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            // Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";
            customer.LastName = "Baggins";

            string expected = "Baggins, Bilbo";
            // Act
            string actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            // Arrange
            Customer customer = new Customer();
            customer.LastName = "Baggins";

            string expected = "Baggins";
            // Act
            string actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            // Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bilbo";

            string expected = "Bilbo";
            // Act
            string actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomerStaticTest()
        {
            var c1 = new Customer();
            c1.FirstName = "Frodo";
            Customer.InstanceCount++;

            var c2 = new Customer();
            c2.FirstName = "Bilbo";
            Customer.InstanceCount++;

            var c3 = new Customer();
            c3.FirstName = "Sam";
            Customer.InstanceCount++;

            Assert.AreEqual(3, Customer.InstanceCount);
        }
        [TestMethod]
        public void CustomerValidateValid()
        {
            // Arrange
            var customer = new Customer();
            customer.LastName = "Baggins";
            customer.EmailAddress = "f.baggins@hobbiton.me";

            var expected = true;
            // Act
            var actual = customer.IsValid;
            // Assert
            Assert.AreEqual(expected,actual);
            
        }
        [TestMethod]
        public void CustomerValidateMissingLastName()
        {
            // Arrange
            var customer = new Customer();
            customer.EmailAddress = "f.baggins@hobbiton.me";

            var expected = false;
            // Act
            var actual = customer.IsValid;
            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ValidateMissingEmailAddress()
        {
            // Arrange
            var customer = new Customer();
            customer.LastName = "Baggins";

            var expected = false;
            // Act
            var actual = customer.IsValid;
            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void MyTestMethod()
        {
            //var expected = ""
        }

    }
}

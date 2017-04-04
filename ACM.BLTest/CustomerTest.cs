using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullName_Test()
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
        public void FullName_Test_FirstNameEmpty()
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
        public void FullName_Test_LastNameEmpty()
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
        public void CustomerStatic_Test()
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
        public void CustomerValidate_Test()
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
        public void CustomerValidateMissingLastName_Test()
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
        public void ValidateMissingEmailAddress_Test()
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
        public void CalculatePercentOfGoalStep_Test_Valid()
        {
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "2000";
            decimal expected = 40M;

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void CalculatePercentOfGoalStep_Test_ValidAndSame()
        {
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "5000";
            decimal expected = 100M;

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStep_Test_ValidActualIsZero()
        {
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "0";
            decimal expected = 0M;

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStep_Test_ValidGoalIsZero()
        {
            var customer = new Customer();
            string goalSteps = "0";
            string actualSteps = "5000";
            decimal expected = 0M;

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStep_Test_ValidBothZero()
        {
            var customer = new Customer();
            string goalSteps = "0";
            string actualSteps = "0";
            decimal expected = 0M;

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

            Assert.AreEqual(expected, actual);
            
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStep_Test_GoalIsNull()
        {
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStep_Test_GoalIsEmpty()
        {
            var customer = new Customer();
            string goalSteps = "";
            string actualSteps = "2000";

            var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStep_Test_GoalIsNotNumeric()
        {
            var customer = new Customer();
            string goalSteps = "Two thousand and fifty";
            string actualSteps = "2000";          

            try
            {
                var actual = customer.CalculatePercentOfGoalStep(goalSteps, actualSteps);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("Goal must be numeric.", e.Message);
                throw;
            }
        }
    }
}

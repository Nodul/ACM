using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System.Collections.Generic;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void CustomerRepoRetrieveExisting()
        {
            var customerRepo = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };

            var actual = customerRepo.Retrieve(1);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CustomerRepoRetrieveExistingInvalid()
        {
            var customerRepo = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "bbaggins@hobbiton.me@internet",
                FirstName = "Bilbosaurus",
                LastName = "Bagginson"
            };

            var actual = customerRepo.Retrieve(1);

            Assert.AreNotEqual(expected, actual);

        }

        [TestMethod]
        public void CustomerRepoRetrieveExistingWithAddress()
        {
            var CustomerRepo = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                addressList = new List<Address>()
                {
                    new Address()
                    {
                            AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144"

                    },
                    new Address()
                    {
                          AddressType = 2,
                             StreetLine1 = "Green Dragon",
                City = "Bywater",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "146"
                    }
                }

            };

            var actual = CustomerRepo.Retrieve(1);

            Assert.AreEqual(expected, actual);

            for (int i = 0; i < 1; i++)
            {
                //bool temp = expected.addressList[i].Equals(actual.addressList[i]);
                //Assert.IsTrue(temp);
               // Assert.AreEqual(expected.addressList[i],actual.addressList[i]);
            }

        }
    }
}

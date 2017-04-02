using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void FindTest_ExistingCustomer()
        {
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.Find(customerList, 2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.CustomerID);
            Assert.AreEqual("Baggins", result.LastName);
            Assert.AreEqual("Bilbo", result.FirstName);
        }

        [TestMethod]
        public void FindTest_NotFound()
        {
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.Find(customerList, 509); // non existing customer

            Assert.IsNull(result);

        }

        [TestMethod]
        public void FindSortByName()
        {
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.SortByName(customerList);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.First().CustomerID);
            Assert.AreEqual("Baggins", result.First().LastName);
            Assert.AreEqual("Bilbo", result.First().FirstName);
        }

        [TestMethod]
        public void FindSortByNameInReverse()
        {
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.SortByNameInReverse(customerList);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.First().CustomerID);
            Assert.AreEqual("Shire Administration Agency", result.First().LastName);

        }

        [TestMethod]
        public void FindSortByType()
        {
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.SortByType(customerList);

            Assert.IsNotNull(result);
            Assert.AreEqual(CustomerTypes.Educator, result.Last().CustomerTypeID.CustomerTypeID);

        }

        [TestMethod]
        public void RetrieveEmptyList()
        {
            CustomerRepository repo = new CustomerRepository();
            var result = repo.RetrieveEmptyList();

            foreach (Customer c in result)
            {
                Console.WriteLine("C: " + c.ToString());
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
            //Assert.AreEqual(null, result.Last().CustomerType);

        }

        [TestMethod]
        public void GetNamesTest()
        {
            CustomerRepository repo = new CustomerRepository();
            var names = repo.Retrieve();

            var result = repo.GetNames(names);

            foreach (var c in result)
            {
                Console.WriteLine("C: " + c.ToString());
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
            //Assert.AreEqual(null, result.Last().CustomerType);

        }
        [TestMethod]
        public void GetNamesAndEmailTest()
        {
            CustomerRepository repo = new CustomerRepository();
            var names = repo.Retrieve();

            var result = repo.GetNamesAndEmail(names);

            // because of REASONS this won't really work with GetNamesAndEmail
            //foreach (var c in result)
            //{
            //    Console.WriteLine("C: " + c.ToString());
            //}

            // Assert.IsNotNull(result);
            // Assert.IsTrue(result.Count() > 0);
            //Assert.AreEqual(null, result.Last().CustomerType);

            // NOT really a test because no assertions
        }
        [TestMethod]
        public void GetNamesAndTypesTest()
        {
            CustomerRepository repo = new CustomerRepository();
            var names = repo.Retrieve();

            CustomerTypeRepository typeRepo = new CustomerTypeRepository();
            var types = typeRepo.Retrieve();

            var result = repo.GetNamesAndTypes(names, types);

            // NOT really a test because no assertions

        }

        [TestMethod]
        public void GetOverdueCustomersTest()
        {
            CustomerRepository repo = new CustomerRepository();
            var customerList = repo.Retrieve();

            var result = repo.GetOverdueCustomers(customerList);

            Console.WriteLine("Customers with overdue invoices:");
            foreach (var c in result)
            {
                Console.WriteLine(c.FullName);
            }

            Assert.IsNotNull(result);
            //Assert.IsTrue(result.Count() > 0);
            //Assert.AreEqual(null, result.Last().CustomerType);

        }

    }
}

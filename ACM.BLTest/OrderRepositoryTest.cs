using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;
using System.Collections.Generic;

namespace ACM.BLTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void OrderRepoRetrieveExisting()
        {
            var orderRepo = new OrderRepository();
            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(2014, TimeSpan.Zero)

            };

            var actual = orderRepo.Retrieve(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderRepoRetrieveExistingInvalid()
        {
            var orderRepo = new OrderRepository();
            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(214, TimeSpan.Zero)
            };

            var actual = orderRepo.Retrieve(10);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void RetrieveOrderDisplayTest()
        {
            var orderRepo = new OrderRepository();
            var expected = new OrderDisplay()
            {
                FirstName = "Bilbo",
                LastName = "Baggins",
                OrderDate = new DateTimeOffset(2014, TimeSpan.Zero),
                ShippingAddress = new Address()
                {
                    AddressType = 1,
                    StreetLine1 = "Bag End",
                    StreetLine2 = "Bagshot row",
                    City = "Hobbiton",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "144"

                },

                OrderDisplayItemList = new List<OrderDisplayItem>()
                {
                     new OrderDisplayItem()
                    {
                     ProductName = "Sunflowers",
                     PurchasePrice = 15.95M,
                     OrderItemQuantity = 2
                    },
                      new OrderDisplayItem()
                    {
                     ProductName = "Rake",
                     PurchasePrice = 6M,
                     OrderItemQuantity = 1
                    },
                }
            };

            var actual = orderRepo.RetrieveOrderDisplay(10);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RetrieveOrderDisplayInvalidTest()
        {
            var orderRepo = new OrderRepository();
            var expected = new OrderDisplay()
            {
                FirstName = "Bilbo",
                LastName = "Baggins",
                OrderDate = new DateTimeOffset(2014, TimeSpan.Zero),
                ShippingAddress = new Address()
                {
                    AddressType = 1,
                    StreetLine1 = "Bagnd",
                    StreetLine2 = "Bagshot row",
                    City = "Hobiton",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "1444"

                },

                OrderDisplayItemList = new List<OrderDisplayItem>()
                {
                     new OrderDisplayItem()
                    {
                     ProductName = "Sunflowers",
                     PurchasePrice = 15.95M,
                     OrderItemQuantity = 2
                    },
                      new OrderDisplayItem()
                    {
                     ProductName = "Rakes",
                     PurchasePrice = 6M,
                     OrderItemQuantity = 1
                    },
                }
            };

            var actual = orderRepo.RetrieveOrderDisplay(10);

            Assert.AreNotEqual(expected, actual);

        }

    }
}


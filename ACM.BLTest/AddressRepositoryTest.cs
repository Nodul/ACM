using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class AddressRepositoryTest
    {
        [TestMethod]
        public void AddressRepoRetrieveExisting()
        {
            var addressRepo = new AddressRepository();
            var expected = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144"
            };

            var actual = addressRepo.Retrieve(1);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void AddressRepoRetrieveExistingInvalid()
        {
            var addressRepo = new AddressRepository();
            var expected = new Address(1)
            {
                AddressType = 100,
                StreetLine1 = "BagEnd",
                StreetLine2 = "Bagshot RoW",
                City = "Hobbitonshire",
                State = "The Shire",
                Country = "Middle Urth",
                PostalCode = "1444"
            };

            var actual = addressRepo.Retrieve(1);

            Assert.AreNotEqual(expected, actual);

        }
    }
}

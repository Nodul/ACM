using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void ProductRepoRetrieveExisting()
        {
            var productRepo = new ProductRepository();
            var expected = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "Assorted sizes",
                CurrentPrice = 15.95M
            };

            var actual = productRepo.Retrieve(2);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ProductRepoRetrieveExistingInvalid()
        {
            var productRepo = new ProductRepository();
            var expected = new Product(2)
            {
                ProductName = "Sun",
                ProductDescription = "Assorted somsdm",
                CurrentPrice = 1595M
            };

            var actual = productRepo.Retrieve(2);

            Assert.AreNotEqual(expected, actual);

        }
    }
}

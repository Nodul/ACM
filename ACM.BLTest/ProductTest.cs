using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductToStringTest()
        {
            var product = new Product();
            product.ProductName = "Sunflower";
            var expected = "Sunflower";

            Assert.AreEqual(expected,product.ProductName);

        }
        [TestMethod]
        public void ProductToStringTestInvalid()
        {
            var product = new Product();
            product.ProductName = "Sunflodsa";
            var expected = "Sunflower";

            Assert.AreNotEqual(expected, product.ProductName);

        }
    }
}

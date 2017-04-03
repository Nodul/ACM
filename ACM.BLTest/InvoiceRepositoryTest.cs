using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL;

namespace ACM.BLTest
{
    [TestClass]
    public class InvoiceRepositoryTest
    {
        [TestMethod]
        public void CalculateTotalAmountInvoicesTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();

            var actual = invoRepo.CalculateTotalAmountInvoices(invoiceList);

            Assert.AreEqual(413.90M,actual);
        }
        [TestMethod]
        public void CalculateTotalUnitsSoldInvoicesTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();

            var actual = invoRepo.CalculateTotalUnitsSoldInvoices(invoiceList);

            Assert.AreEqual(42M, actual);
        }
        [TestMethod]
        public void GetInvoiceTotalByIsPaidTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();

            var actual = invoRepo.GetInvoiceTotalByIsPaid(invoiceList);

  
        }

        [TestMethod]
        public void GetInvoiceTotalByIsPaidAndMonthTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();

            var actual = invoRepo.GetInvoiceTotalByIsPaidAndMonth(invoiceList);


        }


        [TestMethod]
        public void CalculateMeanTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();
            var expected = 11.25M;

            var actual = invoRepo.CalculateMean(invoiceList);

            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void CalculateMedianTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();
            var expected = 10M;

            var actual = invoRepo.CalculateMedian(invoiceList);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CalculateModeTest()
        {
            InvoiceRepository invoRepo = new InvoiceRepository();
            var invoiceList = invoRepo.Retrieve();
            var expected = 10M;

            var actual = invoRepo.CalculateMode(invoiceList);

            Assert.AreEqual(expected, actual);


        }
    }
}

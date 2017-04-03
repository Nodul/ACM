using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        List<Invoice> _invoiceList = new List<Invoice>()
        {
                new Invoice()
                {
                    InvoiceID = 1,
                    CustomerID = 1,
                    InvoiceDate = new DateTime(2013,6,30),
                    DueDate = new DateTime(2013,8,29),
                    IsPaid = null,
                    Amount = 95.50M,
                    NumberOfUnits = 10,
                    DiscountPercent = 10M

                },
                new Invoice()
                {
                    InvoiceID = 2,
                    CustomerID = 1,
                    InvoiceDate = new DateTime(2013,7,30),
                    DueDate = new DateTime(2013,12,29),
                    IsPaid = null,
                    Amount = 250.00M,
                    NumberOfUnits = 20,
                    DiscountPercent = 10M
                },
                new Invoice()
                {
                    InvoiceID = 3,
                    CustomerID = 2,
                    InvoiceDate = new DateTime(2012,6,30),
                    DueDate = new DateTime(2012,8,29),
                    IsPaid = null,
                    Amount = 20.00M,
                    NumberOfUnits = 2,
                    DiscountPercent = 15M
                },
                new Invoice()
                {
                    InvoiceID = 4,
                    CustomerID = 3,
                    InvoiceDate = new DateTime(2010,6,30),
                    DueDate = new DateTime(2011,8,29),
                    IsPaid = true,
                    Amount = 95.50M,
                    NumberOfUnits = 10,
                    DiscountPercent = 10M
                }
        };

        public List<Invoice> Retrieve()
        {
            return _invoiceList;
        }

        public List<Invoice> Retrieve(int customerID)
        {
            var invoiceList = this.Retrieve();
            List<Invoice> filteredList = invoiceList.Where(i => i.CustomerID == customerID).ToList();

            return filteredList;
        }

        public decimal CalculateTotalAmountInvoices(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.TotalAmount);
        }
        public decimal CalculateTotalUnitsSoldInvoices(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(inv => inv.NumberOfUnits);
        }
        public dynamic GetInvoiceTotalByIsPaid(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(
                inv => inv.IsPaid ?? false,
                inv => inv.TotalAmount,
                (groupKey,invTotal) => new
                {
                    Key = groupKey,
                    InvoicedTotal = invTotal.Sum()
                });

            foreach (var item in query)
            {
                Console.WriteLine($"Key = {item.Key}, Invoiced total: = {item.InvoicedTotal}");
            }

            return query;
        }

        public dynamic GetInvoiceTotalByIsPaidAndMonth(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(
                inv => new
                {
                    IsPaid = inv.IsPaid ?? false,
                    InvoiceMonth = inv.InvoiceDate.ToString("MMMM")
                }, 
                inv => inv.TotalAmount,
                (groupKey, invTotal) => new
                {
                    Key = groupKey,
                    InvoicedTotal = invTotal.Sum()
                });

            foreach (var item in query)
            {
                Console.WriteLine($"Key = {item.Key.InvoiceMonth}, Invoiced total: = {item.InvoicedTotal}");
            }

            return query;
        }

        public decimal CalculateMean(List<Invoice> invoiceList)
        {
            return invoiceList.Average(c => c.DiscountPercent);
        }

        public decimal CalculateMedian(List<Invoice> invoiceList)
        {
            var sortedList = invoiceList.OrderBy(i => i.DiscountPercent);

            int count = sortedList.Count();
            int position = count / 2;
            decimal median;

            if(count % 2 == 0)
            {
                median = (sortedList.ElementAt(position).DiscountPercent + sortedList.ElementAt(position - 1).DiscountPercent) / 2;
            }
            else
            {
                median = sortedList.ElementAt(position).DiscountPercent;
            }

            return median;
        }

        public decimal CalculateMode(List<Invoice> invoiceList)
        {
            var mode = invoiceList.GroupBy(inv => inv.DiscountPercent)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();

            return mode;
        }
    }
}

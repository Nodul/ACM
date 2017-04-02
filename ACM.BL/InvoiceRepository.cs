using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        public List<Invoice> Retrieve(int customerID)
        {
            List<Invoice> invoiceList = new List<Invoice>()
            {
                new Invoice()
                {
                    InvoiceID = 1,
                    CustomerID = 1,
                    InvoiceDate = new DateTime(2013,6,30),
                    DueDate = new DateTime(2013,8,29),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceID = 2,
                    CustomerID = 1,
                    InvoiceDate = new DateTime(2013,7,30),
                    DueDate = new DateTime(2013,12,29),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceID = 3,
                    CustomerID = 2,
                    InvoiceDate = new DateTime(2012,6,30),
                    DueDate = new DateTime(2012,8,29),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceID = 4,
                    CustomerID = 3,
                    InvoiceDate = new DateTime(2010,6,30),
                    DueDate = new DateTime(2011,8,29),
                    IsPaid = true
                }
            };
            List<Invoice> filteredList = invoiceList.Where(i => i.CustomerID == customerID).ToList();

            return filteredList;
        }
    }
}

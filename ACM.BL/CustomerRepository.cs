using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        private AddressRepository _addressRepository { get; set; }

        public CustomerRepository()
        {
            _addressRepository = new AddressRepository();
        }

        /// <summary>
        /// Retrieve one customer, by ID;
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public Customer Retrieve(int customerID)
        {
            Customer customer = new Customer(customerID);
            customer.addressList = _addressRepository.RetrieveByCustomerID(customerID).ToList();

            // temp hard coded values to return a populated customer
            if (customerID == 1)
            {
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }

            return customer;
        }

        public Customer Find(List<Customer> customerList, int customerID)
        {
            Customer custFound = null;

            //foreach (var cust in customerList)
            //{
            //    if(cust.CustomerID == customerID)
            //    {
            //        custFound = cust;
            //        break;
            //    }
            //}

            //var query = from c in customerList
            //            where c.CustomerID == customerID
            //            select c;

            //custFound = query.First();

            custFound = customerList.FirstOrDefault(c => c.CustomerID == customerID); // without braces only single line expressions are allowed

            //custFound = customerList.FirstOrDefault(c =>
            //    {
            //        Debug.WriteLine(c.LastName);
            //        return c.CustomerID == customerID;
            //    });

            // custFound = customerList.Where(c => c.CustomerID == customerID).Skip(0).FirstOrDefault();
            return custFound;
        }

        public dynamic GetNamesAndID(List<Customer> customerList)
        {
            var query = customerList
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .Select(c => new
                {
                    Name = c.FullName,
                    c.CustomerID
                });

            return query.ToList();
        }

        public dynamic GetNamesAndTypes(List<Customer> customerList, List<CustomerType> customerTypeList)
        {

            var query = customerList.Join(customerTypeList,
                (c) => c.CustomerTypeID.CustomerTypeID,
                (ct) => ct.CustomerTypeID,
                (c, ct) => new
                {
                    Name = c.FullName,
                    CustomerTypeName = ct.TypeName
                }).Distinct();

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + ", " + item.CustomerTypeName);
            }

            return query.ToList();
        }


        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            InvoiceRepository invoiceRepo = new InvoiceRepository();
            // hard coded for testing
            List<Customer> custList = new List<Customer>()
            {
                new Customer(1)
                {
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    EmailAddress = "fbaggins@hobbiton.me",
                    CustomerTypeID = new CustomerType(CustomerTypes.Residential,2),
                    InvoiceList = invoiceRepo.Retrieve(1)
                },
                    new Customer(2)
                {
                    FirstName = "Bilbo",
                    LastName = "Baggins",
                    EmailAddress = "bbaggins@hobbiton.me",
                    CustomerTypeID = new CustomerType(CustomerTypes.Residential,1),
                    InvoiceList = invoiceRepo.Retrieve(2)
                },
                        new Customer(3)
                {
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    EmailAddress = "sgamgee@hobbiton.me",
                    CustomerTypeID = new CustomerType(CustomerTypes.Educator,4),
                    InvoiceList = invoiceRepo.Retrieve(3)
                },
                            new Customer(4)
                {
                    FirstName = "",
                    LastName = "Shire Administration Agency",
                    EmailAddress = "SAA@shire.me",
                    CustomerTypeID = new CustomerType(CustomerTypes.Government,3),
                    InvoiceList = invoiceRepo.Retrieve(4)
                }
            };

            return custList;
        }

        public IEnumerable<Customer> GetOverdueCustomers(List<Customer> custList)
        {
            // Sadly we won't have direct access to customers 
            //var query = custList
            //    .Select(c => c.InvoiceList
            //        .Where(i => (i.IsPaid ?? false) == false));

            // This makes it so we don't need IEnumerable<IEnumerable<Invoice>>, which is simplified to IEnumerable<Invoice>
            //var query = custList
            //    .SelectMany(c => c.InvoiceList
            //         .Where(i => (i.IsPaid ?? false) == false));

            // Finally this allows to convert directly to IEnumerable<Customer>, as we wanted from the beginning
            var query = custList
              .SelectMany(c => c.InvoiceList
               .Where(i => (i.IsPaid ?? false) == false),
               (c,i) => c).Distinct();

            return query;
        }

        public IEnumerable<KeyValuePair<string,decimal>> GetInvoiceTotalByCustomerType(List<Customer> customerList, List<CustomerType> customerTypeList)
        {
            var customerTypeQuery = customerList.Join(
                customerTypeList,
                c => c.CustomerTypeID.CustomerTypeID,
                ct => ct.CustomerTypeID,
                (c,ct) => new
                {
                    CustomerInstance = c,
                    CustomerTypeName = ct.TypeName
                });

            var query = customerTypeQuery
                .GroupBy(
                    c => c.CustomerTypeName,
                    c => c.CustomerInstance.InvoiceList.Sum(inv => inv.TotalAmount),
                    (groupKey, invTotal) => new KeyValuePair<string,decimal>(groupKey,invTotal.Sum()));

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            return query;
        }

        public IEnumerable<Customer> RetrieveEmptyList()
        {
            return Enumerable.Repeat(new Customer(), 5);
        }

        public IEnumerable<string> GetNames(List<Customer> customerList)
        {
            var query = customerList.Select(c => c.FullName);

            return query;
        }

        /// <summary>
        /// But don't do this in real code, try to make a new class for this new data type 
        /// </summary>
        /// <param name="customerList"></param>
        /// <returns></returns>
        public dynamic GetNamesAndEmail(List<Customer> customerList)
        {
            var query = customerList.Select(c => new
            {
                Name = c.FullName,
                c.EmailAddress
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + ":" + item.EmailAddress);
            }

            return query;
        }

        /// <summary>
        /// Saves current customer
        /// </summary>
        /// <returns></returns>
        public bool Save(Customer customer)
        {
            var success = true;

            if (customer.HasChanges && customer.IsValid)
            {
                if (customer.IsNew)
                {
                    // Call an insert stored procedure
                }
                else
                {
                    // Call an Update Stored Procedure
                }
            }
            return success;
        }

        public IEnumerable<Customer> SortByName(IEnumerable<Customer> custList)
        {
            return custList.OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> custList)
        {
            // Method 1

            //return custList.OrderByDescending(c => c.LastName)
            //    .ThenByDescending(c => c.FirstName);

            // Method 2

            return SortByName(custList).Reverse();
        }

        public IEnumerable<Customer> SortByType(List<Customer> custList)
        {
            // This will make the items with null values go to bottom of list, while normal values will stay at top
            return custList.OrderByDescending(c => c.CustomerTypeID != null).ThenBy(c => (int)c.CustomerTypeID.CustomerTypeID);

        }
    }
}

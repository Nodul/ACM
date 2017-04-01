using System;
using System.Collections.Generic;
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
            if(customerID == 1)
            {
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }

            return customer;
        }
        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        /// <summary>
        /// Saves current customer
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
        }
    }
}

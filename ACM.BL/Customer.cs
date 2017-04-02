using Acme.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{


    public class Customer : EntityBase, ILoggable
    {
        public Customer() : this(0)
        {

        }

        public Customer(int customerID)
        {
            this.CustomerID = customerID;
            addressList = new List<Address>(); // this is so the address list is empty instead of null
        }
        //Properties

        public List<Address> addressList { get; set; }

        public CustomerType CustomerTypeID { get; set; }

        public static int InstanceCount { get; set; }

        private string _lastName; //backing field for LastName

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public int CustomerID { get; private set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
        // Methods


        protected override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            return isValid;
        }
        /// <summary>
        /// Doesn't check address list, assumes these are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            Customer rhs = obj as Customer;

            //var listSEQ = (IStructuralEquatable)this.addressList;
            bool AreAddressListsEqual = true; //temporary, since I can't make structural comparison work :/

            return this.CustomerID == rhs.CustomerID && this.LastName == rhs.LastName && this.FirstName == rhs.FirstName && this.EmailAddress == rhs.EmailAddress && AreAddressListsEqual;

        }
        public override int GetHashCode()
        {
            return this.CustomerID.GetHashCode() ^ this.LastName.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.EmailAddress.GetHashCode(); //^ this.addressList.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }

        public string Log()
        {
            var logString = $"{this.CustomerID}: {this.FullName} Email: {this.EmailAddress} Status: {this.EntityState.ToString()}";

            return logString;
        }
    }
}

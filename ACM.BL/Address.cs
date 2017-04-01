using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Address : EntityBase
    {
        public Address()
        {

        }
        public Address(int addressID)
        {
            this.AddressID = addressID;
        }

        // Properties
        public int AddressID { get; private set; }
        public int AddressType { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        // Methods
        /// <summary>
        /// This doesn't check StreetLine2
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;

            Address rhs = obj as Address;

            //bool isStreet2Equal;
            //if()

            return this.AddressID == rhs.AddressID && this.AddressType == rhs.AddressType && this.StreetLine1 == rhs.StreetLine1 
                && this.City == rhs.City && this.State == rhs.State 
                && this.PostalCode == rhs.PostalCode && this.Country == rhs.Country; 
        }

        public override int GetHashCode()
        {
            return AddressID.GetHashCode() ^ AddressType.GetHashCode() ^ StreetLine1.GetHashCode() ^  City.GetHashCode() ^
                State.GetHashCode() ^ PostalCode.GetHashCode() ^ Country.GetHashCode();
        }

        protected override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(StreetLine1)) isValid = false;
            if (string.IsNullOrWhiteSpace(City)) isValid = false;
            if (string.IsNullOrWhiteSpace(State)) isValid = false;
            if (string.IsNullOrWhiteSpace(Country)) isValid = false;

            return isValid;
        }
    }
}

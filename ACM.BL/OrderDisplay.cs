using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderDisplay
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public List<OrderDisplayItem> OrderDisplayItemList { get; set; }
        public int OrderID { get; set; }
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Doesn't check for OrderDisplayItemList
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;

            OrderDisplay rhs = obj as OrderDisplay;

            return this.FirstName == rhs.FirstName && this.LastName == rhs.LastName && Nullable.Compare<DateTimeOffset>(this.OrderDate, rhs.OrderDate) == 0 && this.OrderID == rhs.OrderID &&
                this.ShippingAddress.Equals(rhs.ShippingAddress);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.OrderDate.GetHashCode() ^ this.OrderID.GetHashCode() ^ this.ShippingAddress.GetHashCode();
        }
    }
}

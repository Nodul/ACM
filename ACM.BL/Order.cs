using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order
    {
        public Order()
        {
             
        }
        public Order(int orderID)
        {
            this.OrderID = orderID;
        }
        //Properties
        public int CustomerID { get; set; }
        public int ShippingAddressID { get; set; }

        public DateTimeOffset? OrderDate { get; set; }
        public int OrderID { get; private set; }
        public List<OrderItem> orderItems { get; set; }
        // Methods

        public bool Validate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;

            Order rhs = obj as Order;

            return this.OrderID == rhs.OrderID && Nullable.Compare<DateTimeOffset>(this.OrderDate,rhs.OrderDate) == 0;
        }
        public override int GetHashCode()
        {
            return this.OrderID.GetHashCode() ^ this.OrderDate.GetHashCode();
        }

        public override string ToString()
        {
            return OrderDate + " [" + OrderID + "]" ;
        }
    }
}

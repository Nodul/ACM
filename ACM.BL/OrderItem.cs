using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        public OrderItem(int orderItemID)
        {
            this.OrderItemID = orderItemID;
        }
        // Properties
        public int OrderItemID { get; private set; }
        public int OrderQuantity { get; set; }
        public int ProductID { get; set; }
        public Decimal? PurchasePrice { get; set; }

        // Methods
        public OrderItem Retrieve(int orderItemID)
        {
            return new OrderItem();
        }
        public bool Save()
        {
            return true;
        }
        public bool Validate()
        {
            var isValid = true;

            if (OrderQuantity <= 0) isValid = false;
            if (ProductID <= 0) isValid = false;
            if (PurchasePrice == null) isValid = false;

            return isValid;
        }
    }
}

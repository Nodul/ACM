using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderRepository
    {
        public Order Retrieve(int orderID)
        {
            Order order = new Order(orderID);

            // Again, this is temp hard coded
            if(orderID == 10)
            {
                order.OrderDate = new DateTimeOffset(2014,TimeSpan.Zero);
            }

            return order;
        }
        public bool Save()
        {
            return true;
        }

        public OrderDisplay RetrieveOrderDisplay(int orderID)
        {
            OrderDisplay orderDisplay = new OrderDisplay();

            // temp hardcoded

            if(orderID == 10)
            {
                orderDisplay.FirstName = "Bilbo";
                orderDisplay.LastName = "Baggins";
                orderDisplay.OrderDate = new DateTimeOffset(2014, TimeSpan.Zero);
                orderDisplay.ShippingAddress = new Address()
                {
                    AddressType = 1,
                    StreetLine1 = "Bag End",
                    StreetLine2 = "Bagshot row",
                    City = "Hobbiton",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "144"

                };
            }

            orderDisplay.OrderDisplayItemList = new List<OrderDisplayItem>();

            if(orderID == 10)
            {
                var orderDisplayItem = new OrderDisplayItem()
                {
                    ProductName = "Sunflowers",
                    PurchasePrice = 15.95M,
                    OrderItemQuantity = 2
                };
                orderDisplay.OrderDisplayItemList.Add(orderDisplayItem);

                orderDisplayItem = new OrderDisplayItem()
                {
                    ProductName = "Rake",
                    PurchasePrice = 6M,
                    OrderItemQuantity = 1
                };
                orderDisplay.OrderDisplayItemList.Add(orderDisplayItem);
            }

            return orderDisplay;
        }

        public bool Save(Order order)
        {
            var success = true;

            if (order.HasChanges && order.IsValid)
            {
                if (order.IsNew)
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
    }
}

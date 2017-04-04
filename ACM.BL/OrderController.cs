using Acme.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderController
    {
        private CustomerRepository customerRepo { get; set; }
        private OrderRepository orderRepo { get; set; }
        private InventoryRepository invRepo { get; set; }
        private EmailLibrary emailLibrary { get; set; }

        public OrderController()
        {
            customerRepo = new CustomerRepository();
            orderRepo = new OrderRepository();
            invRepo = new InventoryRepository();
            emailLibrary = new EmailLibrary();
        }

        public OperationResult PlaceOrder(Customer customer, Order order, Payment payment, bool allowSplitOrders, bool getEmailReceipt)
        {
            Debug.Assert(customerRepo != null, "Missing customer repository instance");
            Debug.Assert(orderRepo != null, "Missing order repository instance");
            Debug.Assert(invRepo != null, "Missing inventory repository instance");
            Debug.Assert(emailLibrary != null, "Missing email library instance");

            if (customer == null) throw new ArgumentNullException("Customer cannot be null");
            if (order == null) throw new ArgumentNullException("Order cannot be null");
            if (payment == null) throw new ArgumentNullException("Payment cannot be null");
            // bools are ok, since they cannot be null

            var op = new OperationResult();

            // TODO the below method should be changed to return something so I can properly update the op object
            customerRepo.Add(customer);

            orderRepo.Add(order);

            invRepo.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (getEmailReceipt)
            {
                var result = customer.ValidateEmail();

                if (result.Success)
                {
                    customerRepo.Update();

                    emailLibrary.SendEmail(customer.EmailAddress, "Here is your receipt");
                }
                else
                {
                    // op.Success = false; //nope, since by this point the order was actually placed
                    // Log messages
                    if (result.MessageList.Any())
                    {
                        op.AddMessage(result.MessageList[0]);
                    }
                }

            }

            return op;
        }
    }
}

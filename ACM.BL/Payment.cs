using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public enum PaymentType
    {
        CreditCard = 0,
        PayPal = 1
    }

    public class Payment
    {
        public PaymentType PaymentType { get; set; }

        public void ProcessPayment()
        {
            switch (PaymentType)
            {
                case PaymentType.CreditCard:
                    // process credit card
                    break;
                case PaymentType.PayPal:
                    // process PayPal
                    break;
                default:
                    throw new ArgumentException("Error with payment type");
            }

            // -- Process the payment --
            // If credit card, 
            // process the credit card payment.
            // If PayPal, 
            // process the PayPal payment.
            // If there is a payment problem, notify the user.
            // Open a connection
            // Set stored procedure parameters with the payment data.
            // Call the save stored procedure.
        }
    }
}

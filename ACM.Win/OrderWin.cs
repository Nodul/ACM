using ACM.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class OrderWin : Form
    {
        public OrderWin()
        {
            InitializeComponent();
        }

        private void PlaceOrder_button1_Click(object sender, EventArgs e)
        {
            PlaceOrder();
        }

        private void PlaceOrder()
        {
            var customer = new Customer()
            {
                // populate customer instance
                LastName = "Anon"
            };


            var order = new Order();
            // populate order instance

            var payment = new Payment();
            // populate payment instance

            var allowSplitOrders = true; // if not enough inventory, do a partial order?
            var getEmailReceipt = true;

            var orderCtrl = new OrderController();

            try
            {
                var op = orderCtrl.PlaceOrder(customer, order, payment, allowSplitOrders, getEmailReceipt);

            }
            catch (ArgumentNullException ex)
            {
                // TODO log
                // TODO display message that something went wrong
                
            }

        }
    }
}

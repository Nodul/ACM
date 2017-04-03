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
    public partial class CustomerWin : Form
    {
        CustomerRepository customerRepo = new CustomerRepository();
        CustomerTypeRepository customerTypeRepo = new CustomerTypeRepository();

        public CustomerWin()
        {
            InitializeComponent();
        }

        private void CustomerWin_Load_1(object sender, EventArgs e)
        {
            var customerList = customerRepo.Retrieve();
            CustomerComboBox1.DisplayMember = "Name";
            CustomerComboBox1.ValueMember = "CustomerID";
            CustomerComboBox1.DataSource = customerRepo.GetNamesAndID(customerList);
        }

        private void GetCustomers_Button1_Click(object sender, EventArgs e)
        {
            var customerList = customerRepo.Retrieve();
            var customerTypeList = customerTypeRepo.Retrieve();

            CustomerGridView.DataSource = customerRepo.GetNamesAndTypes(customerList, customerTypeList); // ToList() required to actually execute the query
        }

        private void GetOverdueCustomers_Button1_Click(object sender, EventArgs e)
        {
            var customerList = customerRepo.Retrieve();
            var unpaidCustomers = customerRepo.GetOverdueCustomers(customerList);
            CustomerGridView.DataSource = customerRepo.SortByName(unpaidCustomers).ToList();
        }

        private void CustomerComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(CustomerComboBox1.SelectedValue != null)
            {
                int customerID;
                if(int.TryParse(CustomerComboBox1.SelectedValue.ToString(),out customerID))
                {
                    var customerList = customerRepo.Retrieve();
                    // We need to pass in a list for the grid view, even if we only have 1 element
                    CustomerGridView.DataSource = new List<Customer>() { customerRepo.Find(customerList, customerID) };
                }
            }
        }

     
    }
}

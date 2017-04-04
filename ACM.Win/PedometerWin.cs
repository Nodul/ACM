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
    public partial class PedometerWin : Form
    {
        public PedometerWin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CalculateSteps_Button1_Click(object sender, EventArgs e)
        {
            var customer = new Customer();
            try
            {
                var result = customer.CalculatePercentOfGoalStep(this.StepGoal_TextBox1.Text, this.NumberOfSteps_TextBox1.Text);
                Results_Label1.Text = $"You have reached {result}% of your goal!";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Your entry was not valid: "+ex.Message);
                Results_Label1.Text = string.Empty;
            }

        }

        private void StepGoal_TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumberOfSteps_TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PedometerWin_Load(object sender, EventArgs e)
        {

        }
    }
}

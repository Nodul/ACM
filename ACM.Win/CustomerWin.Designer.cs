namespace ACM.Win
{
    partial class CustomerWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomerComboBox1 = new System.Windows.Forms.ComboBox();
            this.CustomerGridView = new System.Windows.Forms.DataGridView();
            this.GetCustomers_Button1 = new System.Windows.Forms.Button();
            this.GetOverdueCustomers_Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerComboBox1
            // 
            this.CustomerComboBox1.FormattingEnabled = true;
            this.CustomerComboBox1.Location = new System.Drawing.Point(12, 12);
            this.CustomerComboBox1.Name = "CustomerComboBox1";
            this.CustomerComboBox1.Size = new System.Drawing.Size(378, 21);
            this.CustomerComboBox1.TabIndex = 0;
            this.CustomerComboBox1.SelectedIndexChanged += new System.EventHandler(this.CustomerComboBox1_SelectedIndexChanged);
            // 
            // CustomerGridView
            // 
            this.CustomerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerGridView.Location = new System.Drawing.Point(13, 40);
            this.CustomerGridView.Name = "CustomerGridView";
            this.CustomerGridView.ReadOnly = true;
            this.CustomerGridView.Size = new System.Drawing.Size(791, 590);
            this.CustomerGridView.TabIndex = 2;
            // 
            // GetCustomers_Button1
            // 
            this.GetCustomers_Button1.Location = new System.Drawing.Point(810, 12);
            this.GetCustomers_Button1.Name = "GetCustomers_Button1";
            this.GetCustomers_Button1.Size = new System.Drawing.Size(79, 40);
            this.GetCustomers_Button1.TabIndex = 3;
            this.GetCustomers_Button1.Text = "Get Customers";
            this.GetCustomers_Button1.UseVisualStyleBackColor = true;
            this.GetCustomers_Button1.Click += new System.EventHandler(this.GetCustomers_Button1_Click);
            // 
            // GetOverdueCustomers_Button1
            // 
            this.GetOverdueCustomers_Button1.Location = new System.Drawing.Point(813, 59);
            this.GetOverdueCustomers_Button1.Name = "GetOverdueCustomers_Button1";
            this.GetOverdueCustomers_Button1.Size = new System.Drawing.Size(75, 52);
            this.GetOverdueCustomers_Button1.TabIndex = 4;
            this.GetOverdueCustomers_Button1.Text = "Get Overdue Customers";
            this.GetOverdueCustomers_Button1.UseVisualStyleBackColor = true;
            this.GetOverdueCustomers_Button1.Click += new System.EventHandler(this.GetOverdueCustomers_Button1_Click);
            // 
            // CustomerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 642);
            this.Controls.Add(this.GetOverdueCustomers_Button1);
            this.Controls.Add(this.GetCustomers_Button1);
            this.Controls.Add(this.CustomerGridView);
            this.Controls.Add(this.CustomerComboBox1);
            this.Name = "CustomerWin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CustomerWin_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CustomerComboBox1;
        private System.Windows.Forms.DataGridView CustomerGridView;
        private System.Windows.Forms.Button GetCustomers_Button1;
        private System.Windows.Forms.Button GetOverdueCustomers_Button1;
    }
}


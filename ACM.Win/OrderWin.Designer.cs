namespace ACM.Win
{
    partial class OrderWin
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
            this.PlaceOrder_button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlaceOrder_button1
            // 
            this.PlaceOrder_button1.Location = new System.Drawing.Point(309, 13);
            this.PlaceOrder_button1.Name = "PlaceOrder_button1";
            this.PlaceOrder_button1.Size = new System.Drawing.Size(75, 32);
            this.PlaceOrder_button1.TabIndex = 0;
            this.PlaceOrder_button1.Text = "Place Order";
            this.PlaceOrder_button1.UseVisualStyleBackColor = true;
            this.PlaceOrder_button1.Click += new System.EventHandler(this.PlaceOrder_button1_Click);
            // 
            // OrderWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 412);
            this.Controls.Add(this.PlaceOrder_button1);
            this.Name = "OrderWin";
            this.Text = "OrderWin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlaceOrder_button1;
    }
}
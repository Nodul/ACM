namespace ACM.Win
{
    partial class PedometerWin
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
            this.CalculateSteps_Button1 = new System.Windows.Forms.Button();
            this.StepGoals_Label1 = new System.Windows.Forms.Label();
            this.NumberOfSteps_Label1 = new System.Windows.Forms.Label();
            this.StepGoal_TextBox1 = new System.Windows.Forms.TextBox();
            this.NumberOfSteps_TextBox1 = new System.Windows.Forms.TextBox();
            this.Results_Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CalculateSteps_Button1
            // 
            this.CalculateSteps_Button1.Location = new System.Drawing.Point(248, 13);
            this.CalculateSteps_Button1.Name = "CalculateSteps_Button1";
            this.CalculateSteps_Button1.Size = new System.Drawing.Size(101, 52);
            this.CalculateSteps_Button1.TabIndex = 0;
            this.CalculateSteps_Button1.Text = "Calculate";
            this.CalculateSteps_Button1.UseVisualStyleBackColor = true;
            this.CalculateSteps_Button1.Click += new System.EventHandler(this.CalculateSteps_Button1_Click);
            // 
            // StepGoals_Label1
            // 
            this.StepGoals_Label1.AutoSize = true;
            this.StepGoals_Label1.Location = new System.Drawing.Point(27, 13);
            this.StepGoals_Label1.Name = "StepGoals_Label1";
            this.StepGoals_Label1.Size = new System.Drawing.Size(103, 13);
            this.StepGoals_Label1.TabIndex = 1;
            this.StepGoals_Label1.Text = "Step goal for Today:";
            this.StepGoals_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StepGoals_Label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NumberOfSteps_Label1
            // 
            this.NumberOfSteps_Label1.AutoSize = true;
            this.NumberOfSteps_Label1.Location = new System.Drawing.Point(13, 52);
            this.NumberOfSteps_Label1.Name = "NumberOfSteps_Label1";
            this.NumberOfSteps_Label1.Size = new System.Drawing.Size(117, 13);
            this.NumberOfSteps_Label1.TabIndex = 2;
            this.NumberOfSteps_Label1.Text = "Number of steps Today";
            // 
            // StepGoal_TextBox1
            // 
            this.StepGoal_TextBox1.Location = new System.Drawing.Point(137, 13);
            this.StepGoal_TextBox1.Name = "StepGoal_TextBox1";
            this.StepGoal_TextBox1.Size = new System.Drawing.Size(100, 20);
            this.StepGoal_TextBox1.TabIndex = 3;
            this.StepGoal_TextBox1.TextChanged += new System.EventHandler(this.StepGoal_TextBox1_TextChanged);
            // 
            // NumberOfSteps_TextBox1
            // 
            this.NumberOfSteps_TextBox1.Location = new System.Drawing.Point(137, 44);
            this.NumberOfSteps_TextBox1.Name = "NumberOfSteps_TextBox1";
            this.NumberOfSteps_TextBox1.Size = new System.Drawing.Size(100, 20);
            this.NumberOfSteps_TextBox1.TabIndex = 4;
            this.NumberOfSteps_TextBox1.TextChanged += new System.EventHandler(this.NumberOfSteps_TextBox1_TextChanged);
            // 
            // Results_Label1
            // 
            this.Results_Label1.AutoSize = true;
            this.Results_Label1.Location = new System.Drawing.Point(12, 87);
            this.Results_Label1.Name = "Results_Label1";
            this.Results_Label1.Size = new System.Drawing.Size(0, 13);
            this.Results_Label1.TabIndex = 5;
            this.Results_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PedometerWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 348);
            this.Controls.Add(this.Results_Label1);
            this.Controls.Add(this.NumberOfSteps_TextBox1);
            this.Controls.Add(this.StepGoal_TextBox1);
            this.Controls.Add(this.NumberOfSteps_Label1);
            this.Controls.Add(this.StepGoals_Label1);
            this.Controls.Add(this.CalculateSteps_Button1);
            this.Name = "PedometerWin";
            this.Text = "PedometerWin";
            this.Load += new System.EventHandler(this.PedometerWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalculateSteps_Button1;
        private System.Windows.Forms.Label StepGoals_Label1;
        private System.Windows.Forms.Label NumberOfSteps_Label1;
        private System.Windows.Forms.TextBox StepGoal_TextBox1;
        private System.Windows.Forms.TextBox NumberOfSteps_TextBox1;
        private System.Windows.Forms.Label Results_Label1;
    }
}
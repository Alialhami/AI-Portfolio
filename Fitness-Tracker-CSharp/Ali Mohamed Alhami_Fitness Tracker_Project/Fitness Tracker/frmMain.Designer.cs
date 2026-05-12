namespace Fitness_Tracker
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGoal = new System.Windows.Forms.TextBox();
            this.btnSetGoal = new System.Windows.Forms.Button();
            this.lblGoalDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.lblMetric1 = new System.Windows.Forms.Label();
            this.lblMetric2 = new System.Windows.Forms.Label();
            this.lblMetric3 = new System.Windows.Forms.Label();
            this.txtMetric1 = new System.Windows.Forms.TextBox();
            this.txtMetric2 = new System.Windows.Forms.TextBox();
            this.txtMetric3 = new System.Windows.Forms.TextBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.lblTotalCalories = new System.Windows.Forms.Label();
            this.lblGoalStatus = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set Calorie Goal:";
            // 
            // txtGoal
            // 
            this.txtGoal.Location = new System.Drawing.Point(68, 64);
            this.txtGoal.Name = "txtGoal";
            this.txtGoal.Size = new System.Drawing.Size(114, 24);
            this.txtGoal.TabIndex = 1;
            // 
            // btnSetGoal
            // 
            this.btnSetGoal.Location = new System.Drawing.Point(464, 43);
            this.btnSetGoal.Name = "btnSetGoal";
            this.btnSetGoal.Size = new System.Drawing.Size(143, 65);
            this.btnSetGoal.TabIndex = 2;
            this.btnSetGoal.Text = "Set Goal";
            this.btnSetGoal.UseVisualStyleBackColor = true;
            this.btnSetGoal.Click += new System.EventHandler(this.btnSetGoal_Click_1);
            // 
            // lblGoalDisplay
            // 
            this.lblGoalDisplay.AutoSize = true;
            this.lblGoalDisplay.Location = new System.Drawing.Point(457, 9);
            this.lblGoalDisplay.Name = "lblGoalDisplay";
            this.lblGoalDisplay.Size = new System.Drawing.Size(150, 17);
            this.lblGoalDisplay.TabIndex = 3;
            this.lblGoalDisplay.Text = "Current Goal: 0 calories";
            this.lblGoalDisplay.Click += new System.EventHandler(this.lblGoalDisplay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Activity:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbActivity
            // 
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(136, 143);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(121, 24);
            this.cmbActivity.TabIndex = 5;
            this.cmbActivity.SelectedIndexChanged += new System.EventHandler(this.cmbActivity_SelectedIndexChanged);
            // 
            // lblMetric1
            // 
            this.lblMetric1.AutoSize = true;
            this.lblMetric1.Location = new System.Drawing.Point(380, 146);
            this.lblMetric1.Name = "lblMetric1";
            this.lblMetric1.Size = new System.Drawing.Size(61, 17);
            this.lblMetric1.TabIndex = 6;
            this.lblMetric1.Text = "Metric 1:";
            // 
            // lblMetric2
            // 
            this.lblMetric2.AutoSize = true;
            this.lblMetric2.Location = new System.Drawing.Point(514, 143);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Size = new System.Drawing.Size(61, 17);
            this.lblMetric2.TabIndex = 7;
            this.lblMetric2.Text = "Metric 2:";
            // 
            // lblMetric3
            // 
            this.lblMetric3.AutoSize = true;
            this.lblMetric3.Location = new System.Drawing.Point(664, 143);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Size = new System.Drawing.Size(61, 17);
            this.lblMetric3.TabIndex = 8;
            this.lblMetric3.Text = "Metric 3:";
            // 
            // txtMetric1
            // 
            this.txtMetric1.Location = new System.Drawing.Point(351, 185);
            this.txtMetric1.Name = "txtMetric1";
            this.txtMetric1.Size = new System.Drawing.Size(100, 24);
            this.txtMetric1.TabIndex = 9;
            // 
            // txtMetric2
            // 
            this.txtMetric2.Location = new System.Drawing.Point(488, 185);
            this.txtMetric2.Name = "txtMetric2";
            this.txtMetric2.Size = new System.Drawing.Size(100, 24);
            this.txtMetric2.TabIndex = 10;
            // 
            // txtMetric3
            // 
            this.txtMetric3.Location = new System.Drawing.Point(646, 185);
            this.txtMetric3.Name = "txtMetric3";
            this.txtMetric3.Size = new System.Drawing.Size(100, 24);
            this.txtMetric3.TabIndex = 11;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(464, 258);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(135, 55);
            this.btnRecord.TabIndex = 12;
            this.btnRecord.Text = "Record Activity";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // lblTotalCalories
            // 
            this.lblTotalCalories.AutoSize = true;
            this.lblTotalCalories.Location = new System.Drawing.Point(75, 311);
            this.lblTotalCalories.Name = "lblTotalCalories";
            this.lblTotalCalories.Size = new System.Drawing.Size(153, 17);
            this.lblTotalCalories.TabIndex = 13;
            this.lblTotalCalories.Text = "Total Calories Burned: 0";
            // 
            // lblGoalStatus
            // 
            this.lblGoalStatus.AutoSize = true;
            this.lblGoalStatus.Location = new System.Drawing.Point(452, 367);
            this.lblGoalStatus.Name = "lblGoalStatus";
            this.lblGoalStatus.Size = new System.Drawing.Size(109, 17);
            this.lblGoalStatus.TabIndex = 14;
            this.lblGoalStatus.Text = "Goal not yet set.";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(58, 377);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 61);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblGoalStatus);
            this.Controls.Add(this.lblTotalCalories);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.txtMetric3);
            this.Controls.Add(this.txtMetric2);
            this.Controls.Add(this.txtMetric1);
            this.Controls.Add(this.lblMetric3);
            this.Controls.Add(this.lblMetric2);
            this.Controls.Add(this.lblMetric1);
            this.Controls.Add(this.cmbActivity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGoalDisplay);
            this.Controls.Add(this.btnSetGoal);
            this.Controls.Add(this.txtGoal);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.Button btnSetGoal;
        private System.Windows.Forms.Label lblGoalDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Label lblMetric1;
        private System.Windows.Forms.Label lblMetric2;
        private System.Windows.Forms.Label lblMetric3;
        private System.Windows.Forms.TextBox txtMetric1;
        private System.Windows.Forms.TextBox txtMetric2;
        private System.Windows.Forms.TextBox txtMetric3;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Label lblTotalCalories;
        private System.Windows.Forms.Label lblGoalStatus;
        private System.Windows.Forms.Button btnLogout;
    }
}
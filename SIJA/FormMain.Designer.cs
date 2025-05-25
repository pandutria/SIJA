namespace SIJA
{
    partial class FormMain
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
            this.lblName = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMasterStudent = new System.Windows.Forms.Button();
            this.btnMasterSteacher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(208, 31);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Welcome, [name]!";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(404, 38);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 39);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMasterStudent
            // 
            this.btnMasterStudent.Location = new System.Drawing.Point(28, 157);
            this.btnMasterStudent.Name = "btnMasterStudent";
            this.btnMasterStudent.Size = new System.Drawing.Size(451, 39);
            this.btnMasterStudent.TabIndex = 7;
            this.btnMasterStudent.Text = "Master Student";
            this.btnMasterStudent.UseVisualStyleBackColor = true;
            this.btnMasterStudent.Click += new System.EventHandler(this.btnMasterStudent_Click);
            // 
            // btnMasterSteacher
            // 
            this.btnMasterSteacher.Location = new System.Drawing.Point(28, 106);
            this.btnMasterSteacher.Name = "btnMasterSteacher";
            this.btnMasterSteacher.Size = new System.Drawing.Size(451, 39);
            this.btnMasterSteacher.TabIndex = 8;
            this.btnMasterSteacher.Text = "Master Teacher";
            this.btnMasterSteacher.UseVisualStyleBackColor = true;
            this.btnMasterSteacher.Click += new System.EventHandler(this.btnMasterSteacher_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 225);
            this.Controls.Add(this.btnMasterSteacher);
            this.Controls.Add(this.btnMasterStudent);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblName);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMasterStudent;
        private System.Windows.Forms.Button btnMasterSteacher;
    }
}
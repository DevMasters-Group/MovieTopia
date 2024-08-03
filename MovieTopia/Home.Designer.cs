namespace MovieTopia
{
    partial class Home
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
            this.btnCStaff = new MovieTopia.Controls.BTN();
            this.btnCAdmin = new MovieTopia.Controls.BTN();
            this.SuspendLayout();
            // 
            // btnCStaff
            // 
            this.btnCStaff.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCStaff.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCStaff.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCStaff.BorderRadius = 40;
            this.btnCStaff.BorderSize = 0;
            this.btnCStaff.FlatAppearance.BorderSize = 0;
            this.btnCStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCStaff.ForeColor = System.Drawing.Color.White;
            this.btnCStaff.Location = new System.Drawing.Point(386, 200);
            this.btnCStaff.Name = "btnCStaff";
            this.btnCStaff.Size = new System.Drawing.Size(150, 40);
            this.btnCStaff.TabIndex = 1;
            this.btnCStaff.Text = "Continue as Staff";
            this.btnCStaff.TextColor = System.Drawing.Color.White;
            this.btnCStaff.UseVisualStyleBackColor = false;
            this.btnCStaff.Click += new System.EventHandler(this.btnCStaff_Click);
            // 
            // btnCAdmin
            // 
            this.btnCAdmin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCAdmin.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCAdmin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCAdmin.BorderRadius = 40;
            this.btnCAdmin.BorderSize = 0;
            this.btnCAdmin.FlatAppearance.BorderSize = 0;
            this.btnCAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCAdmin.ForeColor = System.Drawing.Color.White;
            this.btnCAdmin.Location = new System.Drawing.Point(386, 246);
            this.btnCAdmin.Name = "btnCAdmin";
            this.btnCAdmin.Size = new System.Drawing.Size(150, 40);
            this.btnCAdmin.TabIndex = 2;
            this.btnCAdmin.Text = "Continue as Admin";
            this.btnCAdmin.TextColor = System.Drawing.Color.White;
            this.btnCAdmin.UseVisualStyleBackColor = false;
            this.btnCAdmin.Click += new System.EventHandler(this.btnCAdmin_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 541);
            this.Controls.Add(this.btnCAdmin);
            this.Controls.Add(this.btnCStaff);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Home";
            this.Text = "MovieTopia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BTN btnCStaff;
        private Controls.BTN btnCAdmin;
    }
}


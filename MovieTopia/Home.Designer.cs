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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnCStaff = new MovieTopia.Controls.BTN();
            this.btnCAdmin = new MovieTopia.Controls.BTN();
            this.SuspendLayout();
            // 
            // btnCStaff
            // 
            this.btnCStaff.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCStaff.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCStaff.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btnCStaff.BorderRadius = 40;
            this.btnCStaff.BorderSize = 2;
            this.btnCStaff.FlatAppearance.BorderSize = 0;
            this.btnCStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCStaff.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCStaff.ForeColor = System.Drawing.Color.White;
            this.btnCStaff.Location = new System.Drawing.Point(515, 425);
            this.btnCStaff.Margin = new System.Windows.Forms.Padding(4);
            this.btnCStaff.Name = "btnCStaff";
            this.btnCStaff.Size = new System.Drawing.Size(230, 60);
            this.btnCStaff.TabIndex = 1;
            this.btnCStaff.Text = "Continue as Staff";
            this.btnCStaff.TextColor = System.Drawing.Color.White;
            this.btnCStaff.UseVisualStyleBackColor = false;
            this.btnCStaff.Click += new System.EventHandler(this.btnCStaff_Click);
            // 
            // btnCAdmin
            // 
            this.btnCAdmin.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnCAdmin.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.btnCAdmin.BorderColor = System.Drawing.Color.DarkViolet;
            this.btnCAdmin.BorderRadius = 40;
            this.btnCAdmin.BorderSize = 2;
            this.btnCAdmin.FlatAppearance.BorderSize = 0;
            this.btnCAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCAdmin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCAdmin.ForeColor = System.Drawing.Color.White;
            this.btnCAdmin.Location = new System.Drawing.Point(515, 508);
            this.btnCAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnCAdmin.Name = "btnCAdmin";
            this.btnCAdmin.Size = new System.Drawing.Size(230, 60);
            this.btnCAdmin.TabIndex = 2;
            this.btnCAdmin.Text = "Continue as Admin";
            this.btnCAdmin.TextColor = System.Drawing.Color.White;
            this.btnCAdmin.UseVisualStyleBackColor = false;
            this.btnCAdmin.Click += new System.EventHandler(this.btnCAdmin_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MovieTopia.Properties.Resources.logoFullPurple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.btnCAdmin);
            this.Controls.Add(this.btnCStaff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1280, 800);
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


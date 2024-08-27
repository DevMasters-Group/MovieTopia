namespace MovieTopia
{
    partial class Avalible_seats
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
            this.lblStage = new System.Windows.Forms.Label();
            this.lblTheater_num = new System.Windows.Forms.Label();
            this.btnSelect = new MovieTopia.Controls.BTN();
            this.SuspendLayout();
            // 
            // lblStage
            // 
            this.lblStage.AutoSize = true;
            this.lblStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStage.Location = new System.Drawing.Point(552, 612);
            this.lblStage.Name = "lblStage";
            this.lblStage.Size = new System.Drawing.Size(231, 22);
            this.lblStage.TabIndex = 115;
            this.lblStage.Text = "                                                       ";
            // 
            // lblTheater_num
            // 
            this.lblTheater_num.AutoSize = true;
            this.lblTheater_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheater_num.Location = new System.Drawing.Point(569, 9);
            this.lblTheater_num.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTheater_num.Name = "lblTheater_num";
            this.lblTheater_num.Size = new System.Drawing.Size(163, 46);
            this.lblTheater_num.TabIndex = 95;
            this.lblTheater_num.Text = "Theater";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.BackColor = System.Drawing.Color.Aqua;
            this.btnSelect.BackgroundColor = System.Drawing.Color.Aqua;
            this.btnSelect.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btnSelect.BorderRadius = 30;
            this.btnSelect.BorderSize = 2;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.DarkOrchid;
            this.btnSelect.Location = new System.Drawing.Point(567, 693);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(202, 62);
            this.btnSelect.TabIndex = 96;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextColor = System.Drawing.Color.DarkOrchid;
            this.btnSelect.UseMnemonic = false;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // Avalible_seats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 962);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblTheater_num);
            this.MinimumSize = new System.Drawing.Size(1437, 986);
            this.Name = "Avalible_seats";
            this.Text = "Avalible_seats";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();


        }

        #endregion

       

        

        private System.Windows.Forms.Label lblTheater_num;
        private Controls.BTN btnSelect;
        private System.Windows.Forms.Label lblStage;
    }



}

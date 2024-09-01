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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Avalible_seats));
            this.lblStage = new System.Windows.Forms.Label();
            this.lblTheater_num = new System.Windows.Forms.Label();
            this.gbxGuide = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReChoose = new MovieTopia.Controls.BTN();
            this.btnSelect = new MovieTopia.Controls.BTN();
            this.pnlSeats = new System.Windows.Forms.Panel();
            this.gbxGuide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // gbxGuide
            // 
            this.gbxGuide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxGuide.BackColor = System.Drawing.Color.PaleTurquoise;
            this.gbxGuide.Controls.Add(this.label3);
            this.gbxGuide.Controls.Add(this.label2);
            this.gbxGuide.Controls.Add(this.label1);
            this.gbxGuide.Controls.Add(this.pictureBox3);
            this.gbxGuide.Controls.Add(this.pictureBox2);
            this.gbxGuide.Controls.Add(this.pictureBox1);
            this.gbxGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxGuide.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbxGuide.Location = new System.Drawing.Point(1295, 15);
            this.gbxGuide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxGuide.Name = "gbxGuide";
            this.gbxGuide.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxGuide.Size = new System.Drawing.Size(359, 398);
            this.gbxGuide.TabIndex = 117;
            this.gbxGuide.TabStop = false;
            this.gbxGuide.Text = "Seat Booking Guide";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Available Seats";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selected Seats";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Previously booked seat";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::MovieTopia.Properties.Resources.logoIconDark;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(18, 162);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(56, 62);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MovieTopia.Properties.Resources.Seat_Icon_Main1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(18, 266);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 62);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::MovieTopia.Properties.Resources.logoIconLight;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(18, 55);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 62);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnReChoose
            // 
            this.btnReChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReChoose.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnReChoose.BackgroundColor = System.Drawing.Color.DarkOrchid;
            this.btnReChoose.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btnReChoose.BorderRadius = 30;
            this.btnReChoose.BorderSize = 2;
            this.btnReChoose.FlatAppearance.BorderSize = 0;
            this.btnReChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReChoose.ForeColor = System.Drawing.Color.White;
            this.btnReChoose.Location = new System.Drawing.Point(395, 692);
            this.btnReChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReChoose.Name = "btnReChoose";
            this.btnReChoose.Size = new System.Drawing.Size(202, 62);
            this.btnReChoose.TabIndex = 116;
            this.btnReChoose.Text = "Go Back";
            this.btnReChoose.TextColor = System.Drawing.Color.White;
            this.btnReChoose.UseMnemonic = false;
            this.btnReChoose.UseVisualStyleBackColor = false;
            this.btnReChoose.Click += new System.EventHandler(this.btnReChoose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.BackColor = System.Drawing.Color.Aqua;
            this.btnSelect.BackgroundColor = System.Drawing.Color.Aqua;
            this.btnSelect.BorderColor = System.Drawing.Color.Aqua;
            this.btnSelect.BorderRadius = 30;
            this.btnSelect.BorderSize = 2;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(698, 692);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(202, 62);
            this.btnSelect.TabIndex = 96;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextColor = System.Drawing.Color.Black;
            this.btnSelect.UseMnemonic = false;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pnlSeats
            // 
            this.pnlSeats.Location = new System.Drawing.Point(404, 59);
            this.pnlSeats.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSeats.Name = "pnlSeats";
            this.pnlSeats.Size = new System.Drawing.Size(543, 541);
            this.pnlSeats.TabIndex = 118;
            // 
            // Avalible_seats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 962);
            this.Controls.Add(this.pnlSeats);
            this.Controls.Add(this.gbxGuide);
            this.Controls.Add(this.btnReChoose);
            this.Controls.Add(this.lblStage);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblTheater_num);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1685, 984);
            this.Name = "Avalible_seats";
            this.Text = "Avalible_seats";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbxGuide.ResumeLayout(false);
            this.gbxGuide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       

        

        private System.Windows.Forms.Label lblTheater_num;
        private Controls.BTN btnSelect;
        private System.Windows.Forms.Label lblStage;
        private Controls.BTN btnReChoose;
        private System.Windows.Forms.GroupBox gbxGuide;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSeats;
    }



}

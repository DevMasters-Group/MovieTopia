﻿namespace MovieTopia
{
    partial class HomeStaff
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeStaff));
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormName = new System.Windows.Forms.Label();
            this.gbxFiltering = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.btnFilters = new MovieTopia.Controls.BTN();
            this.btnCancel = new MovieTopia.Controls.BTN();
            this.btnSelectMovie = new MovieTopia.Controls.BTN();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.gbxFiltering.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.AllowUserToAddRows = false;
            this.dgvSchedules.AllowUserToDeleteRows = false;
            this.dgvSchedules.BackgroundColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSchedules.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSchedules.Location = new System.Drawing.Point(42, 313);
            this.dgvSchedules.MultiSelect = false;
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSchedules.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSchedules.RowHeadersWidth = 51;
            this.dgvSchedules.RowTemplate.Height = 24;
            this.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedules.Size = new System.Drawing.Size(1353, 323);
            this.dgvSchedules.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = global::MovieTopia.Properties.Resources.logoFullDark;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(204, 100);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlTop.Controls.Add(this.lblFormName);
            this.pnlTop.Controls.Add(this.picLogo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1682, 99);
            this.pnlTop.TabIndex = 2;
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormName.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFormName.Location = new System.Drawing.Point(649, 23);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(355, 46);
            this.lblFormName.TabIndex = 9;
            this.lblFormName.Text = "Select Your Movie";
            // 
            // gbxFiltering
            // 
            this.gbxFiltering.BackColor = System.Drawing.Color.LightBlue;
            this.gbxFiltering.Controls.Add(this.btnFilters);
            this.gbxFiltering.Controls.Add(this.label2);
            this.gbxFiltering.Controls.Add(this.dtpDate);
            this.gbxFiltering.Controls.Add(this.label1);
            this.gbxFiltering.Controls.Add(this.cbxGenre);
            this.gbxFiltering.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxFiltering.Location = new System.Drawing.Point(42, 126);
            this.gbxFiltering.Name = "gbxFiltering";
            this.gbxFiltering.Size = new System.Drawing.Size(1353, 168);
            this.gbxFiltering.TabIndex = 5;
            this.gbxFiltering.TabStop = false;
            this.gbxFiltering.Text = "Selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select a date to filter movies by: ";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(408, 82);
            this.dtpDate.MinDate = new System.DateTime(2024, 8, 28, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(354, 28);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a genre to filter movies by Genre: ";
            // 
            // cbxGenre
            // 
            this.cbxGenre.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.Location = new System.Drawing.Point(408, 33);
            this.cbxGenre.Name = "cbxGenre";
            this.cbxGenre.Size = new System.Drawing.Size(354, 29);
            this.cbxGenre.TabIndex = 0;
            this.cbxGenre.Text = "* Please Select *";
            this.cbxGenre.SelectedIndexChanged += new System.EventHandler(this.cbxGenre_SelectedIndexChanged);
            // 
            // btnFilters
            // 
            this.btnFilters.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFilters.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnFilters.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFilters.BorderRadius = 40;
            this.btnFilters.BorderSize = 0;
            this.btnFilters.FlatAppearance.BorderSize = 0;
            this.btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilters.ForeColor = System.Drawing.Color.White;
            this.btnFilters.Location = new System.Drawing.Point(682, 45);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(164, 50);
            this.btnFilters.TabIndex = 4;
            this.btnFilters.Text = "Clear Filters";
            this.btnFilters.TextColor = System.Drawing.Color.White;
            this.btnFilters.UseVisualStyleBackColor = false;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BackgroundColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancel.BorderRadius = 40;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(806, 671);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelectMovie
            // 
            this.btnSelectMovie.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSelectMovie.BackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSelectMovie.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSelectMovie.BorderRadius = 40;
            this.btnSelectMovie.BorderSize = 0;
            this.btnSelectMovie.FlatAppearance.BorderSize = 0;
            this.btnSelectMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectMovie.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectMovie.ForeColor = System.Drawing.Color.White;
            this.btnSelectMovie.Location = new System.Drawing.Point(496, 671);
            this.btnSelectMovie.Name = "btnSelectMovie";
            this.btnSelectMovie.Size = new System.Drawing.Size(180, 50);
            this.btnSelectMovie.TabIndex = 3;
            this.btnSelectMovie.Text = "Select Movie";
            this.btnSelectMovie.TextColor = System.Drawing.Color.White;
            this.btnSelectMovie.UseVisualStyleBackColor = false;
            this.btnSelectMovie.Click += new System.EventHandler(this.btnSelectMovie_Click);
            // 
            // HomeStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 753);
            this.Controls.Add(this.gbxFiltering);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectMovie);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvSchedules);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1700, 800);
            this.Name = "HomeStaff";
            this.Text = "HomeStaff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomeStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.gbxFiltering.ResumeLayout(false);
            this.gbxFiltering.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlTop;
        private Controls.BTN btnSelectMovie;
        private Controls.BTN btnCancel;
        private System.Windows.Forms.GroupBox gbxFiltering;
        private System.Windows.Forms.ComboBox cbxGenre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private Controls.BTN btnFilters;
        private System.Windows.Forms.Label lblFormName;
    }
}
namespace MovieTopia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeStaff));
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxFiltering = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.btnCancel = new MovieTopia.Controls.BTN();
            this.btnSelectMovie = new MovieTopia.Controls.BTN();
            this.btnFilters = new MovieTopia.Controls.BTN();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbxFiltering.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.BackgroundColor = System.Drawing.Color.LightPink;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Location = new System.Drawing.Point(42, 313);
            this.dgvSchedules.MultiSelect = false;
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.RowHeadersWidth = 51;
            this.dgvSchedules.RowTemplate.Height = 24;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1438, 100);
            this.panel1.TabIndex = 2;
            // 
            // gbxFiltering
            // 
            this.gbxFiltering.BackColor = System.Drawing.Color.LightBlue;
            this.gbxFiltering.Controls.Add(this.btnFilters);
            this.gbxFiltering.Controls.Add(this.label2);
            this.gbxFiltering.Controls.Add(this.dtpDate);
            this.gbxFiltering.Controls.Add(this.label1);
            this.gbxFiltering.Controls.Add(this.cbxGenre);
            this.gbxFiltering.Location = new System.Drawing.Point(42, 126);
            this.gbxFiltering.MinimumSize = new System.Drawing.Size(1353, 168);
            this.gbxFiltering.Name = "gbxFiltering";
            this.gbxFiltering.Size = new System.Drawing.Size(1353, 168);
            this.gbxFiltering.TabIndex = 5;
            this.gbxFiltering.TabStop = false;
            this.gbxFiltering.Text = "Selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select a date to filter movies by: ";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(278, 83);
            this.dtpDate.MinDate = new System.DateTime(2024, 8, 28, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(251, 22);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a genre to filter movies by Genre: ";
            // 
            // cbxGenre
            // 
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.Location = new System.Drawing.Point(278, 33);
            this.cbxGenre.Name = "cbxGenre";
            this.cbxGenre.Size = new System.Drawing.Size(148, 24);
            this.cbxGenre.TabIndex = 0;
            this.cbxGenre.Text = "* Please Select *";
            this.cbxGenre.SelectedIndexChanged += new System.EventHandler(this.cbxGenre_SelectedIndexChanged);
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
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(806, 671);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(168, 50);
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
            this.btnSelectMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectMovie.ForeColor = System.Drawing.Color.White;
            this.btnSelectMovie.Location = new System.Drawing.Point(496, 671);
            this.btnSelectMovie.Name = "btnSelectMovie";
            this.btnSelectMovie.Size = new System.Drawing.Size(168, 50);
            this.btnSelectMovie.TabIndex = 3;
            this.btnSelectMovie.Text = "Select Movie";
            this.btnSelectMovie.TextColor = System.Drawing.Color.White;
            this.btnSelectMovie.UseVisualStyleBackColor = false;
            this.btnSelectMovie.Click += new System.EventHandler(this.btnSelectMovie_Click);
            // 
            // btnFilters
            // 
            this.btnFilters.BackColor = System.Drawing.Color.Crimson;
            this.btnFilters.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnFilters.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFilters.BorderRadius = 40;
            this.btnFilters.BorderSize = 0;
            this.btnFilters.FlatAppearance.BorderSize = 0;
            this.btnFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilters.ForeColor = System.Drawing.Color.White;
            this.btnFilters.Location = new System.Drawing.Point(648, 33);
            this.btnFilters.Name = "btnFilters";
            this.btnFilters.Size = new System.Drawing.Size(159, 63);
            this.btnFilters.TabIndex = 4;
            this.btnFilters.Text = "Remove Filters";
            this.btnFilters.TextColor = System.Drawing.Color.White;
            this.btnFilters.UseVisualStyleBackColor = false;
            this.btnFilters.Click += new System.EventHandler(this.btnFilters_Click);
            // 
            // HomeStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 745);
            this.Controls.Add(this.gbxFiltering);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectMovie);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSchedules);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1456, 792);
            this.Name = "HomeStaff";
            this.Text = "HomeStaff";
            this.Load += new System.EventHandler(this.HomeStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbxFiltering.ResumeLayout(false);
            this.gbxFiltering.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panel1;
        private Controls.BTN btnSelectMovie;
        private Controls.BTN btnCancel;
        private System.Windows.Forms.GroupBox gbxFiltering;
        private System.Windows.Forms.ComboBox cbxGenre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private Controls.BTN btnFilters;
    }
}
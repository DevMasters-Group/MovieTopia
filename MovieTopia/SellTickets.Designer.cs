namespace MovieTopia
{
    partial class SellTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellTickets));
            this.lblMovieDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblGenre = new System.Windows.Forms.Label();
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.dgvAvailableMovies = new System.Windows.Forms.DataGridView();
            this.lblAvailableMovies = new System.Windows.Forms.Label();
            this.btnCancel = new MovieTopia.Controls.BTN();
            this.btnSelect = new MovieTopia.Controls.BTN();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMovieDate
            // 
            this.lblMovieDate.AutoSize = true;
            this.lblMovieDate.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieDate.Location = new System.Drawing.Point(9, 60);
            this.lblMovieDate.Name = "lblMovieDate";
            this.lblMovieDate.Size = new System.Drawing.Size(130, 17);
            this.lblMovieDate.TabIndex = 7;
            this.lblMovieDate.Text = "Movie display date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(219, 54);
            this.dtpDate.MinDate = new System.DateTime(2024, 8, 18, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(251, 24);
            this.dtpDate.TabIndex = 6;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.Location = new System.Drawing.Point(12, 22);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(107, 17);
            this.lblGenre.TabIndex = 5;
            this.lblGenre.Text = "Filter by Genre:";
            // 
            // cbxGenre
            // 
            this.cbxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGenre.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.Location = new System.Drawing.Point(219, 19);
            this.cbxGenre.Name = "cbxGenre";
            this.cbxGenre.Size = new System.Drawing.Size(251, 25);
            this.cbxGenre.TabIndex = 4;
            // 
            // dgvAvailableMovies
            // 
            this.dgvAvailableMovies.AllowUserToAddRows = false;
            this.dgvAvailableMovies.AllowUserToDeleteRows = false;
            this.dgvAvailableMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableMovies.Location = new System.Drawing.Point(12, 137);
            this.dgvAvailableMovies.MultiSelect = false;
            this.dgvAvailableMovies.Name = "dgvAvailableMovies";
            this.dgvAvailableMovies.ReadOnly = true;
            this.dgvAvailableMovies.RowTemplate.Height = 24;
            this.dgvAvailableMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableMovies.Size = new System.Drawing.Size(811, 415);
            this.dgvAvailableMovies.TabIndex = 16;
            // 
            // lblAvailableMovies
            // 
            this.lblAvailableMovies.AutoSize = true;
            this.lblAvailableMovies.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableMovies.Location = new System.Drawing.Point(12, 105);
            this.lblAvailableMovies.Name = "lblAvailableMovies";
            this.lblAvailableMovies.Size = new System.Drawing.Size(118, 17);
            this.lblAvailableMovies.TabIndex = 17;
            this.lblAvailableMovies.Text = "Available Movies:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnCancel.BorderColor = System.Drawing.Color.DarkRed;
            this.btnCancel.BorderRadius = 30;
            this.btnCancel.BorderSize = 2;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Location = new System.Drawing.Point(659, 573);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 50);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.DarkRed;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.LightGreen;
            this.btnSelect.BackgroundColor = System.Drawing.Color.LightGreen;
            this.btnSelect.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSelect.BorderRadius = 30;
            this.btnSelect.BorderSize = 2;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSelect.Location = new System.Drawing.Point(460, 573);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(180, 50);
            this.btnSelect.TabIndex = 18;
            this.btnSelect.Text = "Select Movie";
            this.btnSelect.TextColor = System.Drawing.Color.DarkGreen;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SellTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblAvailableMovies);
            this.Controls.Add(this.dgvAvailableMovies);
            this.Controls.Add(this.lblMovieDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.cbxGenre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "SellTickets";
            this.Text = "SellTickets";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMovieDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ComboBox cbxGenre;
        private System.Windows.Forms.DataGridView dgvAvailableMovies;
        private System.Windows.Forms.Label lblAvailableMovies;
        private Controls.BTN btnCancel;
        private Controls.BTN btnSelect;
    }
}
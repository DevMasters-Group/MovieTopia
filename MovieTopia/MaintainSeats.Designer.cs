namespace MovieTopia
{
    partial class MaintainSeats
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
            this.lblTheater_num = new System.Windows.Forms.Label();
            this.cbTeater_Name = new System.Windows.Forms.ComboBox();
            this.dgvSeat = new System.Windows.Forms.DataGridView();
            this.btnDaiplaySeat = new MovieTopia.Controls.BTN();
            this.btnDelete = new MovieTopia.Controls.BTN();
            this.btnEdit = new MovieTopia.Controls.BTN();
            this.btnNew = new MovieTopia.Controls.BTN();
            this.btnReturn = new MovieTopia.Controls.BTN();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTheater_num
            // 
            this.lblTheater_num.AutoSize = true;
            this.lblTheater_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheater_num.Location = new System.Drawing.Point(20, 6);
            this.lblTheater_num.Name = "lblTheater_num";
            this.lblTheater_num.Size = new System.Drawing.Size(115, 31);
            this.lblTheater_num.TabIndex = 0;
            this.lblTheater_num.Text = "Theater";
            // 
            // cbTeater_Name
            // 
            this.cbTeater_Name.FormattingEnabled = true;
            this.cbTeater_Name.Location = new System.Drawing.Point(483, 49);
            this.cbTeater_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTeater_Name.Name = "cbTeater_Name";
            this.cbTeater_Name.Size = new System.Drawing.Size(110, 21);
            this.cbTeater_Name.TabIndex = 94;
            // 
            // dgvSeat
            // 
            this.dgvSeat.AllowUserToAddRows = false;
            this.dgvSeat.AllowUserToDeleteRows = false;
            this.dgvSeat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeat.Location = new System.Drawing.Point(18, 49);
            this.dgvSeat.MultiSelect = false;
            this.dgvSeat.Name = "dgvSeat";
            this.dgvSeat.ReadOnly = true;
            this.dgvSeat.RowHeadersWidth = 62;
            this.dgvSeat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSeat.Size = new System.Drawing.Size(410, 287);
            this.dgvSeat.TabIndex = 96;
            // 
            // btnDaiplaySeat
            // 
            this.btnDaiplaySeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDaiplaySeat.BackColor = System.Drawing.Color.Cyan;
            this.btnDaiplaySeat.BackgroundColor = System.Drawing.Color.Cyan;
            this.btnDaiplaySeat.BorderColor = System.Drawing.Color.Turquoise;
            this.btnDaiplaySeat.BorderRadius = 30;
            this.btnDaiplaySeat.BorderSize = 2;
            this.btnDaiplaySeat.FlatAppearance.BorderSize = 0;
            this.btnDaiplaySeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaiplaySeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaiplaySeat.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btnDaiplaySeat.Location = new System.Drawing.Point(462, 384);
            this.btnDaiplaySeat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDaiplaySeat.Name = "btnDaiplaySeat";
            this.btnDaiplaySeat.Size = new System.Drawing.Size(121, 40);
            this.btnDaiplaySeat.TabIndex = 95;
            this.btnDaiplaySeat.Text = "Dislay Seats";
            this.btnDaiplaySeat.TextColor = System.Drawing.Color.DarkTurquoise;
            this.btnDaiplaySeat.UseVisualStyleBackColor = false;
            this.btnDaiplaySeat.Click += new System.EventHandler(this.btnDisplaySeat_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnDelete.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.BorderRadius = 30;
            this.btnDelete.BorderSize = 2;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Location = new System.Drawing.Point(310, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 40);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextColor = System.Drawing.Color.DarkRed;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.LightGreen;
            this.btnEdit.BackgroundColor = System.Drawing.Color.LightGreen;
            this.btnEdit.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.BorderRadius = 30;
            this.btnEdit.BorderSize = 2;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.Location = new System.Drawing.Point(161, 384);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(135, 40);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNew.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnNew.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.BorderRadius = 30;
            this.btnNew.BorderSize = 2;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.Location = new System.Drawing.Point(14, 384);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(135, 40);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "New";
            this.btnNew.TextColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnReturn.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnReturn.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.BorderRadius = 30;
            this.btnReturn.BorderSize = 2;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.Location = new System.Drawing.Point(601, 384);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(135, 40);
            this.btnReturn.TabIndex = 97;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // MaintainSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 625);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvSeat);
            this.Controls.Add(this.btnDaiplaySeat);
            this.Controls.Add(this.cbTeater_Name);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblTheater_num);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(963, 655);
            this.Name = "MaintainSeats";
            this.Text = "MaintainSeats";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTheater_num;
        private Controls.BTN btnNew;
        private Controls.BTN btnEdit;
        private Controls.BTN btnDelete;
        private Controls.BTN btnDaiplaySeat;
        private System.Windows.Forms.ComboBox cbTeater_Name;
        
        private System.Windows.Forms.DataGridView dgvSeat;
        private Controls.BTN btnReturn;
    }
}
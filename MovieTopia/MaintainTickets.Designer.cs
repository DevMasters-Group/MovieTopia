namespace MovieTopia
{
    partial class MaintainTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintainTickets));
            this.lblName = new System.Windows.Forms.Label();
            this.dgvSchedules = new System.Windows.Forms.DataGridView();
            this.btnReturn = new MovieTopia.Controls.BTN();
            this.btnNew = new MovieTopia.Controls.BTN();
            this.btnDelete = new MovieTopia.Controls.BTN();
            this.btnEdit = new MovieTopia.Controls.BTN();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(227, 31);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Maintain Tickets";
            // 
            // dgvSchedules
            // 
            this.dgvSchedules.AllowUserToAddRows = false;
            this.dgvSchedules.AllowUserToDeleteRows = false;
            this.dgvSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedules.Location = new System.Drawing.Point(18, 80);
            this.dgvSchedules.MultiSelect = false;
            this.dgvSchedules.Name = "dgvSchedules";
            this.dgvSchedules.ReadOnly = true;
            this.dgvSchedules.RowHeadersWidth = 51;
            this.dgvSchedules.RowTemplate.Height = 24;
            this.dgvSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedules.Size = new System.Drawing.Size(465, 227);
            this.dgvSchedules.TabIndex = 5;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnReturn.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnReturn.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.BorderRadius = 30;
            this.btnReturn.BorderSize = 2;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.Location = new System.Drawing.Point(573, 339);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(180, 50);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextColor = System.Drawing.Color.MidnightBlue;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNew.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.btnNew.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.BorderRadius = 20;
            this.btnNew.BorderSize = 2;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.Location = new System.Drawing.Point(18, 340);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(177, 49);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.TextColor = System.Drawing.Color.MidnightBlue;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.BackgroundColor = System.Drawing.Color.IndianRed;
            this.btnDelete.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.BorderRadius = 20;
            this.btnDelete.BorderSize = 2;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDelete.Location = new System.Drawing.Point(388, 340);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(177, 49);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextColor = System.Drawing.Color.DarkRed;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.LightGreen;
            this.btnEdit.BackgroundColor = System.Drawing.Color.LightGreen;
            this.btnEdit.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.BorderRadius = 20;
            this.btnEdit.BorderSize = 2;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.Location = new System.Drawing.Point(203, 340);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(177, 49);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MaintainTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvSchedules);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "MaintainTickets";
            this.Text = "MaintainTickets";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dgvSchedules;
        private Controls.BTN btnNew;
        private Controls.BTN btnDelete;
        private Controls.BTN btnEdit;
        private Controls.BTN btnReturn;
    }
}
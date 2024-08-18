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
            this.btnSelectMovie = new MovieTopia.Controls.BTN();
            this.btnCancel = new MovieTopia.Controls.BTN();
            this.gbxFiltering = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1436, 100);
            this.panel1.TabIndex = 2;
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
            this.btnSelectMovie.ForeColor = System.Drawing.Color.Black;
            this.btnSelectMovie.Location = new System.Drawing.Point(496, 671);
            this.btnSelectMovie.Name = "btnSelectMovie";
            this.btnSelectMovie.Size = new System.Drawing.Size(168, 50);
            this.btnSelectMovie.TabIndex = 3;
            this.btnSelectMovie.Text = "Select Movie";
            this.btnSelectMovie.TextColor = System.Drawing.Color.Black;
            this.btnSelectMovie.UseVisualStyleBackColor = false;
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
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(806, 671);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(168, 50);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // gbxFiltering
            // 
            this.gbxFiltering.BackColor = System.Drawing.Color.LightBlue;
            this.gbxFiltering.Controls.Add(this.comboBox1);
            this.gbxFiltering.Location = new System.Drawing.Point(42, 126);
            this.gbxFiltering.Name = "gbxFiltering";
            this.gbxFiltering.Size = new System.Drawing.Size(1353, 168);
            this.gbxFiltering.TabIndex = 5;
            this.gbxFiltering.TabStop = false;
            this.gbxFiltering.Text = "Selection";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(393, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
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
            this.Name = "HomeStaff";
            this.Text = "HomeStaff";
            this.Load += new System.EventHandler(this.HomeStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbxFiltering.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedules;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panel1;
        private Controls.BTN btnSelectMovie;
        private Controls.BTN btnCancel;
        private System.Windows.Forms.GroupBox gbxFiltering;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
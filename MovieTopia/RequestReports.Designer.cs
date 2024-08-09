namespace MovieTopia
{
    partial class RequestReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestReports));
            this.label1 = new System.Windows.Forms.Label();
            this.cbbReportType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.cbxAsc = new System.Windows.Forms.CheckBox();
            this.cbxDesc = new System.Windows.Forms.CheckBox();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGenDate = new System.Windows.Forms.Label();
            this.lblAscDesc = new System.Windows.Forms.Label();
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.btnGenerate = new MovieTopia.Controls.BTN();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Report Type:";
            // 
            // cbbReportType
            // 
            this.cbbReportType.FormattingEnabled = true;
            this.cbbReportType.Items.AddRange(new object[] {
            "Top 10 Movies",
            "Top 10 Genres",
            "Ticket Sales"});
            this.cbbReportType.Location = new System.Drawing.Point(158, 13);
            this.cbbReportType.Name = "cbbReportType";
            this.cbbReportType.Size = new System.Drawing.Size(121, 21);
            this.cbbReportType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Time Period:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Start";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "End";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(161, 104);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 5;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(161, 166);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // cbxAsc
            // 
            this.cbxAsc.AutoSize = true;
            this.cbxAsc.Location = new System.Drawing.Point(19, 223);
            this.cbxAsc.Name = "cbxAsc";
            this.cbxAsc.Size = new System.Drawing.Size(76, 17);
            this.cbxAsc.TabIndex = 7;
            this.cbxAsc.Text = "Ascending";
            this.cbxAsc.UseVisualStyleBackColor = true;
            // 
            // cbxDesc
            // 
            this.cbxDesc.AutoSize = true;
            this.cbxDesc.Location = new System.Drawing.Point(161, 223);
            this.cbxDesc.Name = "cbxDesc";
            this.cbxDesc.Size = new System.Drawing.Size(83, 17);
            this.cbxDesc.TabIndex = 8;
            this.cbxDesc.Text = "Descending";
            this.cbxDesc.UseVisualStyleBackColor = true;
            // 
            // pnlReport
            // 
            this.pnlReport.BackColor = System.Drawing.SystemColors.Control;
            this.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReport.Controls.Add(this.dgvReport);
            this.pnlReport.Controls.Add(this.label5);
            this.pnlReport.Controls.Add(this.lblGenDate);
            this.pnlReport.Controls.Add(this.lblAscDesc);
            this.pnlReport.Controls.Add(this.lblTimePeriod);
            this.pnlReport.Controls.Add(this.lblReportType);
            this.pnlReport.Location = new System.Drawing.Point(383, 13);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(964, 559);
            this.pnlReport.TabIndex = 10;
            this.pnlReport.Visible = false;
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(87, 177);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(781, 306);
            this.dgvReport.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(784, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // lblGenDate
            // 
            this.lblGenDate.AutoSize = true;
            this.lblGenDate.Location = new System.Drawing.Point(4, 104);
            this.lblGenDate.Name = "lblGenDate";
            this.lblGenDate.Size = new System.Drawing.Size(35, 13);
            this.lblGenDate.TabIndex = 3;
            this.lblGenDate.Text = "label5";
            // 
            // lblAscDesc
            // 
            this.lblAscDesc.AutoSize = true;
            this.lblAscDesc.Location = new System.Drawing.Point(474, 76);
            this.lblAscDesc.Name = "lblAscDesc";
            this.lblAscDesc.Size = new System.Drawing.Size(35, 13);
            this.lblAscDesc.TabIndex = 2;
            this.lblAscDesc.Text = "label5";
            // 
            // lblTimePeriod
            // 
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.Location = new System.Drawing.Point(474, 40);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new System.Drawing.Size(35, 13);
            this.lblTimePeriod.TabIndex = 1;
            this.lblTimePeriod.Text = "label5";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Location = new System.Drawing.Point(474, 7);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(35, 13);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "label5";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnGenerate.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnGenerate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnGenerate.BorderRadius = 40;
            this.btnGenerate.BorderSize = 0;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(19, 284);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 40);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.TextColor = System.Drawing.Color.White;
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // RequestReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 584);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cbxDesc);
            this.Controls.Add(this.cbxAsc);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbReportType);
            this.Controls.Add(this.label1);
            this.Name = "RequestReports";
            this.Text = "RequestReports";
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbReportType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.CheckBox cbxAsc;
        private System.Windows.Forms.CheckBox cbxDesc;
        private Controls.BTN btnGenerate;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGenDate;
        private System.Windows.Forms.Label lblAscDesc;
        private System.Windows.Forms.Label lblTimePeriod;
        private System.Windows.Forms.Label lblReportType;
    }
}
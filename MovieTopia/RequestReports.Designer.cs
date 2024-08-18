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
            this.lblSelectReport = new System.Windows.Forms.Label();
            this.cbbReportType = new System.Windows.Forms.ComboBox();
            this.lblSelectDate = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.cbxAsc = new System.Windows.Forms.CheckBox();
            this.cbxDesc = new System.Windows.Forms.CheckBox();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblGenDate = new System.Windows.Forms.Label();
            this.lblAscDesc = new System.Windows.Forms.Label();
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.pnlTop10 = new System.Windows.Forms.Panel();
            this.pnlTicketSales = new System.Windows.Forms.Panel();
            this.cbbYear = new System.Windows.Forms.ComboBox();
            this.cbxMonthly = new System.Windows.Forms.CheckBox();
            this.cbxQuarterly = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new MovieTopia.Controls.BTN();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.pnlTop10.SuspendLayout();
            this.pnlTicketSales.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectReport
            // 
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Location = new System.Drawing.Point(30, 13);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(102, 13);
            this.lblSelectReport.TabIndex = 0;
            this.lblSelectReport.Text = "Select Report Type:";
            // 
            // cbbReportType
            // 
            this.cbbReportType.FormattingEnabled = true;
            this.cbbReportType.Items.AddRange(new object[] {
            "Top 10 Movies",
            "Top 10 Genres",
            "Ticket Sales"});
            this.cbbReportType.Location = new System.Drawing.Point(143, 13);
            this.cbbReportType.Name = "cbbReportType";
            this.cbbReportType.Size = new System.Drawing.Size(121, 21);
            this.cbbReportType.TabIndex = 1;
            this.cbbReportType.SelectedIndexChanged += new System.EventHandler(this.cbbReportType_SelectedIndexChanged);
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.AutoSize = true;
            this.lblSelectDate.Location = new System.Drawing.Point(12, 14);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(99, 13);
            this.lblSelectDate.TabIndex = 2;
            this.lblSelectDate.Text = "Select Time Period:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(125, 14);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(125, 75);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(26, 13);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "End";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(123, 41);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 5;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(123, 104);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // cbxAsc
            // 
            this.cbxAsc.AutoSize = true;
            this.cbxAsc.Location = new System.Drawing.Point(15, 158);
            this.cbxAsc.Name = "cbxAsc";
            this.cbxAsc.Size = new System.Drawing.Size(76, 17);
            this.cbxAsc.TabIndex = 7;
            this.cbxAsc.Text = "Ascending";
            this.cbxAsc.UseVisualStyleBackColor = true;
            this.cbxAsc.CheckedChanged += new System.EventHandler(this.cbxAsc_CheckedChanged);
            // 
            // cbxDesc
            // 
            this.cbxDesc.AutoSize = true;
            this.cbxDesc.Location = new System.Drawing.Point(123, 158);
            this.cbxDesc.Name = "cbxDesc";
            this.cbxDesc.Size = new System.Drawing.Size(83, 17);
            this.cbxDesc.TabIndex = 8;
            this.cbxDesc.Text = "Descending";
            this.cbxDesc.UseVisualStyleBackColor = true;
            this.cbxDesc.CheckedChanged += new System.EventHandler(this.cbxDesc_CheckedChanged);
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.BackColor = System.Drawing.SystemColors.Control;
            this.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReport.Controls.Add(this.label2);
            this.pnlReport.Controls.Add(this.label1);
            this.pnlReport.Controls.Add(this.dgvReport);
            this.pnlReport.Controls.Add(this.lblLine1);
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
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(87, 177);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(781, 306);
            this.dgvReport.TabIndex = 5;
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(84, 137);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(784, 13);
            this.lblLine1.TabIndex = 4;
            this.lblLine1.Text = resources.GetString("lblLine1.Text");
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
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(18, 22);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(65, 13);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Select Year:";
            // 
            // pnlTop10
            // 
            this.pnlTop10.Controls.Add(this.lblSelectDate);
            this.pnlTop10.Controls.Add(this.lblStart);
            this.pnlTop10.Controls.Add(this.dtStart);
            this.pnlTop10.Controls.Add(this.lblEnd);
            this.pnlTop10.Controls.Add(this.cbxDesc);
            this.pnlTop10.Controls.Add(this.dtEnd);
            this.pnlTop10.Controls.Add(this.cbxAsc);
            this.pnlTop10.Location = new System.Drawing.Point(12, 54);
            this.pnlTop10.Name = "pnlTop10";
            this.pnlTop10.Size = new System.Drawing.Size(346, 206);
            this.pnlTop10.TabIndex = 12;
            this.pnlTop10.Visible = false;
            // 
            // pnlTicketSales
            // 
            this.pnlTicketSales.Controls.Add(this.cbxQuarterly);
            this.pnlTicketSales.Controls.Add(this.cbxMonthly);
            this.pnlTicketSales.Controls.Add(this.cbbYear);
            this.pnlTicketSales.Controls.Add(this.lblYear);
            this.pnlTicketSales.Location = new System.Drawing.Point(12, 54);
            this.pnlTicketSales.Name = "pnlTicketSales";
            this.pnlTicketSales.Size = new System.Drawing.Size(346, 206);
            this.pnlTicketSales.TabIndex = 13;
            this.pnlTicketSales.Visible = false;
            // 
            // cbbYear
            // 
            this.cbbYear.FormattingEnabled = true;
            this.cbbYear.Location = new System.Drawing.Point(131, 22);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(121, 21);
            this.cbbYear.TabIndex = 12;
            // 
            // cbxMonthly
            // 
            this.cbxMonthly.AutoSize = true;
            this.cbxMonthly.Location = new System.Drawing.Point(21, 134);
            this.cbxMonthly.Name = "cbxMonthly";
            this.cbxMonthly.Size = new System.Drawing.Size(63, 17);
            this.cbxMonthly.TabIndex = 13;
            this.cbxMonthly.Text = "Monthly";
            this.cbxMonthly.UseVisualStyleBackColor = true;
            // 
            // cbxQuarterly
            // 
            this.cbxQuarterly.AutoSize = true;
            this.cbxQuarterly.Location = new System.Drawing.Point(131, 134);
            this.cbxQuarterly.Name = "cbxQuarterly";
            this.cbxQuarterly.Size = new System.Drawing.Size(68, 17);
            this.cbxQuarterly.TabIndex = 14;
            this.cbxQuarterly.Text = "Quarterly";
            this.cbxQuarterly.UseVisualStyleBackColor = true;
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
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(784, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "END OF REPORT";
            // 
            // RequestReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1359, 584);
            this.Controls.Add(this.pnlTicketSales);
            this.Controls.Add(this.pnlTop10);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cbbReportType);
            this.Controls.Add(this.lblSelectReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestReports";
            this.Text = "RequestReports";
            this.Load += new System.EventHandler(this.RequestReports_Load_1);
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.pnlTop10.ResumeLayout(false);
            this.pnlTop10.PerformLayout();
            this.pnlTicketSales.ResumeLayout(false);
            this.pnlTicketSales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectReport;
        private System.Windows.Forms.ComboBox cbbReportType;
        private System.Windows.Forms.Label lblSelectDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.CheckBox cbxAsc;
        private System.Windows.Forms.CheckBox cbxDesc;
        private Controls.BTN btnGenerate;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblGenDate;
        private System.Windows.Forms.Label lblAscDesc;
        private System.Windows.Forms.Label lblTimePeriod;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Panel pnlTop10;
        private System.Windows.Forms.Panel pnlTicketSales;
        private System.Windows.Forms.CheckBox cbxQuarterly;
        private System.Windows.Forms.CheckBox cbxMonthly;
        private System.Windows.Forms.ComboBox cbbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
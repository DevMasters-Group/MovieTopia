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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblGenDate = new System.Windows.Forms.Label();
            this.lblAscDesc = new System.Windows.Forms.Label();
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.pnlTop10 = new System.Windows.Forms.Panel();
            this.pnlTicketSales = new System.Windows.Forms.Panel();
            this.cbxQuarterly = new System.Windows.Forms.CheckBox();
            this.cbxMonthly = new System.Windows.Forms.CheckBox();
            this.cbbYear = new System.Windows.Forms.ComboBox();
            this.btnSave = new MovieTopia.Controls.BTN();
            this.btnGenerate = new MovieTopia.Controls.BTN();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.pnlTop10.SuspendLayout();
            this.pnlTicketSales.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectReport
            // 
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectReport.Location = new System.Drawing.Point(32, 24);
            this.lblSelectReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(121, 16);
            this.lblSelectReport.TabIndex = 0;
            this.lblSelectReport.Text = "Select Report Type:";
            // 
            // cbbReportType
            // 
            this.cbbReportType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbReportType.FormattingEnabled = true;
            this.cbbReportType.Items.AddRange(new object[] {
            "Top 10 Movies",
            "Top 10 Genres",
            "Ticket Sales"});
            this.cbbReportType.Location = new System.Drawing.Point(213, 21);
            this.cbbReportType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbReportType.Name = "cbbReportType";
            this.cbbReportType.Size = new System.Drawing.Size(160, 24);
            this.cbbReportType.TabIndex = 1;
            this.cbbReportType.SelectedIndexChanged += new System.EventHandler(this.cbbReportType_SelectedIndexChanged);
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.AutoSize = true;
            this.lblSelectDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDate.Location = new System.Drawing.Point(16, 17);
            this.lblSelectDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(121, 16);
            this.lblSelectDate.TabIndex = 2;
            this.lblSelectDate.Text = "Select Time Period:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(16, 50);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(41, 16);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "From:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(16, 85);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(24, 16);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "To:";
            // 
            // dtStart
            // 
            this.dtStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.Location = new System.Drawing.Point(96, 50);
            this.dtStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(311, 22);
            this.dtStart.TabIndex = 5;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.Location = new System.Drawing.Point(96, 80);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(311, 22);
            this.dtEnd.TabIndex = 6;
            // 
            // cbxAsc
            // 
            this.cbxAsc.AutoSize = true;
            this.cbxAsc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAsc.Location = new System.Drawing.Point(8, 22);
            this.cbxAsc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxAsc.Name = "cbxAsc";
            this.cbxAsc.Size = new System.Drawing.Size(87, 20);
            this.cbxAsc.TabIndex = 7;
            this.cbxAsc.Text = "Ascending";
            this.cbxAsc.UseVisualStyleBackColor = true;
            this.cbxAsc.CheckedChanged += new System.EventHandler(this.cbxAsc_CheckedChanged);
            // 
            // cbxDesc
            // 
            this.cbxDesc.AutoSize = true;
            this.cbxDesc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDesc.Location = new System.Drawing.Point(178, 22);
            this.cbxDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxDesc.Name = "cbxDesc";
            this.cbxDesc.Size = new System.Drawing.Size(94, 20);
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
            this.pnlReport.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReport.Location = new System.Drawing.Point(16, 357);
            this.pnlReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(1219, 662);
            this.pnlReport.TabIndex = 10;
            this.pnlReport.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(607, 641);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "END OF REPORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 625);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(784, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // dgvReport
            // 
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(116, 218);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(1041, 377);
            this.dgvReport.TabIndex = 5;
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(112, 169);
            this.lblLine1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(784, 16);
            this.lblLine1.TabIndex = 4;
            this.lblLine1.Text = resources.GetString("lblLine1.Text");
            // 
            // lblGenDate
            // 
            this.lblGenDate.AutoSize = true;
            this.lblGenDate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenDate.Location = new System.Drawing.Point(5, 128);
            this.lblGenDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenDate.Name = "lblGenDate";
            this.lblGenDate.Size = new System.Drawing.Size(45, 20);
            this.lblGenDate.TabIndex = 3;
            this.lblGenDate.Text = "label5";
            // 
            // lblAscDesc
            // 
            this.lblAscDesc.AutoSize = true;
            this.lblAscDesc.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAscDesc.Location = new System.Drawing.Point(632, 94);
            this.lblAscDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAscDesc.Name = "lblAscDesc";
            this.lblAscDesc.Size = new System.Drawing.Size(45, 20);
            this.lblAscDesc.TabIndex = 2;
            this.lblAscDesc.Text = "label5";
            // 
            // lblTimePeriod
            // 
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimePeriod.Location = new System.Drawing.Point(632, 49);
            this.lblTimePeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new System.Drawing.Size(45, 20);
            this.lblTimePeriod.TabIndex = 1;
            this.lblTimePeriod.Text = "label5";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(632, 9);
            this.lblReportType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(45, 20);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "label5";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(16, 17);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(78, 16);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Select Year:";
            // 
            // pnlTop10
            // 
            this.pnlTop10.Controls.Add(this.groupBox1);
            this.pnlTop10.Controls.Add(this.lblSelectDate);
            this.pnlTop10.Controls.Add(this.lblStart);
            this.pnlTop10.Controls.Add(this.dtStart);
            this.pnlTop10.Controls.Add(this.lblEnd);
            this.pnlTop10.Controls.Add(this.dtEnd);
            this.pnlTop10.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop10.Location = new System.Drawing.Point(16, 66);
            this.pnlTop10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop10.Name = "pnlTop10";
            this.pnlTop10.Size = new System.Drawing.Size(1219, 190);
            this.pnlTop10.TabIndex = 12;
            this.pnlTop10.Visible = false;
            // 
            // pnlTicketSales
            // 
            this.pnlTicketSales.Controls.Add(this.groupBox2);
            this.pnlTicketSales.Controls.Add(this.cbbYear);
            this.pnlTicketSales.Controls.Add(this.lblYear);
            this.pnlTicketSales.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTicketSales.Location = new System.Drawing.Point(16, 66);
            this.pnlTicketSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTicketSales.Name = "pnlTicketSales";
            this.pnlTicketSales.Size = new System.Drawing.Size(1219, 190);
            this.pnlTicketSales.TabIndex = 13;
            this.pnlTicketSales.Visible = false;
            // 
            // cbxQuarterly
            // 
            this.cbxQuarterly.AutoSize = true;
            this.cbxQuarterly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuarterly.Location = new System.Drawing.Point(7, 69);
            this.cbxQuarterly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxQuarterly.Name = "cbxQuarterly";
            this.cbxQuarterly.Size = new System.Drawing.Size(79, 20);
            this.cbxQuarterly.TabIndex = 14;
            this.cbxQuarterly.Text = "Quarterly";
            this.cbxQuarterly.UseVisualStyleBackColor = true;
            // 
            // cbxMonthly
            // 
            this.cbxMonthly.AutoSize = true;
            this.cbxMonthly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMonthly.Location = new System.Drawing.Point(7, 35);
            this.cbxMonthly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxMonthly.Name = "cbxMonthly";
            this.cbxMonthly.Size = new System.Drawing.Size(72, 20);
            this.cbxMonthly.TabIndex = 13;
            this.cbxMonthly.Text = "Monthly";
            this.cbxMonthly.UseVisualStyleBackColor = true;
            // 
            // cbbYear
            // 
            this.cbbYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbYear.FormattingEnabled = true;
            this.cbbYear.Location = new System.Drawing.Point(197, 14);
            this.cbbYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(160, 24);
            this.cbbYear.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSave.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 30;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1035, 281);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 49);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save as PDF";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnGenerate.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnGenerate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnGenerate.BorderRadius = 30;
            this.btnGenerate.BorderSize = 0;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(16, 281);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 49);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.TextColor = System.Drawing.Color.White;
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxAsc);
            this.groupBox1.Controls.Add(this.cbxDesc);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 56);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorting";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxMonthly);
            this.groupBox2.Controls.Add(this.cbxQuarterly);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 112);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period";
            // 
            // RequestReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTicketSales);
            this.Controls.Add(this.pnlTop10);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cbbReportType);
            this.Controls.Add(this.lblSelectReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "RequestReports";
            this.Text = "RequestReports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RequestReports_Load_1);
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.pnlTop10.ResumeLayout(false);
            this.pnlTop10.PerformLayout();
            this.pnlTicketSales.ResumeLayout(false);
            this.pnlTicketSales.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private Controls.BTN btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
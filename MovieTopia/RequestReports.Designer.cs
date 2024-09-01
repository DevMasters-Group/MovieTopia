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
            this.lblEndReport = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblGenDate = new System.Windows.Forms.Label();
            this.lblAscDesc = new System.Windows.Forms.Label();
            this.lblTimePeriod = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.pnlTop10 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlTicketSales = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxMonthly = new System.Windows.Forms.CheckBox();
            this.cbxQuarterly = new System.Windows.Forms.CheckBox();
            this.cbbYear = new System.Windows.Forms.ComboBox();
            this.btnReturn = new MovieTopia.Controls.BTN();
            this.btnSave = new MovieTopia.Controls.BTN();
            this.btnGenerate = new MovieTopia.Controls.BTN();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.pnlTop10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTicketSales.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSelectReport
            // 
            this.lblSelectReport.AutoSize = true;
            this.lblSelectReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectReport.Location = new System.Drawing.Point(24, 20);
            this.lblSelectReport.Name = "lblSelectReport";
            this.lblSelectReport.Size = new System.Drawing.Size(121, 16);
            this.lblSelectReport.TabIndex = 0;
            this.lblSelectReport.Text = "Select Report Type:";
            // 
            // cbbReportType
            // 
            this.cbbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbReportType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbReportType.FormattingEnabled = true;
            this.cbbReportType.Items.AddRange(new object[] {
            "Top 10 Movies",
            "Top 10 Genres",
            "Ticket Sales"});
            this.cbbReportType.Location = new System.Drawing.Point(160, 17);
            this.cbbReportType.Name = "cbbReportType";
            this.cbbReportType.Size = new System.Drawing.Size(121, 24);
            this.cbbReportType.TabIndex = 1;
            this.cbbReportType.SelectedIndexChanged += new System.EventHandler(this.cbbReportType_SelectedIndexChanged);
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.AutoSize = true;
            this.lblSelectDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDate.Location = new System.Drawing.Point(12, 14);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(121, 16);
            this.lblSelectDate.TabIndex = 2;
            this.lblSelectDate.Text = "Select Time Period:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(12, 41);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(41, 16);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "From:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(12, 69);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(24, 16);
            this.lblEnd.TabIndex = 4;
            this.lblEnd.Text = "To:";
            // 
            // dtStart
            // 
            this.dtStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.Location = new System.Drawing.Point(72, 41);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(234, 22);
            this.dtStart.TabIndex = 5;
            this.dtStart.ValueChanged += new System.EventHandler(this.dtStart_ValueChanged);
            // 
            // dtEnd
            // 
            this.dtEnd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.Location = new System.Drawing.Point(72, 65);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(234, 22);
            this.dtEnd.TabIndex = 6;
            // 
            // cbxAsc
            // 
            this.cbxAsc.AutoSize = true;
            this.cbxAsc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAsc.Location = new System.Drawing.Point(6, 18);
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
            this.cbxDesc.Location = new System.Drawing.Point(134, 18);
            this.cbxDesc.Name = "cbxDesc";
            this.cbxDesc.Size = new System.Drawing.Size(94, 20);
            this.cbxDesc.TabIndex = 8;
            this.cbxDesc.Text = "Descending";
            this.cbxDesc.UseVisualStyleBackColor = true;
            this.cbxDesc.CheckedChanged += new System.EventHandler(this.cbxDesc_CheckedChanged);
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlReport.BackColor = System.Drawing.SystemColors.Control;
            this.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReport.Controls.Add(this.lblEndReport);
            this.pnlReport.Controls.Add(this.lblLine2);
            this.pnlReport.Controls.Add(this.dgvReport);
            this.pnlReport.Controls.Add(this.lblLine1);
            this.pnlReport.Controls.Add(this.lblGenDate);
            this.pnlReport.Controls.Add(this.lblAscDesc);
            this.pnlReport.Controls.Add(this.lblTimePeriod);
            this.pnlReport.Controls.Add(this.lblReportType);
            this.pnlReport.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlReport.Location = new System.Drawing.Point(12, 270);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(909, 555);
            this.pnlReport.TabIndex = 10;
            this.pnlReport.Visible = false;
            // 
            // lblEndReport
            // 
            this.lblEndReport.AutoSize = true;
            this.lblEndReport.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndReport.Location = new System.Drawing.Point(431, 524);
            this.lblEndReport.Name = "lblEndReport";
            this.lblEndReport.Size = new System.Drawing.Size(115, 20);
            this.lblEndReport.TabIndex = 7;
            this.lblEndReport.Text = "END OF REPORT";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.Location = new System.Drawing.Point(84, 495);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(784, 16);
            this.lblLine2.TabIndex = 6;
            this.lblLine2.Text = resources.GetString("lblLine2.Text");
            this.lblLine2.Click += new System.EventHandler(this.lblLine2_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(87, 177);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.Size = new System.Drawing.Size(781, 306);
            this.dgvReport.TabIndex = 5;
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(84, 137);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(784, 16);
            this.lblLine1.TabIndex = 4;
            this.lblLine1.Text = resources.GetString("lblLine1.Text");
            // 
            // lblGenDate
            // 
            this.lblGenDate.AutoSize = true;
            this.lblGenDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenDate.Location = new System.Drawing.Point(4, 104);
            this.lblGenDate.Name = "lblGenDate";
            this.lblGenDate.Size = new System.Drawing.Size(50, 18);
            this.lblGenDate.TabIndex = 3;
            this.lblGenDate.Text = "label5";
            // 
            // lblAscDesc
            // 
            this.lblAscDesc.AutoSize = true;
            this.lblAscDesc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAscDesc.Location = new System.Drawing.Point(474, 76);
            this.lblAscDesc.Name = "lblAscDesc";
            this.lblAscDesc.Size = new System.Drawing.Size(50, 18);
            this.lblAscDesc.TabIndex = 2;
            this.lblAscDesc.Text = "label5";
            // 
            // lblTimePeriod
            // 
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimePeriod.Location = new System.Drawing.Point(474, 40);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new System.Drawing.Size(50, 18);
            this.lblTimePeriod.TabIndex = 1;
            this.lblTimePeriod.Text = "label5";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.Location = new System.Drawing.Point(474, 7);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(50, 18);
            this.lblReportType.TabIndex = 0;
            this.lblReportType.Text = "label5";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(12, 14);
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
            this.pnlTop10.Location = new System.Drawing.Point(12, 54);
            this.pnlTop10.Name = "pnlTop10";
            this.pnlTop10.Size = new System.Drawing.Size(914, 154);
            this.pnlTop10.TabIndex = 12;
            this.pnlTop10.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxAsc);
            this.groupBox1.Controls.Add(this.cbxDesc);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(256, 46);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sorting";
            // 
            // pnlTicketSales
            // 
            this.pnlTicketSales.Controls.Add(this.groupBox2);
            this.pnlTicketSales.Controls.Add(this.cbbYear);
            this.pnlTicketSales.Controls.Add(this.lblYear);
            this.pnlTicketSales.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTicketSales.Location = new System.Drawing.Point(12, 54);
            this.pnlTicketSales.Name = "pnlTicketSales";
            this.pnlTicketSales.Size = new System.Drawing.Size(914, 154);
            this.pnlTicketSales.TabIndex = 13;
            this.pnlTicketSales.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxMonthly);
            this.groupBox2.Controls.Add(this.cbxQuarterly);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(254, 91);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Period";
            // 
            // cbxMonthly
            // 
            this.cbxMonthly.AutoSize = true;
            this.cbxMonthly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMonthly.Location = new System.Drawing.Point(5, 28);
            this.cbxMonthly.Name = "cbxMonthly";
            this.cbxMonthly.Size = new System.Drawing.Size(72, 20);
            this.cbxMonthly.TabIndex = 13;
            this.cbxMonthly.Text = "Monthly";
            this.cbxMonthly.UseVisualStyleBackColor = true;
            this.cbxMonthly.CheckedChanged += new System.EventHandler(this.cbxMonthly_CheckedChanged);
            // 
            // cbxQuarterly
            // 
            this.cbxQuarterly.AutoSize = true;
            this.cbxQuarterly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxQuarterly.Location = new System.Drawing.Point(5, 56);
            this.cbxQuarterly.Name = "cbxQuarterly";
            this.cbxQuarterly.Size = new System.Drawing.Size(79, 20);
            this.cbxQuarterly.TabIndex = 14;
            this.cbxQuarterly.Text = "Quarterly";
            this.cbxQuarterly.UseVisualStyleBackColor = true;
            this.cbxQuarterly.CheckedChanged += new System.EventHandler(this.cbxQuarterly_CheckedChanged);
            // 
            // cbbYear
            // 
            this.cbbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbYear.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbYear.FormattingEnabled = true;
            this.cbbYear.Location = new System.Drawing.Point(148, 11);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(121, 24);
            this.cbbYear.TabIndex = 12;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DimGray;
            this.btnReturn.BackgroundColor = System.Drawing.Color.DimGray;
            this.btnReturn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReturn.BorderRadius = 40;
            this.btnReturn.BorderSize = 0;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(11, 887);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(150, 40);
            this.btnReturn.TabIndex = 15;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextColor = System.Drawing.Color.White;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
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
            this.btnSave.Location = new System.Drawing.Point(776, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
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
            this.btnGenerate.Location = new System.Drawing.Point(12, 214);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 40);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.TextColor = System.Drawing.Color.White;
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // RequestReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(948, 942);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlTicketSales);
            this.Controls.Add(this.pnlTop10);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cbbReportType);
            this.Controls.Add(this.lblSelectReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(964, 657);
            this.Name = "RequestReports";
            this.Text = "RequestReports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RequestReports_Load_1);
            this.Resize += new System.EventHandler(this.RequestReports_Resize);
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.pnlTop10.ResumeLayout(false);
            this.pnlTop10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTicketSales.ResumeLayout(false);
            this.pnlTicketSales.PerformLayout();
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
        private System.Windows.Forms.Label lblEndReport;
        private System.Windows.Forms.Label lblLine2;
        private Controls.BTN btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.BTN btnReturn;
    }
}
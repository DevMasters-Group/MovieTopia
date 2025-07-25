﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace MovieTopia
{
    public partial class RequestReports : Form
    {
        private string DATABASE_URL;
        DataSet ds;
        SqlDataAdapter adapter;
        private string ascDesc;
        DateTime startDate;
        DateTime endDate;
        private string year;
        private string grouping;
        private string reportType;
        private int padding = 20;

        public RequestReports()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            InitializeComponent();

            btnReturn.Font = new Font("Arial", 12, FontStyle.Regular);
        }

        private void RequestReports_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    pnlReport.Size = new Size(915, 540);

            //}
            //else if (this.WindowState == FormWindowState.Maximized)
            //{
            //    pnlReport.Size = new Size(1830, 570);

            //}
            //else if (this.WindowState == FormWindowState.Normal)
            //{
            //    pnlReport.Size = new Size(915, 570);

            //}
            btnGenerate.Left = padding;
            pnlReport.Left = padding;
            pnlReport.Top = btnGenerate.Top + btnGenerate.Height + padding /2;
            pnlReport.Width = this.ClientSize.Width - 2 * padding;
            pnlReport.Height = this.ClientSize.Height - pnlReport.Top - 4 * padding;
            pnlReport.AutoScroll = true;
            btnSave.Left = pnlReport.Left + pnlReport.Width - btnSave.Width;
            btnReturn.Left = pnlReport.Left + pnlReport.Width - btnSave.Width;
            btnReturn.Top = pnlReport.Top + pnlReport.Height + padding / 2;

            CenterControlsOnPanel();
        }

        private void CenterControlsOnPanel()
        {
            lblReportType.Left = (pnlReport.ClientSize.Width - lblReportType.Width) / 2;
            //lblReportType.Top = (pnlReport.ClientSize.Height - lblReportType.Height) / 2;
            lblTimePeriod.Left = (pnlReport.ClientSize.Width - lblTimePeriod.Width) / 2;
            //lblTimePeriod.Top = (pnlReport.ClientSize.Height - lblTimePeriod.Height) / 2;
            lblAscDesc.Left = (pnlReport.ClientSize.Width - lblAscDesc.Width) / 2;
            //lblAscDesc.Top = (pnlReport.ClientSize.Height - lblAscDesc.Height) / 2;
            lblGenDate.Left = (pnlReport.ClientSize.Width - lblGenDate.Width) / 2;
            //lblGenDate.Top = (pnlReport.ClientSize.Height - lblGenDate.Height) / 2;
            lblLine1.Left = (pnlReport.ClientSize.Width - lblLine1.Width) / 2;
            //lblLine1.Top = (pnlReport.ClientSize.Height - lblLine1.Height) / 2;
            dgvReport.Left = (pnlReport.ClientSize.Width - dgvReport.Width) / 2;
            //dgvReport.Top = (pnlReport.ClientSize.Height - dgvReport.Height) / 2;
            lblLine2.Left = (pnlReport.ClientSize.Width - lblLine2.Width) / 2;
            //lblLine2.Top = (pnlReport.ClientSize.Height - lblLine2.Height) / 2;
            lblEndReport.Left = (pnlReport.ClientSize.Width - lblEnd.Width) / 2;
            //lblEnd.Top = (pnlReport.ClientSize.Height - lblEnd.Height) / 2;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                reportType = cbbReportType.SelectedItem.ToString();

                if(cbbReportType.SelectedIndex == 0 || cbbReportType.SelectedIndex == 1)
                {
                    startDate = dtStart.Value;
                    endDate = dtEnd.Value;

                    lblReportType.Text = reportType;
                    lblTimePeriod.Text = "For time period: " + startDate.ToShortDateString() + " to " + endDate.ToShortDateString();

                    while (!(cbxAsc.Checked) && !(cbxDesc.Checked))
                    {
                        MessageBox.Show("Please select either Ascending or Descending");
                        cbxAsc.Focus();
                        return;
                    }

                    if (cbxAsc.Checked)
                    {
                        lblAscDesc.Text = "Ascending Order";
                        lblGenDate.Text = "Generation date of report: " + DateTime.Today.ToShortDateString();
                        ascDesc = "ASC";

                        pnlReport.Visible = true;
                        cbxDesc.Checked = false;
                        btnSave.Visible = true;
                    }
                    else if (cbxDesc.Checked)
                    {
                        lblAscDesc.Text = "Descending Order";
                        lblGenDate.Text = "Generation date of report: " + DateTime.Today.ToShortDateString();
                        ascDesc = "DESC";

                        pnlReport.Visible = true;
                        cbxAsc.Checked = false;
                        btnSave.Visible = true;
                    }

                    populateDGV();
                }
                else if(cbbReportType.SelectedIndex == 2)
                {
                    
                    lblReportType.Text = reportType;

                    while (cbbYear.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a year.");
                        cbbYear.Focus();
                        return;  
                    }

                    year = cbbYear.SelectedItem.ToString();
                    lblTimePeriod.Text = year;

                    while(!(cbxMonthly.Checked) && !(cbxQuarterly.Checked))
                    {
                        MessageBox.Show("Please select either monthly or quarterly");
                        cbxMonthly.Focus();
                        cbxQuarterly.Focus();
                        return;

                    }

                    if(cbxMonthly.Checked)
                    {
                        grouping = "Monthly";
                        lblAscDesc.Text = grouping;
                        lblGenDate.Text = "Generation date of report: " + DateTime.Today.ToShortDateString();

                        pnlReport.Visible = true;
                        btnSave.Visible = true;


                    }
                    else if(cbxQuarterly.Checked)
                    {
                        grouping = "Quarterly";
                        lblAscDesc.Text = grouping;
                        lblGenDate.Text = "Generation date of report: " + DateTime.Today.ToShortDateString();

                        pnlReport.Visible = true;
                        btnSave.Visible = true;
                    }

                    populateDGV();

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RequestReports_Load(object sender, EventArgs e)
        {
            cbbReportType.SelectedIndex = 0;
        }

        private void populateDGV()
        {
            using(SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                String sql = "";

                if (reportType == "Top 10 Movies")
                {
                    sql = $@"SELECT TOP 10 m.Title, COUNT(t.TicketID) AS TicketsSold, FORMAT(SUM(ms.Price), 'N2') AS TotalPrice
                            FROM Movie m
                            JOIN MovieSchedule ms ON ms.MovieID = m.MovieID
                            JOIN Ticket t ON ms.MovieScheduleID = t.MovieScheduleID
                            WHERE t.PurchaseDateTime BETWEEN @startDate AND @endDate
                            GROUP BY m.Title
                            ORDER BY TicketsSold {ascDesc}";

                  
                }
                else if(reportType == "Top 10 Genres")
                {
                    sql = $@"SELECT TOP 10 g.GenreName, COUNT(t.TicketID) AS TicketsSold, FORMAT(SUM(ms.Price), 'N2') AS TotalPrice
                            FROM Genre g
                            JOIN Movie m ON g.GenreID = m.GenreID
                            JOIN MovieSchedule ms ON m.MovieID = ms.MovieID
                            JOIN Ticket t ON ms.MovieScheduleID = t.MovieScheduleID
                            WHERE t.PurchaseDateTime BETWEEN @startDate AND @endDate
                            GROUP BY g.GenreName
                            ORDER BY TicketsSold {ascDesc}";

                    

                }
                else if(reportType == "Ticket Sales")
                {

                    if (grouping == "Monthly")
                    {
                        sql = $@"SELECT DATENAME(MONTH, t.PurchaseDateTime) AS [Period],
                               COUNT(t.TicketID) AS TicketsSold,
                               FORMAT(SUM(ms.Price), 'N2') AS TotalPrice
                        FROM Ticket t
                        JOIN MovieSchedule ms ON ms.MovieScheduleID = t.MovieScheduleID
                        WHERE YEAR(t.PurchaseDateTime) = @SelectedYear
                        GROUP BY MONTH(t.PurchaseDateTime), DATENAME(MONTH, t.PurchaseDateTime)
                        ORDER BY MONTH(t.PurchaseDateTime);

                        SELECT 'Total' AS [Period], COUNT(t.TicketID) AS [Tickets Sold], FORMAT(SUM(ms.Price), 'N2') AS TotalPrice
                        FROM Ticket t
                        JOIN MovieSchedule ms ON ms.MovieScheduleID = t.MovieScheduleID
                        WHERE YEAR(t.PurchaseDateTime) = @SelectedYear;";
                    }
                    else if (grouping == "Quarterly")
                    {
                        sql = $@"SELECT 'Q' + CAST(DATEPART(QUARTER, t.PurchaseDateTime) AS VARCHAR) AS [Period],
                               COUNT(t.TicketID) AS TicketsSold, FORMAT(SUM(ms.Price), 'N2') AS TotalPrice
                        FROM Ticket t
                        JOIN MovieSchedule ms ON ms.MovieScheduleID = t.MovieScheduleID
                        WHERE YEAR(t.PurchaseDateTime) = @SelectedYear
                        GROUP BY DATEPART(QUARTER, t.PurchaseDateTime)
                        ORDER BY DATEPART(QUARTER, t.PurchaseDateTime);

                        SELECT 'Total' AS [Period], COUNT(t.TicketID) AS [Tickets Sold], FORMAT(SUM(ms.Price), 'N2') AS TotalPrice
                        FROM Ticket t
                        JOIN MovieSchedule ms ON ms.MovieScheduleID = t.MovieScheduleID
                        WHERE YEAR(t.PurchaseDateTime) = @SelectedYear;";
                    }


                }

                SqlCommand comm = new SqlCommand(sql, conn);

                if(reportType == "Top 10 Movies" || reportType == "Top 10 Genres")
                {
                    comm.Parameters.AddWithValue("@startDate", startDate);
                    comm.Parameters.AddWithValue("@endDate", endDate);
                    comm.Parameters.AddWithValue("@ascDesc", ascDesc);
                }
                else if(reportType == "Ticket Sales")
                {
                    comm.Parameters.AddWithValue("@GroupingOption", grouping);
                    comm.Parameters.AddWithValue("@SelectedYear", year);
                }

                adapter.SelectCommand = comm;
                adapter.Fill(ds, "Data");

                dgvReport.DataSource = ds;
                dgvReport.DataMember = "Data";



                if (reportType == "Ticket Sales" && ds.Tables.Count > 1)
                {
                    DataRow totalRow = ds.Tables[1].Rows[0];
                    DataRow newRow = ds.Tables[0].NewRow();
                    newRow["Period"] = totalRow["Period"];
                    newRow["TicketsSold"] = totalRow["Tickets Sold"];
                    decimal totalPrice = Convert.ToDecimal(totalRow["TotalPrice"]);
                    newRow["TotalPrice"] = totalPrice.ToString("F2");
                    ds.Tables[0].Rows.Add(newRow);
                }

            }
        }


        private void RequestReports_Load_1(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;

            for(int i = currentYear; i >= 2000; i--)
            {
                cbbYear.Items.Add(i.ToString());
            }

            

            
        }

        private void cbxAsc_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxAsc.Checked)
            {
                cbxDesc.Checked = false;
            }


        }

        private void cbxDesc_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxDesc.Checked)
            {
                cbxAsc.Checked = false;
            }
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbReportType.SelectedIndex == 0 || cbbReportType.SelectedIndex == 1)
            {
                pnlTicketSales.Visible = false;
                pnlTop10.Visible = true;
                btnGenerate.Visible = true;
            }
            else if(cbbReportType.SelectedIndex == 2)
            {
                pnlTicketSales.Visible = true;
                pnlTop10.Visible = false;
                btnGenerate.Visible = true;
            }
            else if(cbbReportType.SelectedIndex == -1)
            {
                pnlTicketSales.Visible = false;
                pnlTop10.Visible = false;
                btnGenerate.Visible = false;
            }
        }

        private Bitmap CapturePanel(Panel panel)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);

            panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));

            return bitmap;
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            try
            {
                this.WindowState = FormWindowState.Normal;
                //Set up the print event handler
                printDoc.PrintPage += (sndr, args) =>
                {
                    Bitmap panelImage = CapturePanel(pnlReport);
                    args.Graphics.DrawImage(panelImage, args.MarginBounds);
                };
                //set up the print dialog
                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDoc,
                    UseEXDialog = true
                };

                //Show the print dialog and allow the user to choose "Microsoft Print to PDF"
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.PrinterSettings = printDialog.PrinterSettings;
                    printDoc.Print();

                    this.Activate();
                }
                this.WindowState = FormWindowState.Maximized;
                MessageBox.Show("Report saved as PDF");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message);
            }
            

            
        }

        private void cbxMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMonthly.Checked)
            {
                cbxQuarterly.Checked = false;
            }
            else if(cbxQuarterly.Checked)
            {
                cbxMonthly.Checked = false;
            }
        }

        private void cbxQuarterly_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxQuarterly.Checked)
            {
                cbxMonthly.Checked = false;
            }
            else if (cbxQuarterly.Checked)
            {
                cbxMonthly.Checked = false;
            }
        }

        private void lblLine2_Click(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

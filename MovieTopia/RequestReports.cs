using System;
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
        public RequestReports()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            InitializeComponent();
        }

        private string DATABASE_URL;
        DataSet ds;
        SqlDataAdapter adapter;
        private string ascDesc;
        DateTime startDate;
        DateTime endDate;
        private string year;
        private string grouping;
        private string reportType;

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
                        break;
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
                        break;
                    }

                    year = cbbYear.SelectedItem.ToString();
                    lblTimePeriod.Text = year;

                    while(!(cbxMonthly.Checked) && !(cbxQuarterly.Checked))
                    {
                        MessageBox.Show("Please select either monthly or quarterly");
                        break;

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
                    sql = $@"SELECT TOP 10 m.Title, COUNT(t.TicketID) AS TicketsSold
                            FROM Movie m
                            JOIN MovieSchedule ms ON ms.MovieID = m.MovieID
                            JOIN Ticket t ON ms.MovieScheduleID = t.MovieScheduleID
                            WHERE t.PurchaseDateTime BETWEEN @startDate AND @endDate
                            GROUP BY m.Title
                            ORDER BY TicketsSold {ascDesc}";

                  
                }
                else if(reportType == "Top 10 Genres")
                {
                    sql = $@"SELECT TOP 10 g.GenreName, COUNT(t.TicketID) AS TicketsSold
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
                    
                    sql = $@"IF @GroupingOption = 'Monthly'
                             BEGIN
                                SELECT DATENAME(MONTH, t.PurchaseDateTime) AS [Period],
                                       COUNT(t.TicketID) AS TicketsSold
                                FROM Ticket t
                                WHERE YEAR(t.PurchaseDateTime) = @SelectedYear
                                GROUP BY MONTH(t.PurchaseDateTime), DATENAME(MONTH, t.PurchaseDateTime)
                                ORDER BY MONTH(t.PurchaseDateTime)
                             END
                             ELSE IF @GroupingOption = 'Quarterly'
                             BEGIN
                                SELECT 'Q' + CAST(DATEPART(QUARTER, t.PurchaseDateTime) AS VARCHAR) AS [Period],
                                       COUNT(t.TicketID) AS TicketsSold
                                FROM Ticket t
                                WHERE YEAR(t.PurchaseDateTime) = @SelectedYear
                                GROUP BY DATEPART(QUARTER, t.PurchaseDateTime)
                                ORDER BY DATEPART(QUARTER, t.PurchaseDateTime)
                             END";

                    
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
                pnlTop10.Visible = false;
                pnlTicketSales.Visible = true;
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

                MessageBox.Show("Report saved as PDF");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message);
            }
            

            
        }
    }
}

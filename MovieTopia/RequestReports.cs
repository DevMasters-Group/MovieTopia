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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                String reportType = cbbReportType.SelectedItem.ToString();
                DateTime startDate = dtStart.Value;
                DateTime endDate = dtEnd.Value;

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

                    pnlReport.Visible = true;
                }
                else if (cbxDesc.Checked)
                {
                    lblAscDesc.Text = "Descending Order";
                    lblGenDate.Text = "Generation date of report: " + DateTime.Today.ToShortDateString();

                    pnlReport.Visible = true;
                }

                populateDGV(reportType, startDate, endDate);
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

        private void populateDGV(String reportType, DateTime startDate, DateTime endDate)
        {
            using(SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                String sql = "";

                if(reportType == "Top 10 Movies")
                {
                    sql = @"SELECT TOP 2 m.Title, COUNT(*) AS TicketsSold
                            FROM Movie m
                            JOIN MovieSchedule ms ON ms.MovieID = m.MovieID
                            JOIN Ticket t ON ms.MovieScheduleID = t.MovieScheduleID
                            WHERE t.PurchaseDateTime BETWEEN @startDate AND @endDate
                            GROUP BY m.Title
                            ORDER BY TicketsSold ASC";
                }
                else if(reportType == "Top 10 Genres")
                {
                    sql = @"SELECT TOP 2 g.GenreName, COUNT(*) AS TicketsSold
                            FROM Genre g
                            JOIN Movie m ON g.GenreID = m.GenreID
                            JOIN MovieSchedule ms ON m.MovieID = ms.MovieID
                            JOIN Ticket t ON ms.MovieScheduleID = t.MovieScheduleID
                            WHERE t.PurchaseDateTime BETWEEN @startDate AND @endDate
                            GROUP BY g.GenreName
                            ORDER BY TicketsSold ASC";
                             
                }

                SqlCommand comm = new SqlCommand(sql, conn);

                comm.Parameters.AddWithValue("@startDate", startDate);
                comm.Parameters.AddWithValue("@endDate", endDate);

                adapter.SelectCommand = comm;
                adapter.Fill(ds, "Data");

                dgvReport.DataSource = ds;
                dgvReport.DataMember = "Data";

            }
        }
    }
}

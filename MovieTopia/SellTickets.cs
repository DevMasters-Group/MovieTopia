using MovieTopia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MovieTopia
{
    public partial class SellTickets : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        private string tblName = "MovieSchedule";
        DataSet ds;
        SqlDataAdapter adapter;

        public SellTickets()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();

            this.Resize += Form_Resize;

            LoadData();
            LoadGenres();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            lblGenre.Top = padding;
            lblMovieDate.Top = padding * 3;
            lblAvailableMovies.Top = padding * 5;
            lblGenre.Left = padding;
            lblMovieDate.Left = padding;
            lblAvailableMovies.Left = padding;

            cbxGenre.Top = padding;
            dtpDate.Top = padding * 3;

            btnSelect.Left = (this.ClientSize.Width / 2) - btnSelect.Width - padding;
            btnCancel.Left = btnSelect.Left + btnSelect.Width + padding;
            btnSelect.Top = (this.ClientSize.Height - btnSelect.Height - padding * 2);
            btnCancel.Top = (this.ClientSize.Height - btnCancel.Height - padding * 2);

            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void AdjustDataGridViewSize()
        {
            dgvData.Width = this.ClientSize.Width - (2 * padding);
            dgvData.Height = this.ClientSize.Height - (12 * padding);
            dgvData.Location = new Point(padding, padding * 7);
        }

        private void AdjustColumnWidths()
        {
            if (dgvData.Columns.Count == 0)
                return;

            dgvData.Columns["Duration"].HeaderText = "Duration (minutes)";
            dgvData.Columns["DateTime"].HeaderText = "Date & Time";
            dgvData.Columns["PG_Rating"].HeaderText = "PG Rating";
            dgvData.Columns["TheatreName"].HeaderText = "Theatre";
            dgvData.Columns["GenreName"].HeaderText = "Genre";
            dgvData.Columns["TotalSeats"].HeaderText = "Total Seats";
            dgvData.Columns["BookedSeats"].HeaderText = "Booked Seats";
            dgvData.Columns["AvailableSeats"].HeaderText = "Available Seats";

            dgvData.Columns["Price"].Width = (int)(dgvData.Width * 0.06);
            dgvData.Columns["DateTime"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["Title"].Width = (int)(dgvData.Width * 0.147);
            dgvData.Columns["Duration"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["PG_Rating"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["TheatreName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["GenreName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["TotalSeats"].Width = (int)(dgvData.Width * 0.09);
            dgvData.Columns["BookedSeats"].Width = (int)(dgvData.Width * 0.09);
            dgvData.Columns["AvailableSeats"].Width = (int)(dgvData.Width * 0.09);

            // optionally set specific columns to hidden
            dgvData.Columns["MovieScheduleID"].Visible = false;
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                // select the parent table and join any additional fields from child entities
                string sqlMovieSchedules = @"
                        SELECT
                            ms.MovieScheduleID, 
                            ms.Price, 
                            ms.DateTime, 
                            m.Title,
                            m.Duration,
                            m.PG_Rating,
                            t.TheatreName,
                            g.GenreName,
                            t.NumRows * t.NumCols AS TotalSeats,
                            COUNT(ticket.SeatID) AS BookedSeats,
                            (t.NumRows * t.NumCols) - COUNT(ticket.SeatID) AS AvailableSeats
                        FROM
                            MovieSchedule ms
                        JOIN
                            Movie m ON ms.MovieID = m.MovieID
                        JOIN
                            Theatre t ON ms.TheatreID = t.TheatreID
                        JOIN
                            Genre g ON m.GenreID = g.GenreID
                        LEFT JOIN
                            Ticket ticket ON ms.MovieScheduleID = ticket.MovieScheduleID
                        WHERE
                            ms.DateTime >= GETDATE()
                        GROUP BY
                            ms.MovieScheduleID, 
                            ms.Price, 
                            ms.DateTime, 
                            m.Title, 
                            m.Duration, 
                            m.PG_Rating, 
                            t.TheatreName, 
                            g.GenreName, 
                            t.NumRows, 
                            t.NumCols
                        ;";
                //display only movie data that is still yet to be played

                adapter.SelectCommand = new SqlCommand(sqlMovieSchedules, conn); ;
                adapter.Fill(ds, "MovieSchedule");

                //dgvData.DataSource = ds;
                //dgvData.DataMember = "MovieSchedules";
                dgvData.DataSource = ds.Tables[tblName].DefaultView;
            }
        }

        private void LoadGenres()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                adapter = new SqlDataAdapter();

                // select the parent table and join any additional fields from child entities
                string sqlGenre = @"SELECT * FROM Genre;";

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlGenre, conn); ;
                adapter.Fill(ds, "Genre");

                cbxGenre.Items.Clear();

                foreach (DataRow row in ds.Tables["Genre"].Rows)
                {
                    int id = (int)row["GenreID"];
                    string name = row["GenreName"].ToString();
                    cbxGenre.Items.Add(new KeyValuePair<int, string>(id, name));
                }
                cbxGenre.Items.Add(new KeyValuePair<int, string>(0, "--ALL--"));

                cbxGenre.ValueMember = "Key";
                cbxGenre.DisplayMember = "Value";
                //cbxGenre.SelectedIndex = -1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];  // get the selected row

                SeatArray seatArray = new SeatArray(selectedRow);
                DialogResult result = seatArray.ShowDialog();
                if (result == DialogResult.Cancel) { return; }

                Dictionary<int, string> selectedSeats = seatArray.selectedSeats;

                BookingConfirmation bookingConfirmation = new BookingConfirmation(selectedRow, selectedSeats);
                DialogResult bookingResult = bookingConfirmation.ShowDialog();
                if (bookingResult == DialogResult.Cancel) { return; }

                string sql = @"
                        INSERT INTO 
                            Ticket (
                                MovieScheduleID,
                                SeatID,
                                Price,
                                PurchaseDateTime,
                                CustomerFirstName,
                                CustomerLastName,
                                CustomerPhoneNumber
                            )
                            VALUES
                            (
                                @MovieScheduleID,
                                @SeatID,
                                @Price,
                                @PurchaseDateTime,
                                @CustomerFirstName,
                                @CustomerLastName,
                                @CustomerPhoneNumber
                            );";
                try
                {
                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        connection.Open();

                        foreach (var item in selectedSeats)
                        {
                            SqlCommand command = new SqlCommand(sql, connection);

                            command.Parameters.AddWithValue("@MovieScheduleID", selectedRow.Cells["MovieScheduleID"].Value);
                            command.Parameters.AddWithValue("@SeatID", item.Key);
                            command.Parameters.AddWithValue("@Price", selectedRow.Cells["Price"].Value);
                            command.Parameters.AddWithValue("@PurchaseDateTime", DateTime.Now);
                            command.Parameters.AddWithValue("@CustomerFirstName", bookingConfirmation.txtFName.Text);
                            command.Parameters.AddWithValue("@CustomerLastName", bookingConfirmation.txtLName.Text);
                            command.Parameters.AddWithValue("@CustomerPhoneNumber", bookingConfirmation.txtPhoneNumber.Text);

                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    MessageBox.Show("Tickets booked Successfully", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            LoadData();
        }

        private void cbxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterText = cbxGenre.Text;
            DataTable dt = ds.Tables[tblName];

            string columnToFilter = "GenreName";

            if (string.IsNullOrEmpty(filterText) || filterText == "--ALL--")
            {
                dt.DefaultView.RowFilter = "";
            }
            else
            {
                DataColumn column = dt.Columns[columnToFilter];
                if (column != null)
                {
                    string filterCondition = string.Empty;

                    if (column.DataType == typeof(string))
                    {
                        filterCondition = $"{columnToFilter} LIKE '%{filterText}%'";
                    }

                    dt.DefaultView.RowFilter = filterCondition;
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpDate.Value.Date; // Get the selected date
            DataTable dt = ds.Tables[tblName]; // Assuming you're working with the first table in the DataSet

            // Specify the column you want to filter on
            string dateTimeColumn = "DateTime"; // Replace with your DateTime column name

            MessageBox.Show("Functionality coming soon");
            //if (dt.Columns.Contains(dateTimeColumn))
            //{
            //    // Filter based on the selected date
            //    string filterCondition = $"{dateTimeColumn} LIKE '{selectedDate.ToString("yyyy-MM-dd")}%'";
            //    dt.DefaultView.RowFilter = filterCondition;
            //}
        }
    }
}

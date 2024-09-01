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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MovieTopia
{
    public partial class HomeStaff : Form
    {
        private string DATABASE_URL;
        private int padding = 50;
        DataSet ds;
        SqlDataAdapter adapter;
        private int inc = 0;
        private int genre = 0;
        private string date = "";
        public HomeStaff()
        {
            // get database connection string
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();
            this.Resize += HomeStaff_Resize;

            // load initial data when form loads
            LoadData(genre, date);
            LoadGenre();
            dtpDate.MinDate = DateTime.Now;
        }

        private void HomeStaff_Resize(object sender, EventArgs e)
        {
            AdjustDataGridViewSize();
            AdjustColumnWidths();

            int button = this.ClientSize.Width / 2;
            btnSelectMovie.Top = this.ClientSize.Height - btnSelectMovie.Height - padding;
            btnSelectMovie.Left = (button) - btnSelectMovie.Width - padding;
            btnCancel.Top = this.ClientSize.Height - btnCancel.Height - padding;
            btnCancel.Left = (button) + padding;

            if ((gbxFiltering.Width / 3) < 500)
                btnFilters.Left = 500;
            else
                btnFilters.Left = 0 + (gbxFiltering.Width / 3);
            btnFilters.Top = 0 + ((gbxFiltering.Height / 2) - (btnFilters.Height / 2));
            btnFilters.BringToFront();
        }

        private void AdjustDataGridViewSize()
        {
            dgvSchedules.Width = this.ClientSize.Width - (2 * padding);
            dgvSchedules.Height = this.ClientSize.Height - pnlTop.Height - gbxFiltering.Height - btnCancel.Height - (padding*4);
            gbxFiltering.Width = this.ClientSize.Width - (2 * padding);
            gbxFiltering.Location = new Point(padding, (0 + pnlTop.Height + padding));
            dgvSchedules.Location = new Point(padding, 0 + pnlTop.Height + (2*padding) + gbxFiltering.Height);
            picLogo.Height = pnlTop.Height;
        }

        private void AdjustColumnWidths()
        {
            if (dgvSchedules.Columns.Count == 0)
                return;

            dgvSchedules.Columns["Code"].HeaderText = "Number";
            dgvSchedules.Columns["MovieTitle"].HeaderText = "Movie Title";
            dgvSchedules.Columns["Price"].HeaderText = "Ticket Price";
            dgvSchedules.Columns["MovieDate"].HeaderText = "Viewing Date";
            dgvSchedules.Columns["MovieTime"].HeaderText = "Viewing Time";
            dgvSchedules.Columns["Duration"].HeaderText = "Movie Duration";
            dgvSchedules.Columns["PG_Rating"].HeaderText = "PG Rating";
            dgvSchedules.Columns["GenreName"].HeaderText = "Movie Genre";
            dgvSchedules.Columns["TotalSeats"].HeaderText = "Total Seats";
            dgvSchedules.Columns["BookedSeats"].HeaderText = "Booked Seats";

            dgvSchedules.Columns["MovieTitle"].Width = (int)(dgvSchedules.Width * 0.12);
            dgvSchedules.Columns["Theatre"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["Price"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["MovieDate"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["MovieTime"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["Duration"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["PG_Rating"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["GenreName"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["TotalSeats"].Width = (int)(dgvSchedules.Width * 0.075);
            dgvSchedules.Columns["BookedSeats"].Width = (int)(dgvSchedules.Width * 0.075);

            // optionally set specific columns to hidden
            dgvSchedules.Columns["Code"].Visible = false;
        }

        private void dgvSchedules_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvSchedules.Columns[e.ColumnIndex].Name == "Duration")
            {
                if (e.Value != null)
                {
                    int hours = 0;
                    if (int.TryParse(e.Value.ToString(), out int value))
                    {
                        for (int i = (int)e.Value; i >= 60; i -= 60)
                        {
                            ++hours;
                        }
                        e.Value = hours.ToString() + " Hours, " + ((int)e.Value - hours * 60).ToString() + " min";
                    }
                    
                }
            }
            if (dgvSchedules.Columns[e.ColumnIndex].Name == "Price")
            {
                if (e.Value != null)
                {
                    if (Double.TryParse(e.Value.ToString(), out double value))
                        e.Value = "R " + value.ToString("f2");
                }
            }
        }

        private void LoadData(int GenreID, string dateFilter)
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                // Base SQL query for MovieSchedule with an optional GenreID filter and DateTime filter
                string sqlMovieSchedules = @"
                SELECT
                    ms.MovieScheduleID AS Code,
                    m.Title AS MovieTitle,
                    t.TheatreName AS Theatre,
                    ms.Price, 
                    CONVERT(VARCHAR(10), ms.DateTime, 101) AS MovieDate,  -- MM/DD/YYYY format for the date
                    FORMAT(ms.DateTime, 'hh:mm tt') AS MovieTime,         -- HH:MM AM/PM format for the time
                    m.Duration, 
                    m.PG_Rating, 
                    g.GenreName,
                    t.NumRows * t.NumCols AS TotalSeats, -- Total number of seats in the theatre
                    COUNT(ticket.SeatID) AS BookedSeats  -- Number of seats already booked
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
                    ms.DateTime > GETDATE() AND
                    (@GenreID = 0 OR m.GenreID = @GenreID) AND
                    (@DateFilter IS NULL OR CAST(ms.DateTime AS DATE) = CAST(@DateFilter AS DATE))
                GROUP BY
                    ms.MovieScheduleID, 
                    m.Title,
                    t.TheatreName,
                    ms.Price, 
                    ms.DateTime, 
                    m.Duration, 
                    m.PG_Rating, 
                    g.GenreName, 
                    t.NumRows, 
                    t.NumCols
                HAVING
                    COUNT(ticket.SeatID) < (t.NumRows * t.NumCols)";

                string sqlMovies = "SELECT * FROM Movie";
                string sqlTheatres = "SELECT * FROM Theatre WHERE Active = 1;";

                adapter.SelectCommand = new SqlCommand(sqlMovieSchedules, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@GenreID", GenreID);

                if (string.IsNullOrWhiteSpace(dateFilter))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@DateFilter", DBNull.Value);
                }
                else
                {
                    // Convert string to DateTime for the SQL query
                    DateTime parsedDate;
                    if (DateTime.TryParse(dateFilter, out parsedDate))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@DateFilter", parsedDate);
                    }
                    else
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@DateFilter", DBNull.Value);
                    }
                }

                adapter.Fill(ds, "MovieSchedule");

                adapter.SelectCommand = new SqlCommand(sqlMovies, conn);
                adapter.Fill(ds, "Movie");

                adapter.SelectCommand = new SqlCommand(sqlTheatres, conn);
                adapter.Fill(ds, "Theatre");

                // fill the datagrid
                dgvSchedules.DataSource = ds;
                dgvSchedules.DataMember = "MovieSchedule";
                dgvSchedules.CellFormatting += dgvSchedules_CellFormatting;

                if (dgvSchedules.Rows.Count > 0)
                {
                    return;
                }
                else if (GenreID == 0 && dateFilter == "")
                {
                    MessageBox.Show("There are currently no movies scheduled for viewing");
                }
                else if (GenreID != 0 && dateFilter != "")
                {
                    int spaceIndex = cbxGenre.SelectedItem.ToString().IndexOf(' ');
                    MessageBox.Show("There are currently no movies scheduled for...\n Genre: " + cbxGenre.SelectedItem.ToString().Substring(spaceIndex + 1) + "\nand Date: " + dateFilter);
                }
                else if (dateFilter != "")
                {
                    MessageBox.Show("There are no movies currently scheduled on: " + dateFilter);
                }
                else
                {
                    int spaceIndex = cbxGenre.SelectedItem.ToString().IndexOf(' ');
                    MessageBox.Show("There are no movies currently scheduled for genre: " + cbxGenre.SelectedItem.ToString().Substring(spaceIndex + 1));
                }
            }
        }


        private void LoadGenre()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                // select the parent table and join any additional fields from child entities
                string sqlGenre = @"
                        SELECT
                            g.GenreID,
                            g.GenreName
                        FROM
                            Genre g
                        JOIN
                            Movie m ON g.GenreID = m.GenreID
                        JOIN
                            MovieSchedule ms ON ms.MovieID = m.MovieID
                        WHERE
                            ms.DateTime > GETDATE()
                        GROUP BY
                            g.GenreID,
                            g.GenreName";

                // NB: select the ENTIRE child entity and store it in the dataset as well. This is used in the DetailsForm for dropdown boxes
                string sqlMovies = "SELECT * FROM Movie";
                string sqlMovieSchedule = "SELECT * FROM MovieSchedule";

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlGenre, conn); ;
                adapter.Fill(ds, "Genre");
                adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                adapter.Fill(ds, "Movie");
                adapter.SelectCommand = new SqlCommand(sqlMovieSchedule, conn); ;
                adapter.Fill(ds, "MovieSchedule");

                cbxGenre.Items.Clear();

                // Loop through the Genre DataTable and add each genre to the ComboBox
                foreach (DataRow row in ds.Tables["Genre"].Rows)
                {
                    string genreItem = row["GenreID"].ToString() + " " + row["GenreName"].ToString();
                    cbxGenre.Items.Add(genreItem);
                }

            }
        }

        private void HomeStaff_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Show a message box with Yes and No buttons
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the ticket?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check which button was clicked
            if (result == DialogResult.Yes)
            {
                // Close the form if No was clicked
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                // Exit the method if Yes was clicked
                return;
            }
        }

        private void btnSelectMovie_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSchedules.SelectedRows[0];  // get the selected row

                int movieScheduleID = Convert.ToInt32(selectedRow.Cells["Code"].Value);

                Avalible_seats SeatForm = new Avalible_seats(movieScheduleID);
                this.Hide();
                SeatForm.ShowDialog();
                this.Close();
            } else
            {
                MessageBox.Show("Please select a movie in the table first!");
            }
        }

        private void cbxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGenre.SelectedIndex < 0)
            {
                //MessageBox.Show("Please select a genre to filter by!");
                return;
            }
            else
            {
                // Parse the selected item to get the GenreID
                string selectedGenre = cbxGenre.SelectedItem.ToString();
                string[] genreParts = selectedGenre.Split(' '); // Assuming format is "GenreID-SPACE-GenreName"
                int selectedGenreID;

                // Attempt to parse the GenreID
                if (int.TryParse(genreParts[0], out selectedGenreID))
                {
                    // Call LoadData with the parsed GenreID
                    genre = selectedGenreID;
                    LoadData(genre, date);
                }
                else
                {
                    MessageBox.Show("Failed to parse GenreID. Please ensure the genre is selected correctly.");
                }
            }

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (inc == 0)
            {
                ++inc;
                return;
            } else
            {
                DateTime selectedDate = dtpDate.Value;

                string formattedDate = selectedDate.ToString("MM/dd/yyyy");

                string savedDate = formattedDate;
                date = savedDate;

                LoadData(genre, date);
            }
        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            genre = 0;
            date = "";
            cbxGenre.SelectedIndex = -1;
            LoadData(genre, date);
        }
    }
}

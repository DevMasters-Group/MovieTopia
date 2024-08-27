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

namespace MovieTopia
{
    public partial class HomeStaff : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        DataSet ds;
        SqlDataAdapter adapter;
        public HomeStaff()
        {
            // get database connection string
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();

            // load initial data when form loads
            LoadData();
            LoadGenre();
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
                            ms.MovieScheduleID AS Code, 
                            ms.Price, 
                            ms.DateTime, 
                            m.Title, 
                            m.Duration, 
                            m.PG_Rating, 
                            t.TheatreName, 
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
                        --WHERE
                            --ms.DateTime > GETDATE()
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
                        HAVING
                            COUNT(ticket.SeatID) < (t.NumRows * t.NumCols)";
                //display only movie data that is still yet to be played

                // NB: select the ENTIRE child entity and store it in the dataset as well. This is used in the DetailsForm for dropdown boxes
                string sqlMovies = "SELECT * FROM Movie";
                string sqlTheatres = "SELECT * FROM Theatre WHERE Active = 1;";

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlMovieSchedules, conn); ;
                adapter.Fill(ds, "MovieSchedule");
                adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                adapter.Fill(ds, "Movie");
                adapter.SelectCommand = new SqlCommand(sqlTheatres, conn); ;
                adapter.Fill(ds, "Theatre");

                // fill the datagrid
                dgvSchedules.DataSource = ds;
                dgvSchedules.DataMember = "MovieSchedule";
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
                        --WHERE
                            --ms.DateTime > GETDATE()
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

                int movieScheduleID = Convert.ToInt32(selectedRow.Cells[0].Value);

                MessageBox.Show(movieScheduleID.ToString());

                //Seats SeatForm = new Seats(int movieScheduleID);
                //this.Hide();
                //homeAdmin.ShowDialog();
                //this.Close();
            }
        }

        private void cbxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxGenre.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a genre to filter by!");
                return;
            } else
            {
                // Parse the selected item to get the GenreID
                string selectedGenre = cbxGenre.SelectedItem.ToString();
                string[] genreParts = selectedGenre.Split(' '); // Assuming the format is "GenreID GenreName"
                string selectedGenreName = genreParts[0];

                // Get the DataTable for the MovieSchedule
                DataTable movieScheduleTable = ds.Tables["Movie"];

                // List all column names for debugging
                StringBuilder sb = new StringBuilder();
                foreach (DataColumn column in movieScheduleTable.Columns)
                {
                    sb.AppendLine(column.ColumnName);
                }
                MessageBox.Show("Columns in MovieSchedule DataTable:\n" + sb.ToString());

                // Check if the GenreName column exists
                if (!movieScheduleTable.Columns.Contains("GenreID"))
                {
                    MessageBox.Show("GenreName column not found in MovieSchedule DataTable.");
                    return;
                }

                // Get the DataView for the MovieSchedule DataTable
                DataView dv = new DataView(movieScheduleTable);

                // Apply the filter based on the selected GenreID
                dv.RowFilter = $"GenreID = {selectedGenreName}";

                // Set the filtered DataView as the DataSource for the DataGridView
                dgvSchedules.DataSource = dv;
            }
        }
    }
}

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
    public partial class SellTickets : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
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

            btnSelect.Left = (this.ClientSize.Width / 2) - btnSelect.Width - padding;
            btnCancel.Left = btnSelect.Left + btnSelect.Width + padding;
            btnSelect.Top = (this.ClientSize.Height - btnSelect.Height - padding * 2);
            btnCancel.Top = (this.ClientSize.Height - btnCancel.Height - padding * 2);

            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void AdjustDataGridViewSize()
        {
            dgvAvailableMovies.Width = this.ClientSize.Width - (2 * padding);
            dgvAvailableMovies.Height = this.ClientSize.Height - (12 * padding);
            dgvAvailableMovies.Location = new Point(padding, padding * 7);
        }

        private void AdjustColumnWidths()
        {
            if (dgvAvailableMovies.Columns.Count == 0)
                return;

            //dgvGenres.Columns["GenreID"].HeaderText = "Genre ID";
            //dgvGenres.Columns["GenreName"].HeaderText = "Genre Name";

            //dgvGenres.Columns["GenreID"].Width = (int)(dgvGenres.Width * 0.2);
            //dgvGenres.Columns["GenreName"].Width = (int)(dgvGenres.Width * 0.8);

            // optionally set specific columns to hidden
            //dgvGenres.Columns["GenreID"].Visible = false;
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
                adapter.Fill(ds, "MovieSchedules");

                dgvAvailableMovies.DataSource = ds;
                dgvAvailableMovies.DataMember = "MovieSchedules";
            }
        }

        private void LoadGenres()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                // select the parent table and join any additional fields from child entities
                string sqlGenre = @"SELECT * FROM Genre;";

                // NB: select the ENTIRE child entity and store it in the dataset as well. This is used in the DetailsForm for dropdown boxes
                //string sqlMovies = "SELECT * FROM Movie";
                //string sqlMovieSchedule = "SELECT * FROM MovieSchedule";

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlGenre, conn); ;
                adapter.Fill(ds, "Genre");
                //adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                //adapter.Fill(ds, "Movie");
                //adapter.SelectCommand = new SqlCommand(sqlMovieSchedule, conn); ;
                //adapter.Fill(ds, "MovieSchedule");

                cbxGenre.Items.Clear();

                List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
                foreach (DataRow row in ds.Tables["Genre"].Rows)
                {
                    items.Add(new KeyValuePair<string, string>(row["GenreID"].ToString(), row["GenreName"].ToString()));
                }
                cbxGenre.DataSource = items;
                cbxGenre.ValueMember = "Key";
                cbxGenre.DisplayMember = "Value";

                // Loop through the Genre DataTable and add each genre to the ComboBox
                //foreach (DataRow row in ds.Tables["Genre"].Rows)
                //{
                //    string genreItem = row["GenreID"].ToString() + " " + row["GenreName"].ToString();
                //    cbxGenre.Items.Add(genreItem);
                //}
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvAvailableMovies.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvAvailableMovies.SelectedRows[0];  // get the selected row

                // This dictionary is used for mapping certain columns to their values in the child table - i.e. what column data you want to show in the drop down box
                //Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                //foreignKeySchemaNames["MovieID"] = "Title";  // this will show the Movie title in the drop down
                //foreignKeySchemaNames["TheatreID"] = "TheatreName";

                //DetailsForm detailsForm = new DetailsForm("MovieSchedule", ds, selectedRow, foreignKeySchemaNames);
                //DialogResult result = detailsForm.ShowDialog();

                SeatArray seatArray = new SeatArray(selectedRow);
                DialogResult result = seatArray.ShowDialog();

            }
        }
    }
}

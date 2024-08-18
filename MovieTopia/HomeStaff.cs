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
                                ms.MovieScheduleID, ms.MovieID, ms.TheatreID, ms.Price, ms.DateTime, m.Title, m.Duration, m.PG_Rating, t.TheatreName, g.GenreName
                            FROM
                                MovieSchedule ms
                            JOIN
                                Movie m ON ms.MovieID = m.MovieID
                            JOIN
                                Theatre t ON ms.TheatreID = t.TheatreID
                            JOIN
                                Genre g ON m.GenreID = g.GenreID";
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

        private void HomeStaff_Load(object sender, EventArgs e)
        {
            
        }
    }
}

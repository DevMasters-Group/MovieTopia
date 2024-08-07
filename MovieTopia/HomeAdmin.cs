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
    public partial class HomeAdmin : Form
    {
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void btnMMovies_Click(object sender, EventArgs e)
        {
            MaintainMovies movieForm = new MaintainMovies();
            this.Hide();
            movieForm.ShowDialog();
            this.Close();
        }

        private void btnSMTimes_Click(object sender, EventArgs e)
        {
            ScheduleMovies scheduleMoviesForm = new ScheduleMovies();
            this.Hide();
            scheduleMoviesForm.ShowDialog();
            this.Close();
        }

        private void btnMTheatres_Click(object sender, EventArgs e)
        {

        }

        private void btnMGenres_Click(object sender, EventArgs e)
        {

        }

        private void btnMSeats_Click(object sender, EventArgs e)
        {

        }

        private void btnMTickets_Click(object sender, EventArgs e)
        {

        }

        private void btnSTickets_Click(object sender, EventArgs e)
        {

        }

        private void btnRReports_Click(object sender, EventArgs e)
        {

        }
    }
}

﻿/// Jaden Straw - 41397673
/// Eugene Holt - 45613192
/// John-Ernest Chamberlain - 45669392
/// Liam Craven - 45995958


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

            this.Resize += Form_Resize;

            btnMMovies.BackColor = HexToColor("#36455D");
            btnMTheatres.BackColor = HexToColor("#4B5C9C");
            btnMGenres.BackColor = HexToColor("#6A80ED");
            btnMSeats.BackColor = HexToColor("#419DF4");
            btnMTickets.BackColor = HexToColor("#2C9ACF");
            btnSMTimes.BackColor = HexToColor("#5A79B6");
            btnSTickets.BackColor = HexToColor("#8660A8");
            btnRReports.BackColor = HexToColor("#B54A99");
            btnReturnHome.BackColor = HexToColor("#36455D");
        }

        public Color HexToColor(string hex)
        {
            return ColorTranslator.FromHtml(hex);
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            btnReturnHome.Left = this.ClientSize.Width - btnReturnHome.Width - btnMMovies.Left;
            btnReturnHome.Top = btnMMovies.Top;
        }

        /// <summary>
        /// Overrides the OnPaint method to draw the background image centered and scaled.
        /// </summary>
        /// <param name="e">The PaintEventArgs instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Image backgroundImage = BackgroundImage;

            if (backgroundImage != null)
            {
                // Calculate the scaling factor
                float widthRatio = (float)this.ClientSize.Width / backgroundImage.Width;
                float heightRatio = (float)this.ClientSize.Height / backgroundImage.Height;
                float scalingFactor = Math.Max(widthRatio, heightRatio);

                // Calculate the destination rectangle
                int scaledWidth = (int)(backgroundImage.Width * scalingFactor);
                int scaledHeight = (int)(backgroundImage.Height * scalingFactor);
                int x = (this.ClientSize.Width - scaledWidth) / 2;
                int y = (this.ClientSize.Height - scaledHeight) / 2;
                Rectangle destRect = new Rectangle(x, y, scaledWidth, scaledHeight);

                // Draw the image
                e.Graphics.DrawImage(backgroundImage, destRect);
            }
        }

        private void btnMMovies_Click(object sender, EventArgs e)
        {
            MaintainMovies movieForm = new MaintainMovies();
            this.Hide();
            movieForm.ShowDialog();
            this.Show();
        }

        private void btnSMTimes_Click(object sender, EventArgs e)
        {
            ScheduleMovies scheduleMoviesForm = new ScheduleMovies();
            this.Hide();
            scheduleMoviesForm.ShowDialog();
            this.Show();
            //this.Close();
        }

        private void btnMTheatres_Click(object sender, EventArgs e)
        {
            MaintainTheatres maintainTheatresForm = new MaintainTheatres();
            this.Hide();
            maintainTheatresForm.ShowDialog();
            this.Show();
        }

        private void btnMGenres_Click(object sender, EventArgs e)
        {
            MaintainGenres maintainGenresForm = new MaintainGenres();
            this.Hide();
            maintainGenresForm.ShowDialog();
            this.Show();
        }

        private void btnMSeats_Click(object sender, EventArgs e)
        {
            MaintainSeats maintainSeatsForm = new MaintainSeats();
            this.Hide();
            maintainSeatsForm.ShowDialog();
            this.Show();
        }

        private void btnMTickets_Click(object sender, EventArgs e)
        {
            MaintainTickets maintainTickets = new MaintainTickets();
            this.Hide();
            maintainTickets.ShowDialog();
            this.Show();
        }

        private void btnSTickets_Click(object sender, EventArgs e)
        {
            SellTickets sellTickets = new SellTickets();
            this.Hide();
            sellTickets.ShowDialog();
            this.Show();
            //HomeStaff homeStaff = new HomeStaff();
            //this.Hide();
            //homeStaff.ShowDialog();
            //this.Show();
        }

        private void btnRReports_Click(object sender, EventArgs e)
        {
            RequestReports requestReports = new RequestReports();
            this.Hide();
            requestReports.ShowDialog();
            this.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

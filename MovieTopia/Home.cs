using System;
using System.Collections;
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
    public partial class Home : Form
    {
        private int padding = 10;

        public Home()
        {
            InitializeComponent();

            this.Resize += Form_Resize;
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            btnCStaff.Left = (this.ClientSize.Width - btnCStaff.Width) / 2;
            btnCAdmin.Left = (this.ClientSize.Width - btnCAdmin.Width) / 2;
            btnCStaff.Top = (this.ClientSize.Height / 4) * 3 - btnCStaff.Height - padding / 2;
            btnCAdmin.Top = (this.ClientSize.Height / 4) * 3 + padding / 2;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            string DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            using (SqlConnection connection = new SqlConnection(DATABASE_URL))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Error: {ex.Message}");
                    MessageBox.Show("Error: The program was unable to connect to the database.\r\nPlease ensure that Microsoft SQL Server is installed and that the service is running.");
                    this.Close();
                }
            }
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

        private void btnCStaff_Click(object sender, EventArgs e)
        {
            //HomeStaff homeStaff = new HomeStaff();
            //this.Hide();
            //homeStaff.ShowDialog();
            //this.Show();
            SellTickets sellTickets = new SellTickets();
            this.Hide();
            sellTickets.ShowDialog();
            this.Show();
        }

        private void btnCAdmin_Click(object sender, EventArgs e)
        {
            HomeAdmin homeAdmin = new HomeAdmin();
            this.Hide();
            homeAdmin.ShowDialog();
            this.Show();
            
        }
    }
}

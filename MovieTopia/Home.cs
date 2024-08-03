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
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            string DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            using (SqlConnection connection = new SqlConnection(DATABASE_URL))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    btnCStaff.Enabled = false;
                    btnCAdmin.Enabled = false;
                }
            }
        }

        private void btnCStaff_Click(object sender, EventArgs e)
        {
            HomeStaff homeStaff = new HomeStaff();
            this.Hide();
            homeStaff.ShowDialog();
            this.Close();
        }

        private void btnCAdmin_Click(object sender, EventArgs e)
        {
            HomeAdmin homeAdmin = new HomeAdmin();
            this.Hide();
            homeAdmin.ShowDialog();
            this.Close();
            
        }
    }
}

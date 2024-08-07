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

            this.Resize += _Resize;
        }

        private void _Resize(Object sender, EventArgs e)
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

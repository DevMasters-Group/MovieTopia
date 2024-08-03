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
    public partial class MMovies : Form
    {
        string DATABASE_URL;
        //SqlConnection conn;
        //DataSet ds;
        //SqlDataAdapter adapter;
        //SqlCommand cmd;

        public MMovies()
        {
            InitializeComponent();

            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
        }

        private void MMovies_Load(object sender, EventArgs e)
        {
            //conn = new SqlConnection(DATABASE_URL);
            //ds = new DataSet();
            //adapter = new SqlDataAdapter();

            //string sqlCmd = "SELECT * FROM Movies";
            //cmd = new SqlCommand(sqlCmd, conn);

            //adapter.SelectCommand = cmd;
            //adapter.Fill(ds, "Movies");

            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "Movies";

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
                }
            }
        }
    }
}

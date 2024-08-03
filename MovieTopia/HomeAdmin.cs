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
            MMovies mMovies = new MMovies();
            this.Hide();
            mMovies.ShowDialog();
            this.Show();
        }
    }
}

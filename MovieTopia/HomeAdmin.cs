using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class HomeAdmin : Form
    {
        string DATABASE_URL;
        public HomeAdmin()
        {
            InitializeComponent();

            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            label1.Text = DATABASE_URL;
        }
    }
}

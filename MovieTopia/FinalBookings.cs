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
    public partial class FinalBookings : Form
    {
        public FinalBookings(List<string> selectedSeats, int movieScheduleID)
        {
            InitializeComponent();

            string selectedSeatsMessage = string.Join(", ", selectedSeats.ToArray());
            MessageBox.Show(selectedSeatsMessage);
        }

        private void FinalBookings_Load(object sender, EventArgs e)
        {

        }
    }
}

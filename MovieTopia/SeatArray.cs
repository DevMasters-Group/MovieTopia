using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class SeatArray : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        private DataGridViewRow selectedDGVR;
        public List<int> selectedSeatIDs = new List<int>();
        public Dictionary<int, string> selectedSeats = new Dictionary<int, string>();
        DataSet ds;
        SqlDataAdapter adapter;

        public SeatArray(DataGridViewRow selectedDGVR)
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            this.selectedDGVR = selectedDGVR;

            InitializeComponent();

            Alignment();
            LoadData();
            PopulateArray();
        }

        private void Alignment()
        {
            // position controls
            pnlScreen.Left = this.ClientSize.Width / 2 - pnlScreen.Width / 2;
            lblScreen.Left = (pnlScreen.Width - lblScreen.Width) / 2;
            lblScreen.Top = (pnlScreen.Height - lblScreen.Height) / 2;
            pnlLegend.Left = this.ClientSize.Width / 2 - pnlLegend.Width / 2;
            pnlLegend.Top = this.ClientSize.Height - 2 * padding - pnlLegend.Height;

            btnCancel.Top = pnlLegend.Top;
            btnContinue.Top = pnlLegend.Top;
            btnCancel.Left = this.ClientSize.Width - btnCancel.Width - padding;
            btnContinue.Left = btnCancel.Left - padding / 2 - btnContinue.Width;
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                int movieScheduleID = int.Parse(selectedDGVR.Cells["MovieScheduleID"].Value.ToString());

                // select the parent table and join any additional fields from child entities
                string sqlSeats = $@"
                    WITH TheatreSeats AS (
                        SELECT 
                            t.TheatreID,
                            t.NumRows,
                            t.NumCols,
                            s.SeatID,
                            s.SeatRow,
                            s.SeatColumn
                        FROM 
                            Theatre t
                        CROSS JOIN 
                            Seat s
                        WHERE 
                            t.TheatreID = (SELECT TheatreID FROM MovieSchedule WHERE MovieScheduleID = {movieScheduleID})
                            AND s.SeatRow <= t.NumRows 
                            AND s.SeatColumn <= CHAR(64 + t.NumCols)
                    ),
                    BookedSeats AS (
                        SELECT 
                            ts.TheatreID,
                            ts.SeatID,
                            ts.SeatRow,
                            ts.SeatColumn,
                            CASE 
                                WHEN tk.TicketID IS NOT NULL THEN 1 -- Booked
                                ELSE 0 -- Not Booked
                            END AS IsBooked
                        FROM 
                            TheatreSeats ts
                        LEFT JOIN 
                            Ticket tk ON ts.SeatID = tk.SeatID AND tk.MovieScheduleID = {movieScheduleID}
                    )
                    SELECT
                        SeatID,
                        SeatRow,
                        SeatColumn,
                        IsBooked
                    FROM 
                        BookedSeats
                    ORDER BY 
                        SeatRow, SeatColumn;";

                adapter.SelectCommand = new SqlCommand(sqlSeats, conn); ;
                adapter.Fill(ds, "Seats");
            }
        }

        private void PopulateArray()
        {
            int pictureBoxWidth = 40; // Size of each PictureBox
            int pictureBoxHeight = 25; // Size of each PictureBox
            int margin = 5; // Space between PictureBoxes
            int startX = pnlScreen.Left;
            int startY = pnlScreen.Bottom + padding; // Starting position for the first PictureBox

            // Temporary variables to calculate total size of seat array
            int totalWidth = 0;
            int totalHeight = 0;

            // Determine the maximum number of rows and columns
            int maxRow = ds.Tables["Seats"].AsEnumerable().Max(row => row.Field<int>("SeatRow"));
            int maxCol = ds.Tables["Seats"].AsEnumerable().Max(row => Convert.ToChar(row.Field<string>("SeatColumn")) - 'A' + 1);

            totalWidth = (maxCol * pictureBoxWidth) + ((maxCol - 1) * margin);
            totalHeight = (maxRow * pictureBoxHeight) + ((maxRow - 1) * margin);

            startX = pnlScreen.Left + pnlScreen.Width / 2 - totalWidth / 2;
            startY = pnlScreen.Bottom + padding; // Leave space for the legend

            foreach (DataRow row in ds.Tables["Seats"].Rows)
            {
                int seatRow = Convert.ToInt32(row["SeatRow"]);
                string seatColumn = row["SeatColumn"].ToString();
                bool isBooked = Convert.ToBoolean(row["IsBooked"]);

                // Create a new PictureBox
                PictureBox pb = new PictureBox
                {
                    Width = pictureBoxWidth,
                    Height = pictureBoxHeight,
                    BackColor = isBooked ? Color.Gray : Color.LightGray, // Dark grey if booked, light grey if available
                    Location = new Point(startX + (seatColumn[0] - 'A') * (pictureBoxWidth + margin),
                                 startY + (seatRow - 1) * (pictureBoxHeight + margin)),
                    Tag = new { SeatID = row["SeatID"], SeatRow = seatRow, SeatColumn = seatColumn, IsBooked = isBooked }
                };

                // Add a click event handler to select/deselect seats
                pb.Click += Seat_Click;

                // Create a Label to display the seat information (e.g., "A1")
                Label seatLabel = new Label
                {
                    Text = $"{seatColumn}{seatRow}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent, // Transparent background to show the PictureBox color
                    ForeColor = Color.Black
                };

                seatLabel.Click += (s, e) => Seat_Click(pb, e);

                // Add the Label to the PictureBox
                pb.Controls.Add(seatLabel);

                // Add the PictureBox to the form or a container (e.g., Panel)
                this.Controls.Add(pb);
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            var seatInfo = (dynamic)pb.Tag;
            int seatID = seatInfo.SeatID;

            if (!seatInfo.IsBooked) // Only allow selection if the seat is not booked
            {
                bool selected = pb.BackColor == Color.LightGray;
                pb.BackColor = selected ? Color.DeepSkyBlue : Color.LightGray; // Toggle selection
                if (selected)
                {
                    selectedSeatIDs.Add(seatID);
                    selectedSeats[seatID] = seatInfo.SeatColumn + "" + seatInfo.SeatRow;
                    btnContinue.Enabled = true;
                }
                else
                {
                    selectedSeatIDs.Remove(seatID);
                    selectedSeats.Remove(seatID);
                    if (selectedSeats.Count == 0) btnContinue.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("This seat is already booked.");
            }
        }

        //private List<int> GetSelectedSeatIDs()
        //{
        //    List<int> selectedSeatIDs = new List<int>();

        //    foreach (Control control in this.Controls)
        //    {
        //        if (control is PictureBox pb && pb.BackColor == Color.FromArgb(0, 191, 255)) // Check for selected color
        //        {
        //            var seatInfo = (dynamic)pb.Tag;
        //            selectedSeatIDs.Add(seatInfo.SeatID);
        //        }
        //    }

        //    return selectedSeatIDs;
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel your booking?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

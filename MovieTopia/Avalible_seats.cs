using MovieTopia.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class Avalible_seats : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        DataSet ds;
        SqlDataAdapter adapter;
        SqlDataReader reader;

        private int ScheduleID = 2;

        public Avalible_seats(int scheduleID)
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            
            InitializeComponent();
            ScheduleID = scheduleID;
            loadSeats(scheduleID);
            pnlSeats.AutoScroll = true;

        }

        private void loadSeats(int ScheduleId)
        {
            int rows = 0;
            int columns = 0;

            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();
                adapter = new SqlDataAdapter();
                ds = new DataSet();

                // Retrieve the TheatreID from the MovieSchedule table using the ScheduleId
                string sqlMovieSchedule = @"
                SELECT
                    TheatreID
                FROM
                    MovieSchedule
                WHERE
                    MovieScheduleID = @MovieScheduleID";
                adapter.SelectCommand = new SqlCommand(sqlMovieSchedule, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MovieScheduleID", ScheduleId);
                adapter.Fill(ds, "MovieSchedule");

                int theatreID = Convert.ToInt32(ds.Tables["MovieSchedule"].Rows[0]["TheatreID"]);

                // Retrieve theatre details using the TheatreID
                string sqlTheatre = @"
                SELECT
                    NumRows, NumCols, TheatreName, Active
                FROM
                    Theatre
                WHERE
                    TheatreID = @TheatreID";
                adapter.SelectCommand = new SqlCommand(sqlTheatre, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@TheatreID", theatreID);
                adapter.Fill(ds, "Theatre");

                // Values to use in the loop to display seats
                rows = Convert.ToInt32(ds.Tables["Theatre"].Rows[0]["NumRows"]);
                columns = Convert.ToInt32(ds.Tables["Theatre"].Rows[0]["NumCols"]);

                // Display seats, labels, and stage
                DisplaySeats(rows, columns);

                // Retrieve occupied seats and mark them
                MarkOccupiedSeats(conn, rows, columns);
            }
        }

        private void DisplaySeats(int rows, int columns)
        {
            int seatWidth = 30;
            int seatHeight = 30;
            int horizontalSpacing = 10; // Space between seat columns
            int verticalSpacing = 10; // Space between seat rows

            // Calculate left and top padding
            int totalWidth = columns * seatWidth + (columns - 1) * horizontalSpacing;
            int leftPadding = (this.ClientSize.Width - totalWidth) / 2;
            //int topPadding = (this.ClientSize.Height - (rows * seatHeight + (rows - 1) * verticalSpacing) - lblStage.Height - padding * 4 - lblTheater_num.Height) / 2;

            // Center the theater number label
            lblTheater_num.Left = (this.ClientSize.Width - lblTheater_num.Width) / 2;
            



            pnlSeats.Controls.Clear();
            // Add seats and row number labels
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if(column >= 24)
                    {
                        // Add seat labels by using controll properties
                        LBL colLabel = new LBL
                        {
                            Text = ((char)('A' + column)).ToString() + ((char)('A' + column)).ToString(),
                            Width = seatWidth,
                            Height = seatHeight,
                            Location = new Point(leftPadding + column * (seatWidth + horizontalSpacing), lblTheater_num.Bottom + 10),
                        };
                        this.Controls.Add(colLabel);
                        pnlSeats.Controls.Add(colLabel);
                        // Add seat picture boxes by using controll properties
                        PBX seat = new PBX
                        {
                            Name = ((row + 1).ToString() + (char)('A' + column)).ToString() + ((char)('A' + column)).ToString(),
                            Width = seatWidth,
                            Height = seatHeight,
                            Location = new Point(leftPadding + column * (seatWidth + horizontalSpacing), lblTheater_num.Bottom + 40 + row * (seatHeight + verticalSpacing)),
                            Image = Properties.Resources.Seat_Icon_Main1, // Default to available seat
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.Purple,
                        };
                        // Add event handler for seat click so that when clicked on it will triger the click event
                        seat.Click += new EventHandler(PBX_Click);
                        this.Controls.Add(seat);
                        pnlSeats.Controls.Add(seat);
                    }
                    else
                    {
                        // Add seat labels by using controll properties
                        LBL colLabel = new LBL
                        {
                            Text = ((char)('A' + column)).ToString(),
                            Width = seatWidth,
                            Height = seatHeight,
                            Location = new Point(leftPadding + column * (seatWidth + horizontalSpacing), lblTheater_num.Bottom + 10),
                        };
                        this.Controls.Add(colLabel);
                        pnlSeats.Controls.Add(colLabel);

                        // Add seat picture boxes by using controll properties
                        PBX seat = new PBX
                        {
                            Name = ((row + 1).ToString() + (char)('A' + column)).ToString(),
                            Width = seatWidth,
                            Height = seatHeight,
                            Location = new Point(leftPadding + column * (seatWidth + horizontalSpacing), lblTheater_num.Bottom + 40 + row * (seatHeight + verticalSpacing)),
                            Image = Properties.Resources.Seat_Icon_Main1, // Default to available seat
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.Purple,
                        };
                        // Add event handler for seat click so that when clicked on it will triger the click event
                        seat.Click += new EventHandler(PBX_Click);
                        this.Controls.Add(seat);
                        pnlSeats.Controls.Add(seat);
                    }
                }
                // Add row number labels
                LBL rowLabel = new LBL
                {
                    Text = (row + 1).ToString(),
                    Width = seatWidth,
                    Height = seatHeight,
                    Location = new Point(leftPadding - seatWidth - 10, lblTheater_num.Bottom + 40 + row * (seatHeight + verticalSpacing)),
                };
                this.Controls.Add(rowLabel);
                pnlSeats.Controls.Add(rowLabel);
            }

            // Position the stage label
            lblStage.Left = (this.ClientSize.Width - lblStage.Width) / 2;
            lblStage.Top = this.ClientSize.Height / 2 + this.ClientSize.Height / 4 + this.ClientSize.Height / 10  + lblTheater_num.Top - btnSelect.Height;

            // Position the panels
            pnlSeats.Top = lblTheater_num.Top + lblTheater_num.Height + padding / 2;
            pnlSeats.Left = padding;
            //pnlSeats.Height = this.ClientSize.Height - this.ClientSize.Height/4 - 2 * padding - lblStage.Height - btnSelect.Height;
            pnlSeats.Height = lblStage.Top - 4 * padding; ;
            pnlSeats.Width = this.ClientSize.Width - 2 * padding - gbxGuide.Width;

            

            // Position buttons under the stage label
            int totalBWidth = btnSelect.Width + btnReChoose.Width + padding;

            //btnSelect.Top = this.ClientSize.Height / 2 + this.ClientSize.Height / 3 + lblTheater_num.Top + padding;
            btnSelect.Top =  lblStage.Top+padding;
            btnReChoose.Top = btnSelect.Top;

            //btnSelect.Left = (this.ClientSize.Width - totalWidth) / 2;
            btnReChoose.Left = (this.ClientSize.Width - totalWidth) / 2 - 2 * padding;
            btnSelect.Left = btnReChoose.Right + padding;
            //btnReChoose.Left = btnSelect.Right + padding;

        }

        private void MarkOccupiedSeats(SqlConnection conn, int rows, int columns)
        {
            
            string sqlSeats = @"
            SELECT
                t.SeatID, 
                s.SeatRow, 
                s.SeatColumn
            FROM
                MovieSchedule ms
            JOIN
                Ticket t ON t.MovieScheduleID = ms.MovieScheduleID
            JOIN
                Seat s ON s.SeatID = t.SeatID
            WHERE
                ms.MovieScheduleID = @MovieScheduleID";
            SqlCommand command = new SqlCommand(sqlSeats, conn);
            //
            //logic to get the movie schedule id
            //
            int movieScheduleID = ScheduleID;
            command.Parameters.AddWithValue("@MovieScheduleID", movieScheduleID);

            SqlDataReader reader = command.ExecuteReader();
            HashSet<string> occupiedSeats = new HashSet<string>();

            // Add occupied seats to a hash set, buy uploading the the information from the table of the lows and columns 
            while (reader.Read())
            {
                string seatPosition = reader["SeatRow"].ToString() + reader["SeatColumn"].ToString();

                occupiedSeats.Add(seatPosition);
            }

            reader.Close();

            // Update seat images based on occupancy
            foreach (Control control in this.Controls)
            {

                if (control is PBX seat)
                {
                    if (occupiedSeats.Contains(seat.Name))
                    {
                        //MessageBox.Show(seat.Name);
                        seat.Image = Properties.Resources.logoIconLight; // Seat is taken
                        seat.BackColor = Color.Red;

                    }
                }
            }        
        }

        //Click event where we check if the seat is taken or not and change the Backcolor of the seat. Long with the imagige to show that it is selceted
        private void PBX_Click(object sender, EventArgs e)
        {
            //
            //I know it is scuffed but it works
            //
            PBX seat = sender as PBX;
            // Check the current image and switch to the next state
            if (seat.BackColor == Color.Purple)
            {
                seat.Image = Properties.Resources.logoIconDark;
                seat.BackColor = Color.Black;
                //MessageBox.Show(seat.Name);
            }
            else if (seat.BackColor == Color.Black)
            {
                seat.Image = Properties.Resources.Seat_Icon_Main1;
                seat.BackColor = Color.Purple;
            }
            else
            {
                seat.Image = Properties.Resources.logoIconLight;
                seat.BackColor = Color.Red;
            }
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();

                // Retrieve occupied seats for the current movie schedule
                string sqlOccupiedSeats = @"
            SELECT
                t.SeatID, 
                s.SeatRow, 
                s.SeatColumn
            FROM
                MovieSchedule ms
            JOIN
                Ticket t ON t.MovieScheduleID = ms.MovieScheduleID
            JOIN
                Seat s ON s.SeatID = t.SeatID
            WHERE
                ms.MovieScheduleID = @MovieScheduleID";

                SqlCommand command = new SqlCommand(sqlOccupiedSeats, conn);

                // Logic to get the movie schedule ID
                int movieScheduleID = ScheduleID;
                command.Parameters.AddWithValue("@MovieScheduleID", movieScheduleID);

                SqlDataReader reader = command.ExecuteReader();
                HashSet<string> occupiedSeats = new HashSet<string>();

                while (reader.Read())
                {
                    string seatPosition = reader["SeatRow"].ToString() + reader["SeatColumn"].ToString();
                    occupiedSeats.Add(seatPosition);
                }

                reader.Close();

                List<string> selectedSeats = new List<string>();

                foreach (Control control in this.Controls)
                {
                    if (control is PBX seat && seat.BackColor == Color.Black)
                    {
                        string seatName = seat.Name;
                        string seatRow = seatName.Substring(0, 1);
                        string seatColumn = seatName.Substring(1);

                        // Check if the seat is already taken
                        if (!occupiedSeats.Contains(seatName))
                        {
                            // Seat is available, add it to the list of selected seats
                            selectedSeats.Add(seatName);
                        }
                        else
                        {
                            MessageBox.Show($"Seat {seat.Name} is already taken.");
                        }
                    }
                }

                if (selectedSeats.Count > 0)
                {
                   // FinalBookings finalBookingsForm = new FinalBookings(selectedSeats, ScheduleID);
                   // this.Hide();
                   // finalBookingsForm.ShowDialog();
                    this.Close();
                }
            }
            this.Close();
        }


        private void btnReChoose_Click(object sender, EventArgs e)
        {
            HomeStaff SeatForm = new HomeStaff();
            this.Hide();
            SeatForm.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



using MovieTopia.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        public Avalible_seats()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            InitializeComponent();
            loadSeats();
            

        }

        

        private void loadSeats()
        {
            int rows = 0;
            int columns = 0;

            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();
                adapter = new SqlDataAdapter();
                ds = new DataSet();

                string sqlTheatre = @"
                    SELECT
                        NumRows, NumCols, TheatreName, Active
                    FROM
                        Theatre
                    WHERE
                        TheatreID = @TheatreID";
                adapter.SelectCommand = new SqlCommand(sqlTheatre, conn);
                //
                //logic to get the theatre id
                //
                int thearterID = 1;
                adapter.SelectCommand.Parameters.AddWithValue("@TheatreID", thearterID);
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
            int topPadding = (this.ClientSize.Height - (rows * seatHeight + (rows - 1) * verticalSpacing) - lblStage.Height - padding - lblTheater_num.Height) / 2;

            // Center the theater number label
            lblTheater_num.Left = (this.ClientSize.Width - lblTheater_num.Width) / 2;
            lblTheater_num.Top = topPadding;



            // Add seats and row number labels
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    LBL colLabel = new LBL
                    {
                        Text = ((char)('A' + column)).ToString(),
                        Width = seatWidth,
                        Height = seatHeight,
                        Location = new Point(leftPadding + column * (seatWidth + horizontalSpacing), lblTheater_num.Bottom + 10),
                    };
                    this.Controls.Add(colLabel);


                    PBX seat = new PBX
                    {
                        Name = ( (row + 1).ToString()+(char)('A' + column)).ToString() ,
                        Width = seatWidth,
                        Height = seatHeight,
                        Location = new Point(leftPadding + column * (seatWidth + horizontalSpacing), lblTheater_num.Bottom + 40 + row * (seatHeight + verticalSpacing)),
                        Image = Properties.Resources.logoFullPurple, // Default to available seat
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };
                    seat.Click += new EventHandler(PBX_Click);
                    this.Controls.Add(seat);
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
            }

            // Position the stage label
            lblStage.Left = (this.ClientSize.Width - lblStage.Width) / 2;
            lblStage.Top = lblTheater_num.Bottom + 20 + rows * (seatHeight + verticalSpacing) + verticalSpacing;

            // Position buttons under the stage label
            btnSelect.Top = lblStage.Bottom + padding;
            btnSelect.Left = (this.ClientSize.Width - btnSelect.Width) / 2;
            
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
            int movieScheduleID = 1;
            command.Parameters.AddWithValue("@MovieScheduleID", movieScheduleID);

            SqlDataReader reader = command.ExecuteReader();
            HashSet<string> occupiedSeats = new HashSet<string>();

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
                        MessageBox.Show(seat.Name);
                        seat.Image = Properties.Resources.logoIconLight; // Seat is taken

                    }
                }
            }
            

        }


        private void PBX_Click(object sender, EventArgs e)
        {
            PBX seat = sender as PBX;

            MessageBox.Show(seat.Name);

            /*
            // Check the current image and switch to the next state
            if (seat.Image == Properties.Resources.logoFullPurple)
            {
                seat.Image = Properties.Resources.logoFullDarkBlackAndWhite;
            }
            else if (seat.Image == Properties.Resources.logoFullDarkBlackAndWhite)
            {
                seat.Image = Properties.Resources.logoFullPurple;
            }
            else
            {
                seat.Image = Properties.Resources.logoIconLight;
            }
            */
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {

                if (control is PBX seat)
                {
                    if (seat.Image == Properties.Resources.logoFullDarkBlackAndWhite)
                    {
                        MessageBox.Show(seat.Name);
                        seat.Image = Properties.Resources.logoIconLight; // Seat is taken
                    }
                }
            }
        }
    }
}



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
    public partial class FinalBookings : Form
    {
        private string DATABASE_URL;
        DataSet ds;
        SqlDataAdapter adapter;
        private int padding = 50;
        private int MovieScheduleID;
        private int priceT = 0;
        private List<string> SeatNames;

        public FinalBookings(List<string> selectedSeats, int movieScheduleID)
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();
            MovieScheduleID = movieScheduleID;
            SeatNames = selectedSeats;
            this.Resize += FinalBookings_Resize;

            DisplayMovieScheduleDetails();
        }

        private void FinalBookings_Resize(object sender, EventArgs e)
        {
            picLogo.Location = new Point(0, 0);
            picLogo.Height = pnlTop.Height;

            lblFormName.Left = this.ClientSize.Width/2 - lblFormName.Width/2;
            lblFormName.Top = pnlTop.Height/2 - lblFormName.Height/2;   

            gbxHolder.Height = this.ClientSize.Height/2 - pnlTop.Height - 25 - padding;
            gbxHolder.Width = this.ClientSize.Width / 2 - padding - 25;
            gbxHolder.Top = pnlTop.Height + padding;
            gbxHolder.Left = padding;

            gbxMovie.Height = this.ClientSize.Height / 2 - btnCancel.Height - 25 - (padding*2);
            gbxMovie.Width = this.ClientSize.Width / 2 - padding - 25;
            gbxMovie.Top = this.ClientSize.Height / 2 + 25;
            gbxMovie.Left = padding;

            gbxNumbers.Height = this.ClientSize.Height - btnCancel.Height - (padding*3) - pnlTop.Height;
            gbxNumbers.Width = this.ClientSize.Width / 2 - padding - 25;
            gbxNumbers.Top = pnlTop.Height + padding;
            gbxNumbers.Left = this.ClientSize.Width/2 + 25;

            btnCancel.Top = btnGoBack.Top = btnSave.Top = this.ClientSize.Height - padding - btnSave.Height;
            btnCancel.Left = this.ClientSize.Width/2 - btnCancel.Width/2;
            btnSave.Left = this.ClientSize.Width/2 - btnCancel.Width/2 - (padding * 2) - btnSave.Width;
            btnGoBack.Left = this.ClientSize.Width/2 + btnCancel.Width/2 + (padding*2);
        }

        private void DisplayMovieScheduleDetails()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();

                // Pull all info from MovieSchedule table using MovieScheduleID
                string sqlMovieSchedule = @"
            SELECT
                ms.MovieID,
                ms.TheatreID,
                ms.DateTime,
                ms.Price
            FROM
                MovieSchedule ms
            WHERE
                ms.MovieScheduleID = @MovieScheduleID";

                SqlCommand command = new SqlCommand(sqlMovieSchedule, conn);
                command.Parameters.AddWithValue("@MovieScheduleID", MovieScheduleID);

                SqlDataReader reader = command.ExecuteReader();

                int movieID = 0;
                int theatreID = 0;
                int price = 0;
                DateTime scheduleDateTime = DateTime.Today;

                if (reader.Read())
                {
                    movieID = Convert.ToInt32(reader["MovieID"]);
                    theatreID = Convert.ToInt32(reader["TheatreID"]);
                    scheduleDateTime = Convert.ToDateTime(reader["DateTime"]);
                    price = Convert.ToInt32(reader["Price"]);
                    priceT = price;
                }
                reader.Close();

                // Get the MovieName from the Movie table
                string sqlMovie = @"
            SELECT
                Title, Duration
            FROM
                Movie
            WHERE
                MovieID = @MovieID";

                command = new SqlCommand(sqlMovie, conn);
                command.Parameters.AddWithValue("@MovieID", movieID);

                SqlDataReader reader2 = command.ExecuteReader();

                string movieName = "";
                int duration = 0;

                if (reader2.Read())
                {
                    movieName = Convert.ToString(reader2["Title"]);
                    duration = Convert.ToInt32(reader2["Duration"]);
                }
                reader2.Close();
                // Get the TheatreName from the Theatre table
                string sqlTheatre = @"
            SELECT
                TheatreName
            FROM
                Theatre
            WHERE
                TheatreID = @TheatreID";

                command = new SqlCommand(sqlTheatre, conn);
                command.Parameters.AddWithValue("@TheatreID", theatreID);

                string theatreName = command.ExecuteScalar().ToString();

                int hours = 0;
                for (int i = duration; i >= 60; i -= 60)
                {
                    ++hours;
                }
                string durationS = hours.ToString() + " Hours, and " + (duration - hours * 60).ToString() + " min";

                lblMovie.Text = movieName;
                lblTheatre.Text = theatreName;
                lblTicket.Text = "R " + priceT.ToString() + ",00";
                lblDate.Text = scheduleDateTime.ToString("dd MMM YYYY");
                lblTime.Text = scheduleDateTime.ToString("hh:ss tt");
                lblDuration.Text = durationS.ToString();

                DisplaySeatsInRichTextBox();
            }
        }

        private void DisplaySeatsInRichTextBox()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The Seats you have selected are:\n");
            sb.AppendLine("Seat Row\t\tSeat Column\t\tSeat Price");
            sb.AppendLine("========\t\t===========\t\t==========");
            int count = 0;

            foreach (string seatName in SeatNames)
            {
                if (seatName.Length > 1)
                {
                    string seatRow = seatName.Substring(0, 1); // First character as the row
                    string seatNumber = seatName.Substring(1); // Remaining characters as the number

                    sb.AppendLine($"{seatRow}\t\t\t{seatNumber}\t\t\t{lblTicket.Text}");
                    ++count;
                }
            }

            sb.AppendLine("");
            sb.AppendLine("======================================================");
            sb.AppendLine("Amount of Seats: \t" + count + "\t\tTotal: R" + (count * priceT));

            rchSeats.Text = sb.ToString();
            lblPrice.Text = "R " + (priceT * count).ToString() + ",00";
        }



        private void FinalBookings_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCellNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (e.g., backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean saved = false;
            if (txtName.Text.Length > 0)
            {
                if (txtSurname.Text.Length > 0)
                {
                    if (txtCellNum.Text.Length > 0)
                    {
                        foreach (string seatName in SeatNames)
                        {
                            if (seatName.Length > 1)
                            {
                                string seatRow = seatName.Substring(0, 1); // First character as the row
                                string seatNumber = seatName.Substring(1); // Remaining characters as the number
                                using (SqlConnection conn = new SqlConnection(DATABASE_URL))
                                {
                                    conn.Open();

                                    string sqlSeat = @"
                                SELECT
                                    SeatID
                                FROM
                                    Seat
                                WHERE
                                    SeatRow = @SeatRow AND
                                    SeatColumn = @SeatCol";

                                    SqlCommand command = new SqlCommand(sqlSeat, conn);
                                    command.Parameters.AddWithValue("@SeatRow", seatRow);
                                    command.Parameters.AddWithValue("@SeatCol", seatNumber);
                                    string seatID = command.ExecuteScalar().ToString();

                                    // New Code: Check if the seat is already booked for the given MovieScheduleID
                                    string sqlCheck = @"
                                SELECT COUNT(*)
                                FROM Ticket
                                WHERE MovieScheduleID = @MovieScheduleID AND SeatID = @SeatID";

                                    SqlCommand checkCommand = new SqlCommand(sqlCheck, conn);
                                    checkCommand.Parameters.AddWithValue("@MovieScheduleID", MovieScheduleID);
                                    checkCommand.Parameters.AddWithValue("@SeatID", seatID);
                                    int count = (int)checkCommand.ExecuteScalar();

                                    if (count > 0)
                                    {
                                        MessageBox.Show($"Seat {seatRow}{seatNumber} is already booked for this schedule.", "Error");
                                        continue; // Skip to the next seat
                                    }

                                    string sqlInsert = @"
                                INSERT INTO 
                                    Ticket (
                                        MovieScheduleID,
                                        SeatID,
                                        PurchaseDateTime,
                                        CustomerFirstName,
                                        CustomerLastName,
                                        CustomerPhoneNumber
                                    )
                                VALUES
                                    (
                                        @MovieScheduleID,
                                        @SeatID,
                                        @PurchaseDateTime,
                                        @CustomerName,
                                        @CustomerSName,
                                        @CustomerPNum
                                    );";

                                    command = new SqlCommand(sqlInsert, conn);
                                    command.Parameters.AddWithValue("@MovieScheduleID", MovieScheduleID);
                                    command.Parameters.AddWithValue("@SeatID", seatID);
                                    command.Parameters.AddWithValue("@PurchaseDateTime", DateTime.Now);
                                    command.Parameters.AddWithValue("@CustomerName", txtName.Text);
                                    command.Parameters.AddWithValue("@CustomerSName", txtSurname.Text);
                                    command.Parameters.AddWithValue("@CustomerPNum", txtCellNum.Text);

                                    try
                                    {
                                        command.ExecuteNonQuery();
                                        //MessageBox.Show("Your tickets have been booked", "Success");
                                        saved = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Error");
                                    }
                                }
                            }
                            
                        }
                        if (saved)
                        {
                            string result = string.Join(", ", SeatNames);
                            DialogResult dialogResult = MessageBox.Show("Your tickets for the following have been booked: \n\n" +
                                txtName.Text + " " + txtSurname.Text + "\n" +
                                "Cell number: " + txtCellNum.Text + "\n\n" +
                                "Movie Name: " + lblMovie.Text + "\n" +
                                "Theatre: " + lblTheatre.Text + "\n" +
                                "At " + lblTicket.Text + " per ticket\n" +
                                "For seats: " + result, "Ticket Confirmation", MessageBoxButtons.OK);

                            if (dialogResult == DialogResult.OK)
                            {
                                MessageBox.Show("Please collect your ticket and receipt at the register.","All Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Enter your cellphone number \ne.g. 0605811652");
                        txtCellNum.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter your Surname \ne.g. Chamberlain");
                    txtSurname.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Enter your First Name \ne.g. John");
                txtName.Focus();
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Avalible_seats SeatForm = new Avalible_seats(MovieScheduleID);
            this.Hide();
            SeatForm.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the ticket?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void txtCellNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

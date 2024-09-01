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

        private int MovieScheduleID;
        private int priceT = 0;
        private List<string> SeatNames;

        public FinalBookings(List<string> selectedSeats, int movieScheduleID)
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();
            MovieScheduleID = movieScheduleID;
            SeatNames = selectedSeats;

            DisplayMovieScheduleDetails();
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
                DateTime scheduleDateTime;

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
                Title
            FROM
                Movie
            WHERE
                MovieID = @MovieID";

                command = new SqlCommand(sqlMovie, conn);
                command.Parameters.AddWithValue("@MovieID", movieID);

                string movieName = command.ExecuteScalar().ToString();

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

                // Display the movie name in the textbox - txtMovie
                txtMovie.Text = movieName;

                // Display the theatre name in the textbox - txtTheatre
                txtTheatre.Text = theatreName;
                txtPrice.Text = priceT.ToString();

                // Add all the seat names to the richtextbox - rchSeats
                DisplaySeatsInRichTextBox();
            }
        }

        private void DisplaySeatsInRichTextBox()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The Seats you have selected are:\n");
            sb.AppendLine("Seat Row\t\tSeat Column");
            sb.AppendLine("========\t\t===========");
            int count = 0;

            foreach (string seatName in SeatNames)
            {
                if (seatName.Length > 1)
                {
                    string seatRow = seatName.Substring(0, 1); // First character as the row
                    string seatNumber = seatName.Substring(1); // Remaining characters as the number

                    sb.AppendLine($"{seatRow}\t\t\t{seatNumber}");
                    ++count;
                }
            }

            rchSeats.Text = sb.ToString();
            txtTotal.Text = (priceT * count).ToString();
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
                            MessageBox.Show("Your tickets for the following have been booked: \n\n" +
                                txtName.Text + " " + txtSurname.Text + "\n" +
                                "Cell number: " + txtCellNum.Text + "\n\n" +
                                "Movie Name: " + txtMovie.Text + "\n" +
                                "Theatre: " + txtTheatre.Text + "\n" +
                                "At R" + txtPrice.Text + " per ticket\n" +
                                "For seats: " + result, "Ticket Confirmation");
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
            // Show a message box with Yes and No buttons
            DialogResult result = MessageBox.Show("Are you sure you want to cancel the ticket?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check which button was clicked
            if (result == DialogResult.Yes)
            {
                // Close the form if No was clicked
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                // Exit the method if Yes was clicked
                return;
            }
        }
    }
}

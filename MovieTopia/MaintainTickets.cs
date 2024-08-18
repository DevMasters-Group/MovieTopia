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
    public partial class MaintainTickets : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        DataSet ds;
        SqlDataAdapter adapter;

        public MaintainTickets()
        {
            // get database connection string
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();

            // handle form scaling/ sizing
            this.Resize += Form_Resize;

            // load initial data when form loads
            LoadData();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            // position controls
            lblName.Left = (this.ClientSize.Width - lblName.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width / 2) + padding / 2;
            btnNew.Left = (this.ClientSize.Width / 2) - btnNew.Width - padding / 2;
            //btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            //btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);

            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                // select the parent table and join any additional fields from child entities
                string sqlTicket = @"
                        SELECT
                            t.TicketID, 
                            t.MovieScheduleID, 
                            t.SeatID, 
                            t.Price, 
                            t.PurchaseDateTime, 
                            t.CustomerFirstName, 
                            t.CustomerLastName, 
                            t.CustomerPhoneNumber, 
                            m.Title, 
                            th.TheatreName, 
                            s.SeatRow
                        FROM
                            Ticket t
                        LEFT JOIN
                            MovieSchedule ms ON t.MovieScheduleID = ms.MovieScheduleID
                        LEFT JOIN
                            Movie m ON ms.MovieID = m.MovieID
                        LEFT JOIN
                            Theatre th ON ms.TheatreID = th.TheatreID
                        LEFT JOIN
                            Seat s ON t.SeatID = s.SeatID";


                // NB: select the ENTIRE child entity and store it in the dataset as well. This is used in the DetailsForm for dropdown boxes
                string sqlMovies = "SELECT * FROM Movie";
                string sqlTheatres = "SELECT * FROM Theatre";
                string sqlMovieSchedule = "SELECT * FROM MovieSchedule";
                string sqlSeats = "SELECT * FROM Seat";

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlTicket, conn); ;
                adapter.Fill(ds, "Ticket");
                adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                adapter.Fill(ds, "Movie");
                adapter.SelectCommand = new SqlCommand(sqlTheatres, conn); ;
                adapter.Fill(ds, "Theatre");
                adapter.SelectCommand = new SqlCommand(sqlMovieSchedule, conn); ;
                adapter.Fill(ds, "MovieSchedule");
                adapter.SelectCommand = new SqlCommand(sqlSeats, conn); ;
                adapter.Fill(ds, "Seat");

                // fill the datagrid
                dgvSchedules.DataSource = ds;
                dgvSchedules.DataMember = "Ticket";
            }
        }

        private void AdjustDataGridViewSize()
        {
            dgvSchedules.Width = this.ClientSize.Width - (2 * padding);
            dgvSchedules.Height = this.ClientSize.Height - (10 * padding);
            dgvSchedules.Location = new Point(padding, padding * 3);
        }

        private void AdjustColumnWidths()
        {
            if (dgvSchedules.Columns.Count == 0)
                return;

            // Set DataGridView column text
            //dgvSchedules.Columns["MovieScheduleID"].HeaderText = "ID";

            // Set DataGridView column widths
            //dgvSchedules.Columns["MovieScheduleID"].Width = (int)(dgvSchedules.Width * 0.1);

            // optionally set specific columns to hidden
            //dgvSchedules.Columns["GenreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
            foreignKeySchemaNames["MovieID"] = "Title";
            foreignKeySchemaNames["TheatreID"] = "TheatreName";
            foreignKeySchemaNames["SeatID"] = "SeatRow";

            DetailsForm detailsForm = new DetailsForm("Ticket", ds, null, foreignKeySchemaNames);
            DialogResult result = detailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Dictionary<string, Control> data = detailsForm.controlsDict;

                string sql = @"
                        INSERT INTO 
                            Ticket (
                                MovieScheduleID,
                                SeatID,
                                Price,
                                PurchaseDateTime,
                                CustomerFirstName,
                                CustomerLastName,
                                CustomerPhoneNumber
                            )
                            VALUES
                            (
                                @MovieScheduleID,
                                @SeatID,
                                @Price,
                                @PurchaseDateTime,
                                @CustomerFirstName,
                                @CustomerLastName,
                                @CustomerPhoneNumber
                            );";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@MovieScheduleID", ((ComboBox)data["MovieScheduleID"]).SelectedValue);
                    command.Parameters.AddWithValue("@SeatID", ((ComboBox)data["SeatID"]).SelectedValue);
                    command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
                    command.Parameters.AddWithValue("@PurchaseDateTime", ((DateTimePicker)data["PurchaseDateTime"]).Text);
                    command.Parameters.AddWithValue("@CustomerFirstName", ((TextBox)data["CustomerFirstName"]).Text);
                    command.Parameters.AddWithValue("@CustomerLastName", ((TextBox)data["CustomerLastName"]).Text);
                    command.Parameters.AddWithValue("@CustomerPhoneNumber", ((TextBox)data["CustomerPhoneNumber"]).Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Created Successfully", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }

                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvSchedules.SelectedRows[0];  // get the selected row

                // This dictionary is used for mapping certain columns to their values in the child table - i.e. what column data you want to show in the drop down box
                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["MovieID"] = "Title";  // this will show the Movie title in the drop down
                foreignKeySchemaNames["TheatreID"] = "TheatreName";
                foreignKeySchemaNames["SeatID"] = "SeatRow";

                DetailsForm detailsForm = new DetailsForm("Ticket", ds, selectedRow, foreignKeySchemaNames);
                DialogResult result = detailsForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // get the dictionary of controls back from the form to get their values
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            Ticket
                        SET
                            MovieScheduleID = @MovieScheduleID,
                            SeatID = @SeatID,
                            Price = @Price,
                            PurchaseDateTime = @PurchaseDateTime,
                            CustomerFirstName = @CustomerFirstName,
                            CustomerLastName = @CustomerLastName,
                            CustomerPhoneNumber = @CustomerPhoneNumber
                        WHERE
                            TicketID = @TicketID;
                        ";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@MovieScheduleID", ((ComboBox)data["MovieScheduleID"]).SelectedValue);
                        command.Parameters.AddWithValue("@SeatID", ((ComboBox)data["SeatID"]).SelectedValue);
                        command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
                        command.Parameters.AddWithValue("@PurchaseDateTime", ((DateTimePicker)data["PurchaseDateTime"]).Text);
                        command.Parameters.AddWithValue("@CustomerFirstName", ((TextBox)data["CustomerFirstName"]).Text);
                        command.Parameters.AddWithValue("@CustomerLastName", ((TextBox)data["CustomerLastName"]).Text);
                        command.Parameters.AddWithValue("@CustomerPhoneNumber", ((TextBox)data["CustomerPhoneNumber"]).Text);
                        command.Parameters.AddWithValue("@TicketID", ((TextBox)data["TicketID"]).Text);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Updated Successfully", "Success");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                    }

                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvSchedules.SelectedRows[0];

                string sql = @"
                        DELETE FROM 
                            Ticket
                        WHERE
                            TicketID = @TicketID;";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@TicketID", selectedRow.Cells["TicketID"].Value);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }

                LoadData();
            }
        }
    }

}

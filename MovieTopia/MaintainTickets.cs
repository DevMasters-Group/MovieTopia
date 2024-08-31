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
        private string tblName = "Ticket";
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
            lblName.Top = padding / 2;
            lblName.Left = (this.ClientSize.Width - lblName.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width - btnEdit.Width) / 2;
            btnNew.Left = btnEdit.Left - btnEdit.Width - padding;
            btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnReturn.Left = this.ClientSize.Width - btnReturn.Width - padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);
            btnReturn.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);

            lblFilter.Location = new Point(padding, 3 * padding);
            txtFilter.Location = new Point(lblFilter.Left + lblFilter.Width + padding, 3 * padding);

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
                            ms.Price, 
                            t.PurchaseDateTime, 
                            t.CustomerFirstName, 
                            t.CustomerLastName, 
                            t.CustomerPhoneNumber, 
                            m.Title, 
                            th.TheatreName,
                            ms.DateTime,
                            CONCAT(s.SeatColumn, s.SeatRow) as CSeat
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
                string sqlMovieSchedule = "SELECT ms.*, CONCAT(m.Title, ' - ', ms.DateTime) as MovieSchedule FROM MovieSchedule ms JOIN Movie m ON ms.MovieID = m.MovieID;";
                string sqlSeats = "SELECT * ,CONCAT(SeatColumn, SeatRow) AS CSeat FROM Seat";
                

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlTicket, conn); ;
                adapter.Fill(ds, "Ticket");
                //adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                //adapter.Fill(ds, "Movie");
                //adapter.SelectCommand = new SqlCommand(sqlTheatres, conn); ;
                //adapter.Fill(ds, "Theatre");
                adapter.SelectCommand = new SqlCommand(sqlMovieSchedule, conn); ;
                adapter.Fill(ds, "MovieSchedule");
                adapter.SelectCommand = new SqlCommand(sqlSeats, conn); ;
                adapter.Fill(ds, "Seat");

                // fill the datagrid
                //dgvData.DataSource = ds;
                //dgvData.DataMember = "Ticket";
                dgvData.DataSource = ds.Tables[tblName].DefaultView;
            }
        }

        private void AdjustDataGridViewSize()
        {
            dgvData.Width = this.ClientSize.Width - (2 * padding);
            dgvData.Height = this.ClientSize.Height - (11 * padding);
            dgvData.Location = new Point(padding, padding * 5);
        }

        private void AdjustColumnWidths()
        {
            if (dgvData.Columns.Count == 0)
                return;

            // Set DataGridView column text
            dgvData.Columns["TicketID"].HeaderText = "Ticket ID";
            dgvData.Columns["PurchaseDateTime"].HeaderText = "Purchased on";
            dgvData.Columns["CustomerFirstName"].HeaderText = "Customer First Name";
            dgvData.Columns["CustomerLastName"].HeaderText = "Customer Last Name";
            dgvData.Columns["CustomerPhoneNumber"].HeaderText = "Customer Phone Number";
            dgvData.Columns["Title"].HeaderText = "Movie";
            dgvData.Columns["TheatreName"].HeaderText = "Theatre";
            dgvData.Columns["DateTime"].HeaderText = "Movie Time";
            dgvData.Columns["CSeat"].HeaderText = "Seat Number";


            // Set DataGridView column widths
            dgvData.Columns["TicketID"].Width = (int)(dgvData.Width * 0.06);
            dgvData.Columns["Price"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["PurchaseDateTime"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["CustomerFirstName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["CustomerLastName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["CustomerPhoneNumber"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["Title"].Width = (int)(dgvData.Width * 0.112);
            dgvData.Columns["TheatreName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["DateTime"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["CSeat"].Width = (int)(dgvData.Width * 0.1);

            // optionally set specific columns to hidden
            dgvData.Columns["MovieScheduleID"].Visible = false;
            dgvData.Columns["SeatID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
            foreignKeySchemaNames["MovieScheduleID"] = "MovieSchedule";
            foreignKeySchemaNames["SeatID"] = "CSeat";

            Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
            attributeNameMap["TicketID"] = "Ticket ID";
            attributeNameMap["MovieScheduleID"] = "Movie Schedule";
            attributeNameMap["SeatID"] = "Seat Number";
            attributeNameMap["PurchaseDateTime"] = "Purchased on";
            attributeNameMap["CustomerPhoneNumber"] = "Phone Number";
            attributeNameMap["CustomerFirstName"] = "First Name";
            attributeNameMap["CustomerLastName"] = "Last Name";

            DetailsForm detailsForm = new DetailsForm("Ticket", ds, null, foreignKeySchemaNames, attributeNameMap);
            DialogResult result = detailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string sqlCheckSeat = @"
                        SELECT SeatID FROM Ticket WHERE MovieScheduleID = @MovieScheduleID AND SeatID = @SeatID";
                Dictionary<string, Control> data = detailsForm.controlsDict;

                string sql = @"
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
                                @CustomerFirstName,
                                @CustomerLastName,
                                @CustomerPhoneNumber
                            );";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sqlCheckSeat, connection);

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    var selectedMovie = (KeyValuePair<int, string>)((ComboBox)data["MovieScheduleID"]).SelectedItem;
                    command.Parameters.AddWithValue("@MovieScheduleID", selectedMovie.Key);
                    var selectedSeat = (KeyValuePair<int, string>)((ComboBox)data["SeatID"]).SelectedItem;
                    command.Parameters.AddWithValue("@SeatID", selectedSeat.Key);
                    //command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
                    command.Parameters.AddWithValue("@PurchaseDateTime", ((DateTimePicker)data["PurchaseDateTime"]).Text);
                    command.Parameters.AddWithValue("@CustomerFirstName", ((TextBox)data["CustomerFirstName"]).Text);
                    command.Parameters.AddWithValue("@CustomerLastName", ((TextBox)data["CustomerLastName"]).Text);
                    command.Parameters.AddWithValue("@CustomerPhoneNumber", ((TextBox)data["CustomerPhoneNumber"]).Text);


                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader()

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Created Successfully", "Success");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("This seat has already been booked for the selected Movie Schedule.", "Error");
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
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];  // get the selected row

                // This dictionary is used for mapping certain columns to their values in the child table - i.e. what column data you want to show in the drop down box
                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();

                foreignKeySchemaNames["MovieScheduleID"] = "MovieSchedule";  // this will show the Movie title in the drop down
                foreignKeySchemaNames["SeatID"] = "CSeat";

                Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
                attributeNameMap["TicketID"] = "Ticket ID";
                attributeNameMap["MovieScheduleID"] = "Movie Schedule";
                attributeNameMap["SeatID"] = "Seat Number";
                attributeNameMap["PurchaseDateTime"] = "Purchased on";
                attributeNameMap["CustomerPhoneNumber"] = "Phone Number";
                attributeNameMap["CustomerFirstName"] = "First Name";
                attributeNameMap["CustomerLastName"] = "Last Name";

                DetailsForm detailsForm = new DetailsForm("Ticket", ds, selectedRow, foreignKeySchemaNames, attributeNameMap);

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
                        var selectedMovie = (KeyValuePair<int, string>)((ComboBox)data["MovieScheduleID"]).SelectedItem;
                        command.Parameters.AddWithValue("@MovieScheduleID", selectedMovie.Key);
                        var selectedSeat = (KeyValuePair<int, string>)((ComboBox)data["SeatID"]).SelectedItem;
                        command.Parameters.AddWithValue("@SeatID", selectedSeat.Key);
                        //command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
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
                        catch (SqlException)
                        {
                            MessageBox.Show("This seat has already been booked for the selected Movie Schedule.", "Error");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                    }

                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a Ticket to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the selected ticket?", "Delete Ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;

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
            else
            {
                MessageBox.Show("Please select a ticket to delete.");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFilter.Text;
            DataTable dt = ds.Tables[tblName];

            if (string.IsNullOrEmpty(filterText))
            {
                dt.DefaultView.RowFilter = "";
            }
            else
            {
                // Construct the filter string
                var filterConditions = dt.Columns.Cast<DataColumn>()
                    .Select(c => {
                        if (c.DataType == typeof(string))
                        {
                            return $"{c.ColumnName} LIKE '%{filterText}%'";
                        }
                        else if (c.DataType == typeof(int) || c.DataType == typeof(decimal))
                        {
                            // Try parsing filterText to avoid applying invalid filter
                            if (decimal.TryParse(filterText, out _))
                            {
                                return $"{c.ColumnName} = {filterText}";
                            }
                            else
                            {
                                return null;
                            }
                        }
                        return null;
                    })
                    .Where(condition => condition != null); // Filter out any null conditions

                // Combine all filter conditions using "OR"
                dt.DefaultView.RowFilter = string.Join(" OR ", filterConditions);
            }
        }
    }

}

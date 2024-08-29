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
    public partial class ScheduleMovies : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        private string tblName = "MovieSchedule";
        DataSet ds;
        SqlDataAdapter adapter;

        public ScheduleMovies()
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
                string sqlMovieSchedules = @"
                            SELECT
                                ms.MovieScheduleID, ms.MovieID, ms.TheatreID, ms.Price, ms.DateTime, DATEADD(MINUTE, m.Duration, ms.DateTime) as EndDateTime, m.Title, m.Duration, m.PG_Rating, t.TheatreName, g.GenreName
                            FROM
                                MovieSchedule ms
                            JOIN
                                Movie m ON ms.MovieID = m.MovieID
                            JOIN
                                Theatre t ON ms.TheatreID = t.TheatreID
                            JOIN
                                Genre g ON m.GenreID = g.GenreID";
                // NB: select the ENTIRE child entity and store it in the dataset as well. This is used in the DetailsForm for dropdown boxes
                string sqlMovies = "SELECT * FROM Movie";
                string sqlTheatres = "SELECT * FROM Theatre WHERE Active = 1;";

                // important to name the returned data in the dataset with the entity name
                adapter.SelectCommand = new SqlCommand(sqlMovieSchedules, conn); ;
                adapter.Fill(ds, "MovieSchedule");
                adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                adapter.Fill(ds, "Movie");
                adapter.SelectCommand = new SqlCommand(sqlTheatres, conn); ;
                adapter.Fill(ds, "Theatre");

                // fill the datagrid
                //dgvData.DataSource = ds;
                //dgvData.DataMember = "MovieSchedule";
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
            dgvData.Columns["MovieScheduleID"].HeaderText = "Schedule ID";
            dgvData.Columns["TheatreName"].HeaderText = "Theatre";
            dgvData.Columns["PG_Rating"].HeaderText = "PG Rating";
            dgvData.Columns["GenreName"].HeaderText = "Genre";
            dgvData.Columns["DateTime"].HeaderText = "Start Time";
            dgvData.Columns["EndDateTime"].HeaderText = "End Time";

            // Set DataGridView column widths
            dgvData.Columns["MovieScheduleID"].Width = (int)(dgvData.Width * 0.06);
            dgvData.Columns["Price"].Width = (int)(dgvData.Width * 0.06);
            dgvData.Columns["DateTime"].Width = (int)(dgvData.Width * 0.09);
            dgvData.Columns["EndDateTime"].Width = (int)(dgvData.Width * 0.09);
            dgvData.Columns["Title"].Width = (int)(dgvData.Width * 0.277);
            dgvData.Columns["Duration"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["PG_Rating"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["TheatreName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["GenreName"].Width = (int)(dgvData.Width * 0.1);

            // optionally set specific columns to hidden
            dgvData.Columns["MovieID"].Visible = false;
            dgvData.Columns["TheatreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
            foreignKeySchemaNames["MovieID"] = "Title";
            foreignKeySchemaNames["TheatreID"] = "TheatreName";

            Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
            attributeNameMap["MovieScheduleID"] = "Movie Schedule ID";
            attributeNameMap["MovieID"] = "Movie";
            attributeNameMap["TheatreID"] = "Theatre";
            attributeNameMap["DateTime"] = "Movie Date and Time";

            DetailsForm detailsForm = new DetailsForm("MovieSchedule", ds, null, foreignKeySchemaNames, attributeNameMap);
            DialogResult result = detailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Dictionary<string, Control> data = detailsForm.controlsDict;

                var selectedMovie = (KeyValuePair<int, string>)((ComboBox)data["MovieID"]).SelectedItem;
                var selectedTheatre = (KeyValuePair<int, string>)((ComboBox)data["TheatreID"]).SelectedItem;
                var dateTime = ((DateTimePicker)data["DateTime"]).Text;

                if (!isValidScheduleTime(selectedTheatre.Key, DateTime.Parse(dateTime))) return;

                string sql = @"
                        INSERT INTO 
                            MovieSchedule (
                                MovieID,
                                TheatreID,
                                Price,
                                DateTime
                            )
                            VALUES
                            (
                                @MovieID,
                                @TheatreID,
                                @Price,
                                @DateTime
                            );";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    
                    command.Parameters.AddWithValue("@MovieID", selectedMovie.Key);
                    command.Parameters.AddWithValue("@TheatreID", selectedTheatre.Key);
                    command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
                    command.Parameters.AddWithValue("@DateTime", dateTime);

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

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];  // get the selected row

                // This dictionary is used for mapping certain columns to their values in the child table - i.e. what column data you want to show in the drop down box
                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["MovieID"] = "Title";  // this will show the Movie title in the drop down
                foreignKeySchemaNames["TheatreID"] = "TheatreName";

                Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
                attributeNameMap["MovieScheduleID"] = "Movie Schedule ID";
                attributeNameMap["MovieID"] = "Movie";
                attributeNameMap["TheatreID"] = "Theatre";
                attributeNameMap["DateTime"] = "Movie Date and Time";

                DetailsForm detailsForm = new DetailsForm("MovieSchedule", ds, selectedRow, foreignKeySchemaNames, attributeNameMap);
                DialogResult result = detailsForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // get the dictionary of controls back from the form to get their values
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            MovieSchedule
                        SET
                            MovieID = @MovieID,
                            TheatreID = @TheatreID,
                            Price = @Price,
                            DateTime = @DateTime
                        WHERE
                            MovieScheduleID = @MovieScheduleID;
                        ";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        var selectedMovie = (KeyValuePair<int, string>)((ComboBox)data["MovieID"]).SelectedItem;
                        command.Parameters.AddWithValue("@MovieID", selectedMovie.Key);
                        var selectedTheatre = (KeyValuePair<int, string>)((ComboBox)data["TheatreID"]).SelectedItem;
                        command.Parameters.AddWithValue("@TheatreID", selectedTheatre.Key);
                        command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
                        command.Parameters.AddWithValue("@DateTime", ((DateTimePicker)data["DateTime"]).Text);
                        command.Parameters.AddWithValue("@MovieScheduleID", ((TextBox)data["MovieScheduleID"]).Text);

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

        private bool canScheduleAfterExistingDate(DateTime datetime, int theatreID, int minutesBetweenMovies)
        {
            DateTime mostRecentSchedule = datetime;
            string movie = string.Empty;
            int movieDuration = 0;
            string theatreName = string.Empty;

            string sql = @"
                SELECT
                    TOP 1 ms.*, m.Duration, m.Title, t.TheatreName
                FROM
                    MovieSchedule ms
                JOIN
                    Movie m ON m.MovieID = ms.MovieID
                JOIN
                    Theatre t on t.TheatreID = ms.TheatreID 
                WHERE
                    ms.TheatreID = @TheatreID AND ms.DateTime <= @DateTime
                ORDER BY DateTime DESC;";

            using (SqlConnection connection = new SqlConnection(DATABASE_URL))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@TheatreID", theatreID);
                command.Parameters.AddWithValue("@DateTime", datetime);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        mostRecentSchedule = reader.GetDateTime(reader.GetOrdinal("DateTime"));
                        movie = reader.GetString(reader.GetOrdinal("Title"));
                        movieDuration = reader.GetInt32(reader.GetOrdinal("Duration"));
                        theatreName = reader.GetString(reader.GetOrdinal("TheatreName"));
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            MessageBox.Show($"after existing - selected: {datetime.ToString("yyyy-MM-dd HH:mm")}; existing: {mostRecentSchedule.ToString("yyyy-MM-dd HH:mm")}");
            bool scheduleAfterExisting = mostRecentSchedule.AddMinutes(movieDuration + minutesBetweenMovies) <= datetime;
            if (!scheduleAfterExisting)
            {
                MessageBox.Show($"The '{theatreName}' theatre is not available at the specified time due to a clash with another schedule for this theatre. The selected theatre is booked out from {mostRecentSchedule} to {mostRecentSchedule.AddMinutes(movieDuration + minutesBetweenMovies)} for '{movie}'.");
                return false;
            }
            return true;
        }

        private bool canScheduleBeforeExistingDate(DateTime datetime, int theatreID, int minutesBetweenMovies)
        {
            DateTime mostRecentSchedule = datetime;
            string movie = string.Empty;
            int movieDuration = 0;
            string theatreName = string.Empty;

            string sql = @"
                SELECT
                    TOP 1 ms.*, m.Duration, m.Title, t.TheatreName
                FROM
                    MovieSchedule ms
                JOIN
                    Movie m ON m.MovieID = ms.MovieID
                JOIN
                    Theatre t on t.TheatreID = ms.TheatreID 
                WHERE
                    ms.TheatreID = @TheatreID AND ms.DateTime >= @DateTime
                ORDER BY DateTime ASC;";

            using (SqlConnection connection = new SqlConnection(DATABASE_URL))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@TheatreID", theatreID);
                command.Parameters.AddWithValue("@DateTime", datetime);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        mostRecentSchedule = reader.GetDateTime(reader.GetOrdinal("DateTime"));
                        movie = reader.GetString(reader.GetOrdinal("Title"));
                        movieDuration = reader.GetInt32(reader.GetOrdinal("Duration"));
                        theatreName = reader.GetString(reader.GetOrdinal("TheatreName"));
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            MessageBox.Show($"before existing - selected: {datetime.ToString("yyyy-MM-dd HH:mm")}; existing {mostRecentSchedule.ToString("yyyy-MM-dd HH:mm")}");
            bool scheduleBeforeExisting = mostRecentSchedule >= datetime.AddMinutes(movieDuration + minutesBetweenMovies);
            if (!scheduleBeforeExisting)
            {
                MessageBox.Show($"The '{theatreName}' theatre is not available at the specified time due to a clash with another schedule for this theatre. The selected theatre is booked out from {mostRecentSchedule} to {mostRecentSchedule.AddMinutes(movieDuration + minutesBetweenMovies)} for '{movie}'.");
                return false;
            }
            return true;
        }

        private bool isValidScheduleTime(int theatreID, DateTime dateTime)
        {
            int minutesBetweenMovies = 30;
            if (!canScheduleAfterExistingDate(dateTime, theatreID, minutesBetweenMovies)) return false;
            if (!canScheduleBeforeExistingDate(dateTime, theatreID, minutesBetweenMovies)) return false;

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete the selected movie schedule?", "Delete Movie Schedule", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No) return;

                string sql = @"
                        DELETE FROM 
                            MovieSchedule
                        WHERE
                            MovieScheduleID = @MovieScheduleID;";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@MovieScheduleID", selectedRow.Cells["MovieScheduleID"].Value);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Success");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"The selected Movie Schedule cannot be deleted because of 1 or more Tickets that are dependent on this Schedule. Please delete the corresponding records before attempting to delete this Schedule.", "Error");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }

                LoadData();
            }
        }

        private void ScheduleMovies_Load(object sender, EventArgs e)
        {

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

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
                                ms.MovieScheduleID, ms.MovieID, ms.TheatreID, ms.Price, ms.DateTime, m.Title, m.Duration, m.PG_Rating, t.TheatreName, g.GenreName
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
                dgvSchedules.DataSource = ds;
                dgvSchedules.DataMember = "MovieSchedule";
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
            dgvSchedules.Columns["MovieScheduleID"].HeaderText = "Schedule ID";
            dgvSchedules.Columns["TheatreName"].HeaderText = "Theatre";
            dgvSchedules.Columns["PG_Rating"].HeaderText = "PG Rating";
            dgvSchedules.Columns["GenreName"].HeaderText = "Genre";
            dgvSchedules.Columns["DateTime"].HeaderText = "Start Time";

            // Set DataGridView column widths
            dgvSchedules.Columns["MovieScheduleID"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["Price"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["DateTime"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["Title"].Width = (int)(dgvSchedules.Width * 0.272);
            dgvSchedules.Columns["Duration"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["PG_Rating"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["TheatreName"].Width = (int)(dgvSchedules.Width * 0.1);
            dgvSchedules.Columns["GenreName"].Width = (int)(dgvSchedules.Width * 0.1);

            // optionally set specific columns to hidden
            dgvSchedules.Columns["MovieID"].Visible = false;
            dgvSchedules.Columns["TheatreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
            foreignKeySchemaNames["MovieID"] = "Title";
            foreignKeySchemaNames["TheatreID"] = "TheatreName";

            DetailsForm detailsForm = new DetailsForm("MovieSchedule", ds, null, foreignKeySchemaNames);
            DialogResult result = detailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Dictionary<string, Control> data = detailsForm.controlsDict;

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
                    command.Parameters.AddWithValue("@MovieID", ((ComboBox)data["MovieID"]).SelectedValue);
                    command.Parameters.AddWithValue("@TheatreID", ((ComboBox)data["TheatreID"]).SelectedValue);
                    command.Parameters.AddWithValue("@Price", ((NumericUpDown)data["Price"]).Value);
                    command.Parameters.AddWithValue("@DateTime", ((DateTimePicker)data["DateTime"]).Text);

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
            if (dgvSchedules.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvSchedules.SelectedRows[0];  // get the selected row

                // This dictionary is used for mapping certain columns to their values in the child table - i.e. what column data you want to show in the drop down box
                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["MovieID"] = "Title";  // this will show the Movie title in the drop down
                foreignKeySchemaNames["TheatreID"] = "TheatreName";

                DetailsForm detailsForm = new DetailsForm("MovieSchedule", ds, selectedRow, foreignKeySchemaNames);
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
                        command.Parameters.AddWithValue("@MovieID", ((ComboBox)data["MovieID"]).SelectedValue);
                        command.Parameters.AddWithValue("@TheatreID", ((ComboBox)data["TheatreID"]).SelectedValue);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedules.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvSchedules.SelectedRows[0];

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
    }
}

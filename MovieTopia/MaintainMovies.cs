using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class MaintainMovies : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        DataSet ds;
        SqlDataAdapter adapter;

        public MaintainMovies()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();

            this.Resize += Form_Resize;

            LoadMovies();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            lblName.Left = (this.ClientSize.Width - lblName.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width - btnEdit.Width) /2;
            btnNew.Left = btnEdit.Left - btnEdit.Width - padding;
            btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding*2);
            btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding*2);
            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void LoadMovies()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                //string sql = "SELECT * FROM Movie";
                string sqlMovies = @"
                            SELECT
                                m.MovieID, m.GenreID, m.Title, m.Description, m.Duration, m.PG_Rating, g.GenreName
                            FROM
                                Movie m
                            JOIN
                                Genre g ON m.GenreID = g.GenreID";
                string sqlGenres = "SELECT * FROM Genre";
                string sqlSeats = "SELECT * FROM Seat";
                //cmd = new SqlCommand(sqlMovies, conn);

                adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                adapter.Fill(ds, "Movie");
                adapter.SelectCommand = new SqlCommand(sqlGenres, conn); ;
                adapter.Fill(ds, "Genre");
                adapter.SelectCommand = new SqlCommand(sqlSeats, conn); ;
                adapter.Fill(ds, "Seat");

                dgvMovies.DataSource = ds;
                dgvMovies.DataMember = "Movie";
            }
        }

        private void AdjustDataGridViewSize()
        {
            dgvMovies.Width = this.ClientSize.Width - (2 * padding);
            dgvMovies.Height = this.ClientSize.Height - (10 * padding);
            dgvMovies.Location = new Point(padding, padding * 3);
        }

        private void AdjustColumnWidths()
        {
            if (dgvMovies.Columns.Count == 0)
                return;

            dgvMovies.Columns["MovieID"].HeaderText = "Movie ID";
            dgvMovies.Columns["PG_Rating"].HeaderText = "PG Rating";
            dgvMovies.Columns["GenreName"].HeaderText = "Genre";

            dgvMovies.Columns["MovieID"].Width = (int)(dgvMovies.Width * 0.1);
            //dgvMovies.Columns["GenreID"].Width = (int)(dgvMovies.Width * 0.1);
            dgvMovies.Columns["GenreName"].Width = (int)(dgvMovies.Width * 0.1);
            dgvMovies.Columns["Title"].Width = (int)(dgvMovies.Width * 0.2);
            dgvMovies.Columns["Description"].Width = (int)(dgvMovies.Width * 0.378);
            dgvMovies.Columns["Duration"].Width = (int)(dgvMovies.Width * 0.1);
            dgvMovies.Columns["PG_Rating"].Width = (int)(dgvMovies.Width * 0.1);

            // optionally set specific columns to hidden
            dgvMovies.Columns["GenreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 1)
            {
                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["GenreID"] = "GenreName";

                DetailsForm detailsForm = new DetailsForm("Movie", ds, null, foreignKeySchemaNames);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        INSERT INTO 
                            Movie (
                                GenreID,
                                Title,
                                Description,
                                Duration,
                                PG_Rating
                            )
                            VALUES
                            (
                                @GenreID,
                                @Title,
                                @Description,
                                @Duration,
                                @PG_Rating
                            );";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@GenreID", ((ComboBox)data["GenreID"]).SelectedValue);
                        command.Parameters.AddWithValue("@Title", ((TextBox)data["Title"]).Text);
                        command.Parameters.AddWithValue("@Description", ((TextBox)data["Description"]).Text);
                        command.Parameters.AddWithValue("@Duration", int.Parse(((NumericUpDown)data["Duration"]).Text));
                        command.Parameters.AddWithValue("@PG_Rating", ((TextBox)data["PG_Rating"]).Text);

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

                    LoadMovies();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvMovies.SelectedRows[0];

                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["GenreID"] = "GenreName";

                DetailsForm detailsForm = new DetailsForm("Movie", ds, selectedRow, foreignKeySchemaNames);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            Movie
                        SET 
                            GenreID = @GenreID,
                            Title = @Title,
                            Description = @Description,
                            Duration = @Duration,
                            PG_Rating = @PG_Rating
                        WHERE
                            MovieID = @MovieID;
                        ";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@GenreID", ((ComboBox)data["GenreID"]).SelectedValue);
                        command.Parameters.AddWithValue("@Title", ((TextBox)data["Title"]).Text);
                        command.Parameters.AddWithValue("@Description", ((TextBox)data["Description"]).Text);
                        command.Parameters.AddWithValue("@Duration", int.Parse(((NumericUpDown)data["Duration"]).Text));
                        command.Parameters.AddWithValue("@PG_Rating", ((TextBox)data["PG_Rating"]).Text);
                        command.Parameters.AddWithValue("@MovieID", ((TextBox)data["MovieID"]).Text);

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

                    LoadMovies();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvMovies.SelectedRows[0];

                string sql = @"
                        DELETE FROM 
                            Movie
                        WHERE
                            MovieID = @MovieID;";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@MovieID", selectedRow.Cells["MovieID"].Value);

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

                LoadMovies();
            }
        }
    }
}

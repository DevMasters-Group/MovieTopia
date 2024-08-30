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
        private string tblName = "Movie";
        DataSet ds;
        SqlDataAdapter adapter;

        public MaintainMovies()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();

            this.Resize += Form_Resize;

            LoadData();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            lblName.Top = padding / 2;
            lblName.Left = (this.ClientSize.Width - lblName.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width - btnEdit.Width) /2;
            btnNew.Left = btnEdit.Left - btnEdit.Width - padding;
            btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnReturn.Left = this.ClientSize.Width - btnReturn.Width - padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);
            btnReturn.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);

            lblFilter.Location = new Point(padding, 3 * padding);
            txtFilter.Location = new Point(lblFilter.Left + lblFilter.Width + padding, 3 * padding);
            btnHelp.Location = new Point(btnReturn.Left, lblFilter.Top - padding / 2);

            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void LoadData()
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
                                Genre g ON m.GenreID = g.GenreID;";
                string sqlGenres = "SELECT * FROM Genre";
                string sqlSeats = "SELECT * FROM Seat";
                //cmd = new SqlCommand(sqlMovies, conn);

                adapter.SelectCommand = new SqlCommand(sqlMovies, conn); ;
                adapter.Fill(ds, "Movie");
                adapter.SelectCommand = new SqlCommand(sqlGenres, conn); ;
                adapter.Fill(ds, "Genre");
                adapter.SelectCommand = new SqlCommand(sqlSeats, conn); ;
                adapter.Fill(ds, "Seat");

                //dgvData.DataSource = ds;
                //dgvData.DataMember = "Movie";
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

            dgvData.Columns["MovieID"].HeaderText = "Movie ID";
            dgvData.Columns["PG_Rating"].HeaderText = "PG Rating";
            dgvData.Columns["GenreName"].HeaderText = "Genre";

            dgvData.Columns["MovieID"].Width = (int)(dgvData.Width * 0.1);
            //dgvData.Columns["GenreID"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["GenreName"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["Title"].Width = (int)(dgvData.Width * 0.2);
            dgvData.Columns["Description"].Width = (int)(dgvData.Width * 0.377);
            dgvData.Columns["Duration"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["PG_Rating"].Width = (int)(dgvData.Width * 0.1);

            // optionally set specific columns to hidden
            dgvData.Columns["GenreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
            foreignKeySchemaNames["GenreID"] = "GenreName";

            Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
            attributeNameMap["MovieID"] = "Movie ID";
            attributeNameMap["GenreID"] = "Genre";
            attributeNameMap["PG_Rating"] = "PG Rating";

            DetailsForm detailsForm = new DetailsForm("Movie", ds, null, foreignKeySchemaNames, attributeNameMap);
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
                    var selectedGenre = (KeyValuePair<int, string>)((ComboBox)data["GenreID"]).SelectedItem;
                    command.Parameters.AddWithValue("@GenreID", selectedGenre.Key);
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
                    catch (SqlException)
                    {
                        MessageBox.Show("The entered Movie already exits", "Error");
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
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["GenreID"] = "GenreName";
                Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
                attributeNameMap["MovieID"] = "Movie ID";
                attributeNameMap["GenreID"] = "Genre";
                attributeNameMap["PG_Rating"] = "PG Rating";

                DetailsForm detailsForm = new DetailsForm("Movie", ds, selectedRow, foreignKeySchemaNames, attributeNameMap);
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
                        var selectedGenre = (KeyValuePair<int, string>)((ComboBox)data["GenreID"]).SelectedItem;
                        command.Parameters.AddWithValue("@GenreID", selectedGenre.Key);
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
                        catch (SqlException)
                        {
                            MessageBox.Show("The entered Movie already exits", "Error");
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
                MessageBox.Show("Please select a Movie to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete \"{selectedRow.Cells["Title"].Value}\"?", "Delete Movie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;
                

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
                    catch (SqlException)
                    {
                        MessageBox.Show($"\"{selectedRow.Cells["Title"].Value}\" cannot be deleted because of 1 or more Scheduled Movies that are dependent on this Movie. Please delete the corresponding records before attempting to delete this Movie.", "Error");
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
                MessageBox.Show("Please select a Movie to delete.");
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }
    }
}

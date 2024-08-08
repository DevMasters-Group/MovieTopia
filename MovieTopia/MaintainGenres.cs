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
    public partial class MaintainGenres : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        DataSet ds;
        SqlDataAdapter adapter;

        public MaintainGenres()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");

            InitializeComponent();

            this.Resize += Form_Resize;

            LoadMovies();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            lblName.Left = (this.ClientSize.Width - lblName.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width - btnEdit.Width) / 2;
            btnNew.Left = btnEdit.Left - btnEdit.Width - padding;
            btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);
            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void LoadMovies()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                string sqlGenres = @"
                            SELECT
                                g.GenreID, g.GenreName
                            FROM
                                Genre g
                            ;";

                adapter.SelectCommand = new SqlCommand(sqlGenres, conn); ;
                adapter.Fill(ds, "Genre");

                dgvGenres.DataSource = ds;
                dgvGenres.DataMember = "Genre";
            }
        }

        private void AdjustDataGridViewSize()
        {
            dgvGenres.Width = this.ClientSize.Width - (2 * padding);
            dgvGenres.Height = this.ClientSize.Height - (10 * padding);
            dgvGenres.Location = new Point(padding, padding * 3);
        }

        private void AdjustColumnWidths()
        {
            if (dgvGenres.Columns.Count == 0)
                return;

            dgvGenres.Columns["GenreID"].HeaderText = "Genre ID";
            dgvGenres.Columns["GenreName"].HeaderText = "Genre Name";

            dgvGenres.Columns["GenreID"].Width = (int)(dgvGenres.Width * 0.2);
            dgvGenres.Columns["GenreName"].Width = (int)(dgvGenres.Width * 0.8);

            // optionally set specific columns to hidden
            //dgvGenres.Columns["GenreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvGenres.SelectedRows.Count == 1)
            {
                DetailsForm detailsForm = new DetailsForm("Genre", null, null, null);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        INSERT INTO 
                            Genre (
                                GenreName
                            )
                            VALUES
                            (
                                @GenreName
                            );";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@GenreName", ((TextBox)data["GenreName"]).Text);

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
            if (dgvGenres.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvGenres.SelectedRows[0];

                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["GenreID"] = "GenreName";

                DetailsForm detailsForm = new DetailsForm("Genre", ds, selectedRow, foreignKeySchemaNames);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            Genre
                        SET 
                            GenreName = @GenreName
                        WHERE
                            GenreID = @GenreID;
                        ";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@GenreID", ((TextBox)data["GenreID"]).Text);
                        command.Parameters.AddWithValue("@GenreName", ((TextBox)data["GenreName"]).Text);

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
            if (dgvGenres.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvGenres.SelectedRows[0];

                string sql = @"
                        DELETE FROM 
                            Genre
                        WHERE
                            GenreID = @GenreID;";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@GenreID", selectedRow.Cells["GenreID"].Value);

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

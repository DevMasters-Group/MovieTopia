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
        private string tblName = "Genre";
        DataSet ds;
        SqlDataAdapter adapter;

        public MaintainGenres()
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

                string sqlGenres = @"
                            SELECT
                                g.GenreID, g.GenreName
                            FROM
                                Genre g
                            ;";

                adapter.SelectCommand = new SqlCommand(sqlGenres, conn); ;
                adapter.Fill(ds, "Genre");

                //dgvData.DataSource = ds;
                //dgvData.DataMember = "Genre";
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

            dgvData.Columns["GenreID"].HeaderText = "Genre ID";
            dgvData.Columns["GenreName"].HeaderText = "Genre Name";

            dgvData.Columns["GenreID"].Width = (int)(dgvData.Width * 0.2);
            dgvData.Columns["GenreName"].Width = (int)(dgvData.Width * 0.777);

            // optionally set specific columns to hidden
            //dgvData.Columns["GenreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
            attributeNameMap["GenreID"] = "Genre ID";
            attributeNameMap["GenreName"] = "Genre Name";

            DetailsForm detailsForm = new DetailsForm("Genre", null, null, null, attributeNameMap);
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

                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                //Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                //foreignKeySchemaNames["GenreID"] = "GenreName";
                Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
                attributeNameMap["GenreID"] = "Genre ID";
                attributeNameMap["GenreName"] = "Genre Name";

                DetailsForm detailsForm = new DetailsForm("Genre", ds, selectedRow, null, attributeNameMap);
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

                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete \"{selectedRow.Cells["GenreName"].Value}\"?", "Delete Genre", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No) return;

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
                    catch (SqlException)
                    {
                        MessageBox.Show($"\"{selectedRow.Cells["GenreName"].Value}\" cannot be deleted because of 1 or more Movies that are dependent on this Genre. Please delete the corresponding records before attempting to delete this Genre.", "Error");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }

                LoadData();
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

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
    public partial class MaintainTheatres : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        private string tblName = "Theatre";
        DataSet ds;
        SqlDataAdapter adapter;

        public MaintainTheatres()
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

                string sql = @"
                            SELECT
                                t.TheatreID, t.TheatreName, t.Active, t.NumRows, t.NumCols
                            FROM
                                Theatre t;";

                adapter.SelectCommand = new SqlCommand(sql, conn);
                adapter.Fill(ds, "Theatre");

                //dgvData.DataSource = ds;
                //dgvData.DataMember = "Theatre";
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

            dgvData.Columns["TheatreID"].HeaderText = "Theatre ID";
            dgvData.Columns["TheatreName"].HeaderText = "Theatre Name";
            dgvData.Columns["NumRows"].HeaderText = "Number of Rows";
            dgvData.Columns["NumCols"].HeaderText = "Number of Cols";

            dgvData.Columns["TheatreID"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["TheatreName"].Width = (int)(dgvData.Width * 0.377);
            dgvData.Columns["Active"].Width = (int)(dgvData.Width * 0.1);
            dgvData.Columns["NumRows"].Width = (int)(dgvData.Width * 0.2);
            dgvData.Columns["NumCols"].Width = (int)(dgvData.Width * 0.2);

            // optionally set specific columns to hidden
            //dgvData.Columns["GenreID"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
            attributeNameMap["TheatreID"] = "Theatre ID";
            attributeNameMap["TheatreName"] = "Theatre Name";
            attributeNameMap["NumRows"] = "Number of Rows";
            attributeNameMap["NumCols"] = "Number of Columns";

            DetailsForm detailsForm = new DetailsForm("Theatre", ds, null, null, attributeNameMap);
            DialogResult result = detailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Dictionary<string, Control> data = detailsForm.controlsDict;

                string sql = @"
                    INSERT INTO 
                        Theatre (
                            TheatreName,
                            Active,
                            NumRows,
                            NumCols
                        )
                        VALUES
                        (
                            @TheatreName,
                            @Active,
                            @NumRows,
                            @NumCols
                        );";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@TheatreName", ((TextBox)data["TheatreName"]).Text);
                    command.Parameters.AddWithValue("@Active", ((CheckBox)data["Active"]).Checked);
                    command.Parameters.AddWithValue("@NumRows", int.Parse(((NumericUpDown)data["NumRows"]).Text));
                    command.Parameters.AddWithValue("@NumCols", int.Parse(((NumericUpDown)data["NumCols"]).Text));

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Created Successfully", "Success");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("The entered Theatre name already exits", "Error");
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

                Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
                attributeNameMap["TheatreID"] = "Theatre ID";
                attributeNameMap["TheatreName"] = "Theatre Name";
                attributeNameMap["NumRows"] = "Number of Rows";
                attributeNameMap["NumCols"] = "Number of Columns";

                DetailsForm detailsForm = new DetailsForm("Theatre", ds, selectedRow, null, attributeNameMap);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            Theatre
                        SET 
                            TheatreName = @TheatreName,
                            Active = @Active,
                            NumRows = @NumRows,
                            NumCols = @NumCols
                        WHERE
                            TheatreID = @TheatreID;
                        ";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@TheatreID", ((TextBox)data["TheatreID"]).Text);
                        command.Parameters.AddWithValue("@TheatreName", ((TextBox)data["TheatreName"]).Text);
                        command.Parameters.AddWithValue("@Active", ((CheckBox)data["Active"]).Checked);
                        command.Parameters.AddWithValue("@NumRows", int.Parse(((NumericUpDown)data["NumRows"]).Text));
                        command.Parameters.AddWithValue("@NumCols", int.Parse(((NumericUpDown)data["NumCols"]).Text));

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Updated Successfully", "Success");
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("The entered Theatre name already exits", "Error");
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
                MessageBox.Show("Please select a Theatre to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete \"{selectedRow.Cells["TheatreName"].Value}\"?", "Delete Theatre", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.No) return;

                string sql = @"
                        DELETE FROM 
                            Theatre
                        WHERE
                            TheatreID = @TheatreID;";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@TheatreID", selectedRow.Cells["TheatreID"].Value);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Deleted Successfully", "Success");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show($"\"{selectedRow.Cells["TheatreName"].Value}\" cannot be deleted because of 1 or more Scheduled Movies that are dependent on this Theatre. Please delete the corresponding records before attempting to delete this Theatre.", "Error");
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
                MessageBox.Show("Please select a Theatre to delete.");
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

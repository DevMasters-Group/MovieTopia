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

                adapter.SelectCommand = new SqlCommand(sql, conn); ;
                adapter.Fill(ds, "Theatre");

                dgvData.DataSource = ds;
                dgvData.DataMember = "Theatre";
            }
        }

        private void AdjustDataGridViewSize()
        {
            dgvData.Width = this.ClientSize.Width - (2 * padding);
            dgvData.Height = this.ClientSize.Height - (10 * padding);
            dgvData.Location = new Point(padding, padding * 3);
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
            if (dgvData.SelectedRows.Count == 1)
            {
                DetailsForm detailsForm = new DetailsForm("Theatre", ds, null, null);
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                    }

                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];

                DetailsForm detailsForm = new DetailsForm("Theatre", ds, selectedRow, null);
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

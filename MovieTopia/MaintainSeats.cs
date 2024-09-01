using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class MaintainSeats : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
        private string tblName = "Seat";
        DataSet ds;
        SqlDataAdapter adapter;
        SqlDataReader thereader;
        public MaintainSeats()
        {
            DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL");
            InitializeComponent();
            this.Resize += Form_Resize;

            LoadData();
        }
        private void Form_Resize(Object sender, EventArgs e)
        {

            // set buttons and labels accordingly for form resizing
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
                conn.Open();
                adapter= new SqlDataAdapter();
                ds = new DataSet();

                //string sqlTheatres = "SELECT * FROM Theatre";
                //adapter.SelectCommand = new SqlCommand(sqlTheatres, conn);
                //adapter.Fill(ds, "Theatre");

                string sqlseats = @"
                    SELECT
                        s.SeatID, s.SeatRow, s.SeatColumn, CONCAT(s.SeatColumn, s.SeatRow) as CSeat
                    FROM
                        Seat s;";

                adapter.SelectCommand = new SqlCommand(sqlseats, conn);
                adapter.Fill(ds, "Seat");

                //dgvData.DataSource = ds;
                //dgvData.DataMember = "Seat";
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

            dgvData.Columns["SeatID"].HeaderText = "Seat ID";
            //dgvData.Columns["SeatRow"].HeaderText = "Seat Row";
            //dgvData.Columns["SeatColumn"].HeaderText = "Seat Column";
            dgvData.Columns["CSeat"].HeaderText = "Seat";

            dgvData.Columns["SeatID"].Width = (int)(dgvData.Width * 0.2);
            //dgvData.Columns["SeatRow"].Width = (int)(dgvData.Width * 0.388);
            //dgvData.Columns["SeatColumn"].Width = (int)(dgvData.Width * 0.389);
            dgvData.Columns["CSeat"].Width = (int)(dgvData.Width * 0.777);

            // optionally set specific columns to hidden
            dgvData.Columns["SeatRow"].Visible = false;
            dgvData.Columns["SeatColumn"].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> attributeNameMap = new Dictionary<string, string>();
            attributeNameMap["SeatID"] = "Seat ID";
            attributeNameMap["SeatRow"] = "Seat Row";
            attributeNameMap["SeatColumn"] = "Seat Column";

            DetailsForm detailsForm = new DetailsForm("Seat", null, null, null, attributeNameMap);
            DialogResult result = detailsForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Dictionary<string, Control> data = detailsForm.controlsDict;

                string sql = @"
                    INSERT INTO 
                        Seat (
                            SeatRow, SeatColumn
                        )
                        VALUES
                        (
                            @SeatRow, @SeatColumn
                        );";

                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    //command.Parameters.Add("@GenreID", SqlDbType.Int);
                    //command.Parameters["@ID"].Value = customerID;

                    // Use AddWithValue to assign Demographics.
                    // SQL Server will implicitly convert strings into XML.
                    command.Parameters.AddWithValue("@SeatRow", ((NumericUpDown)data["SeatRow"]).Value);
                    command.Parameters.AddWithValue("@SeatColumn", ((TextBox)data["SeatColumn"]).Text);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Created Successfully", "Success");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("The entered Seat already exits", "Error");
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
                attributeNameMap["SeatID"] = "Seat ID";
                attributeNameMap["SeatRow"] = "Seat Row";
                attributeNameMap["SeatColumn"] = "Seat Column";

                DetailsForm detailsForm = new DetailsForm("Seat", ds, selectedRow, null, attributeNameMap);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            Seat
                        SET 
                            SeatRow = @SeatRow,
                            SeatColumn = @SeatColumn
                        WHERE
                            SeatID = @SeatID;
                        ";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@SeatID", ((TextBox)data["SeatID"]).Text);
                        command.Parameters.AddWithValue("@SeatRow", ((NumericUpDown)data["SeatRow"]).Value);
                        command.Parameters.AddWithValue("@SeatColumn", ((TextBox)data["SeatColumn"]).Text);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Updated Successfully", "Success");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("The entered Seat already exits.", "Error");
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
                MessageBox.Show("Please select a Seat to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvData.SelectedRows[0];
                string seatCol = "EMPTY";
                int seatRow = 0;

                string sqlSeats = @"SELECT SeatColumn, SeatRow FROM Seat WHERE SeatID = @SeatID";
                using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlSeats, connection))
                    {
                        command.Parameters.AddWithValue("@SeatID", selectedRow.Cells[0].Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                seatCol = reader["SeatColumn"].ToString();
                                seatRow = Convert.ToInt32(reader["SeatRow"]);
                                reader.Close();
                                connection.Close();
                            }
                            connection.Close();
                        }
                    }
                }

                if (seatCol != "EMPTY" && seatRow != 0)
                {
                    int ColToNum = 0;
                    
                    if (seatCol.Length == 2)
                    {
                        char letter = seatCol[1];
                        ColToNum += (letter - 'A' + 27);
                    }
                    else
                    {
                        char letter = seatCol[0];
                        ColToNum += (letter - 'A' + 1);
                    }

                    string sqlCheck = @"SELECT * FROM Theatre WHERE (@SeatCol BETWEEN 1 AND NumCols) AND NumRows >= @SeatRow";
                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sqlCheck, connection);
                        command.Parameters.AddWithValue("@SeatCol", ColToNum);
                        command.Parameters.AddWithValue("@SeatRow", seatRow);

                        try
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                if (reader.HasRows)
                                {
                                    MessageBox.Show("You can't delete that seat because it is in use by an active theatre");
                                    reader.Close();
                                    connection.Close();
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                            connection.Close();
                            return;
                        }
                    }

                    DialogResult confirm = MessageBox.Show($"Are you sure you want to delete \"{selectedRow.Cells["SeatColumn"].Value}{selectedRow.Cells["SeatRow"].Value}\"?", "Delete Seat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.No) return;

                    string sql = @"
                        DELETE FROM 
                            Seat
                        WHERE
                            SeatID = @SeatID;";

                    using (SqlConnection connection = new SqlConnection(DATABASE_URL))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);
                        //command.Parameters.Add("@GenreID", SqlDbType.Int);
                        //command.Parameters["@ID"].Value = customerID;

                        // Use AddWithValue to assign Demographics.
                        // SQL Server will implicitly convert strings into XML.
                        command.Parameters.AddWithValue("@SeatID", selectedRow.Cells["SeatID"].Value);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully", "Success");
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show($"\"{selectedRow.Cells["SeatColumn"].Value}{selectedRow.Cells["SeatRow"].Value}\" cannot be deleted because it is being referenced by 1 or more Tickets for movies on display, or up-and-coming movies.", "Error");
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
                    MessageBox.Show("Please select a Seat to delete.");
                }
            }
            else
            {
                MessageBox.Show("Please select a Seat to delete.");
            }
        }

        private void btnDisplaySeat_Click(object sender, EventArgs e)
        {
            Avalible_seats avalible_Seats = new Avalible_seats(1);
            this.Hide();
            avalible_Seats.ShowDialog();
            this.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFilter.Text.Replace("[", "").Replace("]", "");
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

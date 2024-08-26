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
    public partial class MaintainSeats : Form
    {
        private string DATABASE_URL;
        private int padding = 20;
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
            
            // Keep the other controls as they are
            lblTheater_num.Left = (this.ClientSize.Width - lblTheater_num.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width - btnEdit.Width) / 2;
            btnNew.Left = btnEdit.Left - btnEdit.Width - padding;
            btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnDaiplaySeat.Left = btnDelete.Left + btnEdit.Width + padding;
            btnReturn.Left = this.ClientSize.Width - btnReturn.Width - padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);
            btnDaiplaySeat.Top = (this.ClientSize.Height - btnDaiplaySeat.Height - padding * 2);
            btnReturn.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);

            cbTeater_Name.Left = (this.ClientSize.Width - cbTeater_Name.Width - padding * 2);
            cbTeater_Name.Top = lblTheater_num.Top + lblTheater_num.Height;
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
                string sqlTheatres = "SELECT * FROM Theatre";
                adapter.SelectCommand = new SqlCommand(sqlTheatres, conn);
                adapter.Fill(ds, "Theatre");

                // Bind the ComboBox to display theater names
                cbTeater_Name.DataSource = ds.Tables["Theatre"];
                cbTeater_Name.DisplayMember = "TheatreName";
                cbTeater_Name.ValueMember = "TheatreID";

                string sqlseats = @"
                            Select
                                s.SeatID, s.SeatRow, s.SeatColumn
                            From
                                Seat s";

                adapter.SelectCommand = new SqlCommand(sqlseats, conn);
                adapter.Fill(ds, "Seat");

                dgvSeat.DataSource = ds;
                dgvSeat.DataMember = "Seat";


                
            }
        }
        private void AdjustDataGridViewSize()
        {
            dgvSeat.Width = this.ClientSize.Width - (2 * padding);
            dgvSeat.Height = this.ClientSize.Height - (10 * padding);
            dgvSeat.Location = new Point(padding, padding * 3);
        }
        private void AdjustColumnWidths()
        {
            if (dgvSeat.Columns.Count == 0)
                return;

            dgvSeat.Columns["SeatID"].HeaderText = "Seat ID";
            dgvSeat.Columns["SeatRow"].HeaderText = "Seat Row";
            dgvSeat.Columns["SeatColumn"].HeaderText = "Seat Column";

            dgvSeat.Columns["SeatID"].Width = (int)(dgvSeat.Width * 0.2);
            dgvSeat.Columns["SeatRow"].Width = (int)(dgvSeat.Width * 0.2);
            dgvSeat.Columns["SeatColumn"].Width = (int)(dgvSeat.Width * 0.2);

            // optionally set specific columns to hidden
            //dgvGenres.Columns["GenreID"].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DetailsForm detailsForm = new DetailsForm("Seat", null, null, null);
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
            if (dgvSeat.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvSeat.SelectedRows[0];

                Dictionary<string, string> foreignKeySchemaNames = new Dictionary<string, string>();
                foreignKeySchemaNames["SeatID"] = "SeatRow" + "SeatColumn";

                DetailsForm detailsForm = new DetailsForm("Seat", ds, selectedRow, foreignKeySchemaNames);
                DialogResult result = detailsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Dictionary<string, Control> data = detailsForm.controlsDict;

                    string sql = @"
                        UPDATE 
                            Seat
                        SET 
                            SeatRow = @SeatRow
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
            if (dgvSeat.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dgvSeat.SelectedRows[0];

                string sql = @"
                        DELETE FROM 
                            Seat
                        WHERE
                            GenreID = @SeatID;";

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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }

                LoadData();
            }
        }

        private void btnDisplaySeat_Click(object sender, EventArgs e)
        {
            Avalible_seats avalible_Seats = new Avalible_seats();
            this.Hide();
            avalible_Seats.ShowDialog();
            this.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}

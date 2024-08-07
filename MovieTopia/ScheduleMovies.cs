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
            LoadMovies();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            // position controls
            lblName.Left = (this.ClientSize.Width - lblName.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width / 2) + padding / 2;
            btnNew.Left = (this.ClientSize.Width / 2) - btnNew.Width - padding / 2;
            //btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            //btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);

            AdjustDataGridViewSize();
            AdjustColumnWidths();
        }

        private void LoadMovies()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                // select the parent table and join any additional fields from child entities
                string sqlMovieSchedules = @"
                            SELECT
                                ms.MovieScheduleID, ms.MovieID, ms.TheatreID, ms.Price, ms.DateTime, m.Title, t.TheatreName
                            FROM
                                MovieSchedule ms
                            JOIN
                                Movie m ON ms.MovieID = m.MovieID
                            JOIN
                                Theatre t ON ms.TheatreID = t.TheatreID";
                // NB: select the ENTIRE child entity and store it in the dataset as well. This is used in the DetailsForm for dropdown boxes
                string sqlMovies = "SELECT * FROM Movie";
                string sqlTheatres = "SELECT * FROM Theatre";

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
            //dgvSchedules.Columns["MovieScheduleID"].HeaderText = "ID";

            // Set DataGridView column widths
            //dgvSchedules.Columns["MovieScheduleID"].Width = (int)(dgvSchedules.Width * 0.1);

            // optionally set specific columns to hidden
            //dgvSchedules.Columns["GenreID"].Visible = false;
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
                    Dictionary<string, Control> controlsDict = detailsForm.controlsDict;
                    // get values from the dictionary - casting is necessary depending on the control that is used for each datatype
                    int MovieID = int.Parse(((ComboBox)controlsDict["MovieID"]).SelectedValue.ToString());

                    MessageBox.Show("Test ID: " + MovieID);

                    // reload the data to the datagrid after SQL queries
                    LoadMovies();
                }
            }
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
                LoadMovies();
            }
        }
    }
}

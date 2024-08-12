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

            //LoadData();
        }
        private void Form_Resize(Object sender, EventArgs e)
        {
            int seatWidth = 40;
            int seatHeight = 40;
            int horizontalSpacing = 10; // Space between seat columns
            int verticalSpacing = 10; // Space between seat rows

            // Calculate the starting positions
            int topPadding = 50; // Distance from the top of the form to the first row of seats
            int leftPadding = (this.ClientSize.Width - (6 * seatWidth + 5 * horizontalSpacing)) / 2;

            // Arrange labels A to F
            lblA.Left = leftPadding;
            lblB.Left = lblA.Left + seatWidth + horizontalSpacing;
            lblC.Left = lblB.Left + seatWidth + horizontalSpacing;
            lblD.Left = lblC.Left + seatWidth + horizontalSpacing;
            lblE.Left = lblD.Left + seatWidth + horizontalSpacing;
            lblF.Left = lblE.Left + seatWidth + horizontalSpacing;

            lblA.Top = topPadding;
            lblB.Top = topPadding;
            lblC.Top = topPadding;
            lblD.Top = topPadding;
            lblE.Top = topPadding;
            lblF.Top = topPadding;

            // Arrange labels 1 to 10
            int numberLeft = lblA.Left - seatWidth; // Align numbers with row labels
            lbl1.Left = numberLeft;
            lbl2.Left = numberLeft;
            lbl3.Left = numberLeft;
            lbl4.Left = numberLeft;
            lbl5.Left = numberLeft;
            lbl6.Left = numberLeft;
            lbl7.Left = numberLeft;
            lbl8.Left = numberLeft;
            lbl9.Left = numberLeft;
            lbl10.Left = numberLeft;

            lbl1.Top = lblA.Top + seatHeight + verticalSpacing;
            lbl2.Top = lbl1.Top + seatHeight + verticalSpacing;
            lbl3.Top = lbl2.Top + seatHeight + verticalSpacing;
            lbl4.Top = lbl3.Top + seatHeight + verticalSpacing;
            lbl5.Top = lbl4.Top + seatHeight + verticalSpacing;
            lbl6.Top = lbl5.Top + seatHeight + verticalSpacing;
            lbl7.Top = lbl6.Top + seatHeight + verticalSpacing;
            lbl8.Top = lbl7.Top + seatHeight + verticalSpacing;
            lbl9.Top = lbl8.Top + seatHeight + verticalSpacing;
            lbl10.Top = lbl9.Top + seatHeight + verticalSpacing;

            // Arrange the PictureBox to align with the seat and row labels
            pictureBox1.Left = lbl1.Left + seatWidth ;
            pictureBox2.Left = lbl2.Left + seatWidth ;
            pictureBox5.Left = lbl3.Left + seatWidth ;
            pictureBox6.Left = lbl4.Left + seatWidth ;
            pictureBox7.Left = lbl5.Left + seatWidth ;
            pictureBox8.Left = lbl6.Left + seatWidth ;
            pictureBox9.Left = lbl7.Left + seatWidth ;
            pictureBox10.Left = lbl8.Left + seatWidth ;
            pictureBox11.Left = lbl9.Left + seatWidth;
            pictureBox12.Left = lbl10.Left + seatWidth;
            pictureBox13.Left = lbl1.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox14.Left = lbl2.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox15.Left = lbl3.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox16.Left = lbl4.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox17.Left = lbl5.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox18.Left = lbl6.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox19.Left = lbl7.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox20.Left = lbl8.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox21.Left = lbl9.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox22.Left = lbl10.Left + seatWidth * 2 + horizontalSpacing;
            pictureBox23.Left = lbl1.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox24.Left = lbl2.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox25.Left = lbl3.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox26.Left = lbl4.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox27.Left = lbl5.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox28.Left = lbl6.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox29.Left = lbl7.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox30.Left = lbl8.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox31.Left = lbl9.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox32.Left = lbl10.Left + seatWidth * 3 + horizontalSpacing * 2;
            pictureBox33.Left = lbl1.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox34.Left = lbl2.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox35.Left = lbl3.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox36.Left = lbl4.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox37.Left = lbl5.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox38.Left = lbl6.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox39.Left = lbl7.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox40.Left = lbl8.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox41.Left = lbl9.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox42.Left = lbl10.Left + seatWidth * 4 + horizontalSpacing * 3;
            pictureBox43.Left = lbl1.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox44.Left = lbl2.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox45.Left = lbl3.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox46.Left = lbl4.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox47.Left = lbl5.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox48.Left = lbl6.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox49.Left = lbl7.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox50.Left = lbl8.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox51.Left = lbl9.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox52.Left = lbl10.Left + seatWidth * 5 + horizontalSpacing * 4;
            pictureBox53.Left = lbl1.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox54.Left = lbl2.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox56.Left = lbl3.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox57.Left = lbl4.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox58.Left = lbl5.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox59.Left = lbl6.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox60.Left = lbl7.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox61.Left = lbl8.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox62.Left = lbl9.Left + seatWidth * 6 + horizontalSpacing * 5;
            pictureBox63.Left = lbl10.Left + seatWidth * 6 + horizontalSpacing * 5;
             
                

            pictureBox1.Top = lbl1.Top;
            pictureBox2.Top = lbl2.Top;
            pictureBox5.Top = lbl3.Top;
            pictureBox6.Top = lbl4.Top;
            pictureBox7.Top = lbl5.Top;
            pictureBox8.Top = lbl6.Top;
            pictureBox9.Top = lbl7.Top;
            pictureBox10.Top = lbl8.Top;
            pictureBox11.Top = lbl9.Top;
            pictureBox12.Top = lbl10.Top;
            pictureBox13.Top = lbl1.Top;
            pictureBox14.Top = lbl2.Top ;
            pictureBox15.Top = lbl3.Top ;
            pictureBox16.Top = lbl4.Top ;
            pictureBox17.Top = lbl5.Top ;
            pictureBox18.Top = lbl6.Top ;
            pictureBox19.Top = lbl7.Top ;
            pictureBox20.Top = lbl8.Top ;
            pictureBox21.Top = lbl9.Top ;
            pictureBox22.Top = lbl10.Top;
            pictureBox23.Top = lbl1.Top ;
            pictureBox24.Top = lbl2.Top ;
            pictureBox25.Top = lbl3.Top ;
            pictureBox26.Top = lbl4.Top ;
            pictureBox27.Top = lbl5.Top ;
            pictureBox28.Top = lbl6.Top ;
            pictureBox29.Top = lbl7.Top ;
            pictureBox30.Top = lbl8.Top ;
            pictureBox31.Top = lbl9.Top ;
            pictureBox32.Top = lbl10.Top ;
            pictureBox33.Top = lbl1.Top ;
            pictureBox34.Top = lbl2.Top ;
            pictureBox35.Top = lbl3.Top ;
            pictureBox36.Top = lbl4.Top ;
            pictureBox37.Top = lbl5.Top ;
            pictureBox38.Top = lbl6.Top ;
            pictureBox39.Top = lbl7.Top ;
            pictureBox40.Top = lbl8.Top ;
            pictureBox41.Top = lbl9.Top ;
            pictureBox42.Top = lbl10.Top;
            pictureBox43.Top = lbl1.Top ;
            pictureBox44.Top = lbl2.Top ;
            pictureBox45.Top = lbl3.Top ;
            pictureBox46.Top = lbl4.Top ;
            pictureBox47.Top = lbl5.Top ;
            pictureBox48.Top = lbl6.Top ;
            pictureBox49.Top = lbl7.Top ;
            pictureBox50.Top = lbl8.Top ;
            pictureBox51.Top = lbl9.Top ;
            pictureBox52.Top = lbl10.Top;
            pictureBox53.Top = lbl1.Top ;
            pictureBox54.Top = lbl2.Top ;
            pictureBox56.Top = lbl3.Top ;
            pictureBox57.Top = lbl4.Top ;
            pictureBox58.Top = lbl5.Top ;
            pictureBox59.Top = lbl6.Top ;
            pictureBox60.Top = lbl7.Top ;
            pictureBox61.Top = lbl8.Top ;
            pictureBox62.Top = lbl9.Top ;
            pictureBox63.Top = lbl10.Top ;
           


            // Center the stage label at the bottom
            lblStage.Left = (this.ClientSize.Width - lblStage.Width) / 2;
            lblStage.Top = lbl10.Top + seatHeight + verticalSpacing * 2;

            // Keep the other controls as they are
            lblTheater_num.Left = (this.ClientSize.Width - lblTheater_num.Width) / 2;
            btnEdit.Left = (this.ClientSize.Width - btnEdit.Width) / 2;
            btnNew.Left = btnEdit.Left - btnEdit.Width - padding;
            btnDelete.Left = btnEdit.Left + btnEdit.Width + padding;
            btnNew.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnEdit.Top = (this.ClientSize.Height - btnEdit.Height - padding * 2);
            btnDelete.Top = (this.ClientSize.Height - btnDelete.Height - padding * 2);
        }




        private void laodSeats()
        {
            using (SqlConnection conn = new SqlConnection(DATABASE_URL))
            {
                conn.Open();
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                string sql = @"
                            SELECT
                                s.SeatID, s.SeatNumber, s.RowNumber, s.ColumnNumber, s.Active
                            FROM
                                Seat s;";

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /**
private void LoadData()
{
   using (SqlConnection conn = new SqlConnection(DATABASE_URL))
   {
       conn.Open();
       ds = new DataSet();
       adapter = new SqlDataAdapter();

       string sql = @"
                   SELECT
                       t.TheatreID, t.TheatreName, t.Active, t.NumRows, t.NumCols
                   FROM
                       Theatre t;";
       

       adapter.SelectCommand = new SqlCommand(sql, conn);
       thereader =  adapter.SelectCommand.ExecuteReader();
       //adapter.Fill(ds, "Theatre");
       lblTheater_num.Text = $"{thereader.GetString(1)}";

       conn.Close();
   }
}
*/

    }
    
}

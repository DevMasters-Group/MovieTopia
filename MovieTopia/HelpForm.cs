using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class HelpForm : Form
    {
        private int padding = 20;

        public HelpForm()
        {
            InitializeComponent();

            this.Resize += Form_Resize;
            this.Width = 800;
            this.Height = 600;

            // Set the documentation text
            string helpText = "The below information describes the use of and flow of this form.\r\n\r\n" +
                              "1. Use the Filter box to search for movies.\r\n" +
                              "2. Click 'New' to add a new movie.\r\n" +
                              "3. Select a movie and click 'Edit' to modify it.\r\n" +
                              "4. Select a movie and click 'Delete' to remove it.\r\n" +
                              "5. Use the 'Return' button to go back to the previous screen.\r\n\r\n" +
                              "Note:\r\n" +
                              "Ensure you enter information for all the required fields when adding or editing a movie.\r\n" +
                              "Movies cannot be deleted if they have been referenced or used for a Movie Schedule. The Movie Schedule and it's dependents (Tickets), must first be deleted before attempting to delete a movie.";

            txtHelp.Text = helpText;
            txtHelp.Multiline = true;
            txtHelp.ReadOnly = true; // Make the TextBox read-only
            //txtHelp.ScrollBars = ScrollBars.Vertical; // Enable scrolling
            txtHelp.Font = new Font("Arial", 12, FontStyle.Regular);
        }

        private void Form_Style()
        {
            txtHelp.Multiline = true;
            txtHelp.Width = this.ClientSize.Width - padding * 4;
            txtHelp.Height = this.ClientSize.Height - padding * 4 - btnClose.Height;
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            btnClose.Left = (this.ClientSize.Width - btnClose.Width) / 2;
            btnClose.Top = (this.ClientSize.Height - btnClose.Height - padding * 2);

            txtHelp.Location = new Point(padding * 2, padding);

            Form_Style();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

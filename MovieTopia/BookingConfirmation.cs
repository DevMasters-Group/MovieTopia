using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTopia
{
    public partial class BookingConfirmation : Form
    {
        private DataGridViewRow selectedRow;
        private Dictionary<int, string> selectedSeats = new Dictionary<int, string>();
        private int padding = 20;

        public BookingConfirmation(DataGridViewRow selectedRow, Dictionary<int, string> selectedSeats)
        {
            InitializeComponent();

            this.FormClosing += BookingConfirmation_FormClosing;
            this.Resize += Form_Resize;

            this.selectedRow = selectedRow;
            this.selectedSeats = selectedSeats;

            LoadData();
            Validators();
        }

        private void Form_Resize(Object sender, EventArgs e)
        {
            FormAlignment();
        }

        private void Validators()
        {
            txtFName.Validating += new CancelEventHandler(textBox_Validating);
            txtLName.Validating += new CancelEventHandler(textBox_Validating);
            txtPhoneNumber.Validating += new CancelEventHandler(textBoxPhoneNumber_Validating);
        }

        private void LoadData()
        {
            decimal price = (decimal)selectedRow.Cells["Price"].Value;
            decimal grandTotal = selectedSeats.Count * price;

            lblMovie.Text = selectedRow.Cells["Title"].Value.ToString();
            lblDuration.Text = selectedRow.Cells["Duration"].Value.ToString() + " minutes";
            lblDateTime.Text = selectedRow.Cells["DateTime"].Value.ToString();
            lblTheatre.Text = selectedRow.Cells["TheatreName"].Value.ToString();
            lblTotalSeats.Text = selectedSeats.Count.ToString();
            lblPrice.Text = price.ToString("C2");
            lblGrandTotal.Text = grandTotal.ToString("C2");


            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in selectedSeats)
            {
                // Append the key and value, followed by a comma
                stringBuilder.Append($"{item.Value}, ");
            }
            string seats = stringBuilder.ToString();
            if (seats.Length > 2)
            {
                seats = seats.Substring(0, seats.Length - 2);
            }
            txtSelected.Text = seats;
        }

        private void FormAlignment()
        {
            txtSelected.Width = 280;
            txtSelected.Height = 200;
            txtSelected.Multiline = true;

            lblTotalSeats.Width = 280;
            lblPrice.Width = 280;
            lblGrandTotal.Width = 280;

            lblFormName.Left = (this.ClientSize.Width - lblFormName.Width) / 2;
            gbxMDetails.Left = this.ClientSize.Width / 2 - gbxMDetails.Width - padding / 2;
            gbxCDetails.Left = this.ClientSize.Width / 2 - gbxCDetails.Width - padding / 2;
            gbxSeatsTotal.Left = (this.ClientSize.Width + padding) / 2;

            btnContinue.Left = this.ClientSize.Width / 2 - btnContinue.Width - padding / 2;
            btnCancel.Left = this.ClientSize.Width / 2 + padding / 2;
            btnContinue.Top = gbxSeatsTotal.Bottom + padding * 2;
            btnCancel.Top = gbxSeatsTotal.Bottom + padding * 2;
        }

        /// <summary>
        /// Validates the TextBox value to prevent blank or whitespace entries
        /// </summary>
        /// <param name="sender">The control.</param>
        /// <param name="e">The CancelEventsArgs.</param>
        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrWhiteSpace(tb.Text) || string.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetIconPadding(tb, padding);
                errorProvider1.SetError(tb, "This field is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tb, "");
            }
        }

        /// <summary>
        /// Validates the TextBox value to prevent blank or whitespace entries
        /// </summary>
        /// <param name="sender">The control.</param>
        /// <param name="e">The CancelEventsArgs.</param>
        private void textBoxPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Regex expr = new Regex(@"^\d{10}$");
            if (string.IsNullOrWhiteSpace(tb.Text) || string.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetIconPadding(tb, padding);
                errorProvider1.SetError(tb, "This field is required.");
                e.Cancel = true;
            }
            else if (!expr.IsMatch(tb.Text))
            {
                errorProvider1.SetIconPadding(tb, padding);
                errorProvider1.SetError(tb, "Please enter a valid 10-digit phone number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tb, "");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel your booking?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter values for all the required fields");
            }
        }

        private void BookingConfirmation_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the form is closing due to user clicking the close button
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Allow form to close without validation if the close button was clicked
                return;
            }

            if (!this.ValidateChildren(ValidationConstraints.Enabled))
            {
                e.Cancel = true;
                //MessageBox.Show("Please correct the validation errors before closing the form.");
            }
        }

        private void txtPhoneNumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and not a control key (e.g., backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }
    }
}

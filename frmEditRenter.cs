using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmEditRenter : Form
    {
        // Constructor that accepts the selected row data from frmRenters
        public frmEditRenter(string rentersName, string emailAddress, string phoneNumber, string address)
        {
            InitializeComponent();
            textBox1.Text = rentersName;  // Renters Name
            textBox2.Text = emailAddress; // Email Addressa
            textBox3.Text = phoneNumber;  // Phone Number
            textBox4.Text = address;      // Address

            // Set email and phone number text boxes as read-only
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close this modal?",
                "Confirm Close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the updated values from the text boxes
            string updatedRentersName = textBox1.Text;
            string updatedEmailAddress = textBox2.Text;  // Email Address will not be updated, just for WHERE
            string updatedPhoneNumber = textBox3.Text;   // Phone Number will not be updated
            string updatedAddress = textBox4.Text;

            // Check if all fields are filled
            if (string.IsNullOrEmpty(updatedRentersName) || string.IsNullOrEmpty(updatedEmailAddress) ||
                string.IsNullOrEmpty(updatedPhoneNumber) || string.IsNullOrEmpty(updatedAddress))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to update renter details excluding email and phone number
            string query = "UPDATE customers SET renters_name = @renters_name, address = @address WHERE email_address = @email";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            // Add parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@renters_name", updatedRentersName);
            cmd.Parameters.AddWithValue("@email", updatedEmailAddress);  // The WHERE clause checks for the correct email
            cmd.Parameters.AddWithValue("@address", updatedAddress);

            try
            {
                // Executes the update query
                db.ExecuteQuery(cmd);

                // Show success message
                MessageBox.Show("Renter details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form after updating
                this.Close();
            }
            catch (Exception ex)
            {
                // If there is an error, show the error message
                MessageBox.Show("Error: " + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close this modal?",
                "Confirm Close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();  
            }
        }
    }
}

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
    public partial class frmAddRenter : Form
    {
        public frmAddRenter()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                this.Close();  // Close the form if the user confirms
            }
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
                this.Close();  // Close the form if the user confirms
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            // Get the input data from the form fields (based on your exact field names)
            string rentersName = textBox1.Text;   // Renters name
            string email = textBox2.Text;          // Email address
            string phoneNumber = textBox3.Text;    // Phone number
            string address = textBox4.Text;        // Address

            // Validate that the required fields are not empty
            if (string.IsNullOrEmpty(rentersName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL query to insert the renter data into the customers table
            string query = "INSERT INTO customers (renters_name, email_address, phone_number, address) " +
                           "VALUES (@renters_name, @email, @phone, @address)";

            // Create a new MySqlCommand
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@renters_name", rentersName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phoneNumber);
            cmd.Parameters.AddWithValue("@address", address);

            try
            {
                // Execute the query to insert the new renter into the database
                db.ExecuteQuery(cmd);

                // Inform the user that the renter was added successfully
                MessageBox.Show("Renter added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the modal form (frmAddRenter)
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the database operation
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

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
    public partial class frmCreateAccount : Form
    {
        private bool isPasswordVisible = false;
        public frmCreateAccount()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capture the input data from the form
            string name = textBox3.Text; // Name
            string birthday = dateTimePicker2.Value.ToString("yyyy-MM-dd"); // Birthday
            string email = textBox4.Text; // Email
            string phoneNumber = textBox1.Text; // Phone Number
            string password = textBox2.Text; // Password

            // Check if any required field is empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                // Show an error message if any field is empty
                MessageBox.Show("Please fill in all the fields to create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution if fields are empty
            }

            // Check if the email or phone number already exists in the database
            string queryCheck = "SELECT COUNT(*) FROM users WHERE email_address = @email OR phone_number = @phone";
            DatabaseConnection dbCheck = new DatabaseConnection();
            MySqlCommand cmdCheck = new MySqlCommand(queryCheck);
            cmdCheck.Parameters.AddWithValue("@email", email);
            cmdCheck.Parameters.AddWithValue("@phone", phoneNumber);

            try
            {
                MySqlDataReader readerCheck = dbCheck.ExecuteSelectQuery(cmdCheck);

                if (readerCheck != null && readerCheck.Read() && readerCheck.GetInt32(0) > 0)
                {
                    // Show error message if email or phone number already exists
                    MessageBox.Show("This email or phone number is already in use. Please use a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hash the password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // SQL query to insert the data into the users table
                string query = "INSERT INTO users (name, birthday, email_address, phone_number, password_hash, created_at, modified_at) " +
                               "VALUES (@name, @birthday, @email, @phone, @password, NOW(), NOW())";

                // Create a connection and execute the query
                DatabaseConnection db = new DatabaseConnection();
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@birthday", birthday);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phoneNumber);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                db.ExecuteQuery(cmd); // Execute the query to insert data into the table

                // Notify user of successful account creation
                DialogResult result = MessageBox.Show(
                    "Account Successfully Created",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.OK)
                {
                    // Open login form
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    this.Hide(); // Hide current form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                textBox2.UseSystemPasswordChar = true;
                pictureBox3.Image = Properties.Resources.eye_open;
                isPasswordVisible = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                pictureBox3.Image = Properties.Resources.eye_closed;
                isPasswordVisible = true;
            }
        }
    }
}

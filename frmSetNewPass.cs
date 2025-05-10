using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dotenv.net;
using MySql.Data.MySqlClient;


namespace EDP_WinProject102__WearRent_
{
    public partial class frmSetNewPass : Form
    {
        private string userEmail;  // Store the email passed from frmSetCode
        private bool isPasswordVisible = false;
        public frmSetNewPass()
        {
            InitializeComponent();
        }
        public frmSetNewPass(string email)
        {
            InitializeComponent();
            userEmail = email;  // Store the passed email
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the values from the password and confirm password textboxes
            string password = textBox1.Text;
            string confirmPassword = textBox2.Text;

            // Validate that the passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("The passwords do not match. Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate that the password meets the criteria (8 characters and at least one special character)
            if (!IsPasswordValid(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one special character.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password using BCrypt before storing it in the database
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // If validation passes, update the password in the database
            string query = "UPDATE users SET password_hash = @password WHERE email_address = @email"; // Correct column name is password_hash
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@password", hashedPassword);  // Update the hashed password
            cmd.Parameters.AddWithValue("@email", userEmail);
            try
            {
                db.ExecuteQuery(cmd);  // Execute the query to update the password

                // Inform the user that the password has been changed
                MessageBox.Show("Your password has been successfully reset.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to login screen
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to validate password
        private bool IsPasswordValid(string password)
        {
            // Check that the password is at least 8 characters long
            if (password.Length < 8)
                return false;

            // Check that the password contains at least one special character
            string specialCharacters = @"!@#$%^&*()_+[]{}|;:,.<>?";
            foreach (char c in specialCharacters)
            {
                if (password.Contains(c))
                    return true;
            }

            return false;
        }



        private void label4_Click(object sender, EventArgs e)
        {
            frmSetCode setCodeForm = new frmSetCode();
            setCodeForm.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmSetCode setCodeForm = new frmSetCode();
            setCodeForm.Show();
            this.Hide();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

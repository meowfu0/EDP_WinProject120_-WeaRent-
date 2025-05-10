﻿using System;
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
    public partial class frmLogin : Form
    {
        private bool isPasswordVisible = false;
        public frmLogin()
        {
            InitializeComponent();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
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

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;  // Email or Phone
            string password = textBox2.Text;  // Password

            // Check if both fields are filled in
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email/phone number and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL query to check if the user exists based on email or phone number
            string query = "SELECT password_hash FROM users WHERE email_address = @username OR phone_number = @username";
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                // Create a MySqlCommand object
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@username", username);  // Add the parameter for email/phone

                // Pass the MySqlCommand object to ExecuteSelectQuery method
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);

                // Check if the user exists
                if (reader != null && reader.HasRows)
                {
                    reader.Read();  // Read the first (and only) row
                    string storedPasswordHash = reader["password_hash"].ToString();  // Retrieve the stored hashed password

                    // Check if the entered password matches the stored hash using BCrypt
                    if (BCrypt.Net.BCrypt.Verify(password, storedPasswordHash))
                    {
                        // If the password matches, login is successful
                        DialogResult result;
                        if (chkRememberMe.Checked)
                        {
                            result = MessageBox.Show("Login with Remember Me checked.", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            result = MessageBox.Show("Login without remembering.", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (result == DialogResult.OK)
                        {
                            // Open the Dashboard
                            frmDashboard dashboard = new frmDashboard();
                            dashboard.Show();
                            this.Hide(); // Hide current form
                        }
                    }
                    else
                    {
                        // Incorrect password
                        MessageBox.Show("Invalid password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // No user found with the provided email or phone number
                    MessageBox.Show("No account found with that email or phone number. Please create an account.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label3_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            frmForgotPassword forgotPasswordForm = new frmForgotPassword();
            forgotPasswordForm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frmCreateAccount createAccountForm = new frmCreateAccount();
            createAccountForm.Show();
            this.Hide(); 
        }

    }
}


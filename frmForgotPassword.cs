﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using dotenv.net;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }
        private void SendResetCode(string userEmail)
        {
            Random rand = new Random();
            string resetCode = rand.Next(10000, 99999).ToString(); 

            try
            {
                string smtpUser = "wearentofficialacc@gmail.com";
                string smtpPassword = "qnci cckt hwcp jsvz";      

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com") 
                {
                    Port = 587,
                    Credentials = new NetworkCredential(smtpUser, smtpPassword),  
                    EnableSsl = true
                };
                // Prepare the email message with HTML content
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUser),  // Use the sending email
                    Subject = "Password Reset Request",
                    Body = $@"
        <html>
        <body>
            <h2 style='color: #4CAF50;'>Password Reset Request</h2>
            <p>Hello,</p>
            <p>We received a request to reset your password for your account.</p>

            <p style='font-size: 20px; font-weight: bold; color: #FF5733;'>Your password reset code is: <strong>{resetCode}</strong></p>

            <p>Please enter this code in the password reset form on the application to proceed with resetting your password.</p>

            <p><strong>Note:</strong> This code is valid for <strong>15 minutes</strong>. If you do not complete the process within that time, you may need to request a new reset code.</p>

            <p>If you did not request a password reset, please ignore this email.</p>

            <p>Thank you,<br>The WearRent Team</p>
        </body>
        </html>
    ",
                    IsBodyHtml = true, // Set to true to send HTML-formatted emails
                };


                // Send to the user's email address
                mailMessage.To.Add(userEmail); // userEmail is the email entered by the user

                // Send the email
                smtpClient.Send(mailMessage);

                // Store the reset code and expiration timestamp in the database
                string query = "UPDATE users SET reset_code = @resetCode, reset_code_expiration = NOW() + INTERVAL 15 MINUTE WHERE email_address = @userEmail";
                DatabaseConnection db = new DatabaseConnection();
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@resetCode", resetCode);
                cmd.Parameters.AddWithValue("@userEmail", userEmail);

                db.ExecuteQuery(cmd); // Execute the query to update the reset code and expiration time in the database

                // Inform the user that the email has been sent
                MessageBox.Show("A reset code has been sent to your email. Please check your inbox.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Proceed to the form where the user will enter the reset code
                frmSetCode setCodeForm = new frmSetCode();  // Create the verification form
                setCodeForm.Show();  // Show the form to enter the code
                this.Hide();  // Hide the current form (Forgot Password form)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text; // Get the entered email

            // Check if email is empty
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the email exists in the database
            string query = "SELECT COUNT(*) FROM users WHERE email_address = @email";
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", email);

            try
            {
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);

                if (reader != null && reader.Read() && reader.GetInt32(0) > 0)
                {
                    // Email exists, send reset code to email
                    SendResetCode(email); // This will send the reset code to the user's email

                    // Pass the email to the next form (frmSetCode)
                    frmSetCode setCodeForm = new frmSetCode(email);  // Pass the email to frmSetCode
                    setCodeForm.Show();
                    this.Hide(); // Hide the current form (Forgot Password form)
                }
                else
                {
                    // If email does not exist, show an error message
                    MessageBox.Show("No account found with that email address. Please check and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

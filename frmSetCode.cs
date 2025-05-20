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
using dotenv.net;


namespace EDP_WinProject102__WearRent_
{
    public partial class frmSetCode : Form
    {
        private string userEmail;  
        public frmSetCode()
        {
            InitializeComponent();
        }
        public frmSetCode(string email)
        {
            InitializeComponent();
            userEmail = email; 
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmForgotPassword forgotPasswordForm = new frmForgotPassword();
            forgotPasswordForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frmForgotPassword forgotPasswordForm = new frmForgotPassword();
            forgotPasswordForm.Show();
            this.Hide(); 
        }
        private string GetEnteredCode()
        {
            return textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredCode = GetEnteredCode();  
            if (enteredCode.Length != 5)
            {
                MessageBox.Show("Please enter a valid 5-digit code.", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "SELECT reset_code, email_address FROM users WHERE reset_code = @resetCode";
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@resetCode", enteredCode);  

            try
            {
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);

                if (reader != null && reader.Read())
                {
                    string userEmail = reader["email_address"].ToString();  
                    frmSetNewPass setNewPassForm = new frmSetNewPass(userEmail); 
                    setNewPassForm.Show();
                    this.Hide();  
                }
                else
                {
                    MessageBox.Show("The code you entered is incorrect. Please try again.", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error validating the code: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
            string name = textBox3.Text; 
            string birthday = dateTimePicker2.Value.ToString("yyyy-MM-dd"); 
            string email = textBox4.Text;
            string phoneNumber = textBox1.Text;
            string password = textBox2.Text; 

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(birthday) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all the fields to create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

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
                    MessageBox.Show("This email or phone number is already in use. Please use a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                string query = "INSERT INTO users (name, birthday, email_address, phone_number, password_hash, created_at, modified_at) " +
                               "VALUES (@name, @birthday, @email, @phone, @password, NOW(), NOW())";

                DatabaseConnection db = new DatabaseConnection();
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@birthday", birthday);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phoneNumber);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                db.ExecuteQuery(cmd); 

                DialogResult result = MessageBox.Show(
                    "Account Successfully Created",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.OK)
                {
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    this.Hide(); 
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

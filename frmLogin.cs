using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Simulate successful login
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
                frmDashboard dashboard = new frmDashboard();
                dashboard.Show();
                this.Hide();
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

    }
}


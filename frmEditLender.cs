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
    public partial class frmEditLender : Form
    {
        public frmEditLender(string lendersName, string emailAddress, string phoneNumber, string address)
        {
            InitializeComponent();
            textBox1.Text = lendersName;  
            textBox2.Text = emailAddress;
            textBox3.Text = phoneNumber;  
            textBox4.Text = address;      
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updatedLendersName = textBox1.Text;
            string updatedEmailAddress = textBox2.Text;  
            string updatedPhoneNumber = textBox3.Text;   
            string updatedAddress = textBox4.Text;

            if (string.IsNullOrEmpty(updatedLendersName) || string.IsNullOrEmpty(updatedEmailAddress) ||
                string.IsNullOrEmpty(updatedPhoneNumber) || string.IsNullOrEmpty(updatedAddress))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE lenders SET lenders_name = @lenders_name, address = @address WHERE email_address = @email";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.AddWithValue("@lenders_name", updatedLendersName);
            cmd.Parameters.AddWithValue("@email", updatedEmailAddress);  
            cmd.Parameters.AddWithValue("@address", updatedAddress);

            try
            {
                db.ExecuteQuery(cmd);
                MessageBox.Show("Lender details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
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
    }
}

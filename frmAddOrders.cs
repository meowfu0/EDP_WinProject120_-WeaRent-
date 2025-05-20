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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmAddOrders : Form
    {
        public frmAddOrders()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string renterName = textBox1.Text;   
            string clothesName = textBox2.Text;   
            DateTime orderDate = dateTimePicker1.Value; 
            DateTime returnDate = dateTimePicker2.Value;
            string lenderName = textBox5.Text;    
            int quantity = Convert.ToInt32(textBox6.Text); 
            decimal rentalPrice = 0;  
            decimal totalPrice = 0; 

            if (!decimal.TryParse(textBox9.Text, out rentalPrice))
            {
                MessageBox.Show("Please enter a valid rental price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentStatus = textBox7.Text; 

            if (string.IsNullOrEmpty(renterName) || string.IsNullOrEmpty(clothesName) ||
                string.IsNullOrEmpty(lenderName) || string.IsNullOrEmpty(paymentStatus) ||
                quantity <= 0 || rentalPrice <= 0)
            {
                MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            totalPrice = rentalPrice * quantity;

            string query = "INSERT INTO orders (renter_name, clothes_name, order_date, return_date, lender_name, quantity, rental_price, total_price, payment_status) " +
                           "VALUES (@renter_name, @clothes_name, @order_date, @return_date, @lender_name, @quantity, @rental_price, @total_price, @payment_status)";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@renter_name", renterName);
            cmd.Parameters.AddWithValue("@clothes_name", clothesName);
            cmd.Parameters.AddWithValue("@order_date", orderDate);  
            cmd.Parameters.AddWithValue("@return_date", returnDate); 
            cmd.Parameters.AddWithValue("@lender_name", lenderName);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@rental_price", rentalPrice);
            cmd.Parameters.AddWithValue("@total_price", totalPrice);  
            cmd.Parameters.AddWithValue("@payment_status", paymentStatus);

            try
            {
                db.ExecuteQuery(cmd);
                MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice(); 
        }


        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();  
        }

        private void CalculateTotalPrice()
        {
            int quantity;
            decimal rentalPrice;

            if (int.TryParse(textBox6.Text, out quantity) && decimal.TryParse(textBox9.Text, out rentalPrice))
            {
                decimal totalPrice = quantity * rentalPrice;
                textBox8.Text = totalPrice.ToString("F2");  
            }
            else
            {
                textBox8.Text = "";
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

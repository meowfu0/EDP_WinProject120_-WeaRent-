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
    public partial class frmEditOrders : Form
    {
        public frmEditOrders(string renterName, string clothesName, DateTime orderDate, DateTime returnDate, string lenderName, int quantity, decimal rentalPrice, decimal totalPrice, string paymentStatus)
        {
            InitializeComponent();
            textBox1.Text = renterName;  
            textBox2.Text = clothesName; 
            dateTimePicker1.Value = orderDate;  
            dateTimePicker2.Value = returnDate; 
            textBox5.Text = lenderName; 
            textBox6.Text = quantity.ToString();  
            textBox9.Text = rentalPrice.ToString("F2");
            textBox8.Text = totalPrice.ToString("F2");  
            textBox7.Text = paymentStatus; 
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

            string query = "UPDATE orders SET renter_name = @renter_name, clothes_name = @clothes_name, order_date = @order_date, return_date = @return_date, lender_name = @lender_name, quantity = @quantity, rental_price = @rental_price, total_price = @total_price, payment_status = @payment_status WHERE renter_name = @renter_name AND clothes_name = @clothes_name AND order_date = @order_date";

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
                MessageBox.Show("Order details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CalculateTotalPrice()
        {
            if (int.TryParse(textBox6.Text, out int quantity) && decimal.TryParse(textBox9.Text, out decimal rentalPrice))
            {
                decimal totalPrice = quantity * rentalPrice;  
                textBox8.Text = totalPrice.ToString("F2"); 
            }
            else
            {
                textBox8.Text = "0.00";  
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();  
        }


        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();  
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

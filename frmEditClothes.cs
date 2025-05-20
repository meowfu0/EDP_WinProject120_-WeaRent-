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
    public partial class frmEditClothes : Form
    {
        public frmEditClothes(string clothesName, string size, string color, string rentalPrice, string category, string lenderName)
        {
            InitializeComponent();
            textBox1.Text = clothesName;
            textBox2.Text = size;
            textBox3.Text = color;
            textBox4.Text = rentalPrice;
            textBox5.Text = category;
            textBox6.Text = lenderName;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updatedClothesName = textBox1.Text;
            string updatedSize = textBox2.Text;
            string updatedColor = textBox3.Text;
            string updatedRentalPrice = textBox4.Text;
            string updatedCategory = textBox5.Text;
            string updatedLenderName = textBox6.Text;

            if (string.IsNullOrEmpty(updatedClothesName) || string.IsNullOrEmpty(updatedSize) ||
                string.IsNullOrEmpty(updatedColor) || string.IsNullOrEmpty(updatedRentalPrice) ||
                string.IsNullOrEmpty(updatedCategory) || string.IsNullOrEmpty(updatedLenderName))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE clothes SET name = @name, size = @size, color = @color, rental_price = @rental_price, category_name = @category_name, lender_name = @lender_name WHERE name = @original_name";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.AddWithValue("@name", updatedClothesName);
            cmd.Parameters.AddWithValue("@size", updatedSize);
            cmd.Parameters.AddWithValue("@color", updatedColor);
            cmd.Parameters.AddWithValue("@rental_price", updatedRentalPrice);
            cmd.Parameters.AddWithValue("@category_name", updatedCategory);
            cmd.Parameters.AddWithValue("@lender_name", updatedLenderName);
            cmd.Parameters.AddWithValue("@original_name", textBox1.Text);  

            try
            {
                db.ExecuteQuery(cmd);
                MessageBox.Show("Clothes details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

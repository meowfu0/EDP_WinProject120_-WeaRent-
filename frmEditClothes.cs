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
        // Constructor that accepts the selected row data from frmClothes
        public frmEditClothes(string clothesName, string size, string color, string rentalPrice, string category, string lenderName)
        {
            InitializeComponent();

            // Set the TextBox values to the passed data
            textBox1.Text = clothesName;  // Clothes Name
            textBox2.Text = size;         // Size
            textBox3.Text = color;        // Color
            textBox4.Text = rentalPrice;  // Rental Price
            textBox5.Text = category;     // Category
            textBox6.Text = lenderName;   // Lender Name
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

        // Update button click - update the clothes data in the database
        private void button1_Click(object sender, EventArgs e)
        {
            string updatedClothesName = textBox1.Text;
            string updatedSize = textBox2.Text;
            string updatedColor = textBox3.Text;
            string updatedRentalPrice = textBox4.Text;
            string updatedCategory = textBox5.Text;
            string updatedLenderName = textBox6.Text;

            // Validate that the fields are not empty
            if (string.IsNullOrEmpty(updatedClothesName) || string.IsNullOrEmpty(updatedSize) ||
                string.IsNullOrEmpty(updatedColor) || string.IsNullOrEmpty(updatedRentalPrice) ||
                string.IsNullOrEmpty(updatedCategory) || string.IsNullOrEmpty(updatedLenderName))
            {
                MessageBox.Show("Please fill in all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to update clothes data
            string query = "UPDATE clothes SET name = @name, size = @size, color = @color, rental_price = @rental_price, category_name = @category_name, lender_name = @lender_name WHERE name = @original_name";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            // Add parameters to avoid SQL injection
            cmd.Parameters.AddWithValue("@name", updatedClothesName);
            cmd.Parameters.AddWithValue("@size", updatedSize);
            cmd.Parameters.AddWithValue("@color", updatedColor);
            cmd.Parameters.AddWithValue("@rental_price", updatedRentalPrice);
            cmd.Parameters.AddWithValue("@category_name", updatedCategory);
            cmd.Parameters.AddWithValue("@lender_name", updatedLenderName);
            cmd.Parameters.AddWithValue("@original_name", textBox1.Text);  // The WHERE clause checks for the original name

            try
            {
                // Execute the update query
                db.ExecuteQuery(cmd);

                // Show success message
                MessageBox.Show("Clothes details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form after updating
                this.Close();
            }
            catch (Exception ex)
            {
                // If there is an error, show the error message
                MessageBox.Show("Error: " + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

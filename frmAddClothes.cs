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
    public partial class frmAddClothes : Form
    {
        public frmAddClothes()
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
            // Get the input data from the form fields
            string clothesName = textBox1.Text;   // Clothes name
            string size = textBox2.Text;          // Size
            string color = textBox3.Text;         // Color
            string rentalPrice = textBox4.Text;   // Rental price
            string category = textBox5.Text;      // Category
            string lenderName = textBox6.Text;    // Lender's name

            // Validate that the required fields are not empty
            if (string.IsNullOrEmpty(clothesName) || string.IsNullOrEmpty(size) || string.IsNullOrEmpty(color) ||
                string.IsNullOrEmpty(rentalPrice) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(lenderName))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL query to insert the clothes data into the clothes table
            string query = "INSERT INTO clothes (name, size, color, rental_price, category_name, lender_name) " +
                           "VALUES (@name, @size, @color, @rental_price, @category_name, @lender_name)";

            // Create a new MySqlCommand
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@name", clothesName);
            cmd.Parameters.AddWithValue("@size", size);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@rental_price", rentalPrice);
            cmd.Parameters.AddWithValue("@category_name", category);
            cmd.Parameters.AddWithValue("@lender_name", lenderName);

            try
            {
                // Execute the query to insert the new clothes item into the database
                db.ExecuteQuery(cmd);

                // Inform the user that the clothes item was added successfully
                MessageBox.Show("Clothes item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the modal form (frmAddClothes)
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the database operation
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

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
    public partial class frmEditCategories : Form
    {
        private string categoryName; // Store the category name

        // Constructor to accept categoryName
        public frmEditCategories(string categoryName)
        {
            InitializeComponent();
            this.categoryName = categoryName;  // Store the category name
            textBox1.Text = categoryName; // Display the category name in the TextBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the updated category name
            string updatedCategoryName = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(updatedCategoryName))
            {
                MessageBox.Show("Category name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE categories SET category_name = @category_name WHERE category_name = @original_category_name";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@category_name", updatedCategoryName);
            cmd.Parameters.AddWithValue("@original_category_name", categoryName); // Use original category name for WHERE clause

            try
            {
                // Execute the query to update the category
                db.ExecuteQuery(cmd);

                // Update the DataGridView row directly (assuming frmCategorie will reload the data)
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


    }
}

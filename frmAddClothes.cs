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
            string clothesName = textBox1.Text;   
            string size = textBox2.Text;          
            string color = textBox3.Text;         
            string rentalPrice = textBox4.Text;   
            string category = textBox5.Text;      
            string lenderName = textBox6.Text;    

            if (string.IsNullOrEmpty(clothesName) || string.IsNullOrEmpty(size) || string.IsNullOrEmpty(color) ||
                string.IsNullOrEmpty(rentalPrice) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(lenderName))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO clothes (name, size, color, rental_price, category_name, lender_name) " +
                           "VALUES (@name, @size, @color, @rental_price, @category_name, @lender_name)";

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
                db.ExecuteQuery(cmd);
                MessageBox.Show("Clothes item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

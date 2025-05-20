using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void ResetSidebar()
        {
            button4.BackColor = Color.Transparent; 
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadTotalUsersCount();
            LoadTotalLendersCount();
            LoadTotalRentersCount();
            timer1.Start();
            label1.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");

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
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmClothes clothesForm = new frmClothes();
            clothesForm.Show();                     
            this.Hide();                               
        }
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetSidebar(); 
            button4.BackColor = Color.FromArgb(0, 120, 215);

            frmRenters rentersForm = new frmRenters();
            rentersForm.Show();
            this.Hide();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            frmLenders lendersForm = new frmLenders(); 
            lendersForm.Show();                       
            this.Hide();                              
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmCategorie categorieForm = new frmCategorie(); 
            categorieForm.Show();                              
            this.Hide();                                         
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders(); 
            ordersForm.Show();                      
            this.Hide();                            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            frmCategorie categorieForm = new frmCategorie();
            categorieForm.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmCategorie categorieForm = new frmCategorie();
            categorieForm.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            frmRenters rentersForm = new frmRenters();
            rentersForm.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmLenders lendersForm = new frmLenders();
            lendersForm.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            frmClothes clothesForm = new frmClothes();
            clothesForm.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
            this.Hide();  
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( 
                "Are you sure you want to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide(); 
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadTotalRentersCount()
        {
            string query = "SELECT COUNT(*) FROM customers WHERE deleted_at IS NULL";
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            try
            {
                object result = db.ExecuteScalarQuery(cmd);
                int count = 0;
                if (result != null && int.TryParse(result.ToString(), out count))
                {
                    label3.Text = count.ToString();
                }
                else
                {
                    label3.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load renters count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label3.Text = "0";
            }
        }

        private void LoadTotalLendersCount()
        {
            string query = "SELECT COUNT(*) FROM lenders WHERE deleted_at IS NULL"; 
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            try
            {
                object result = db.ExecuteScalarQuery(cmd);
                int count = 0;
                if (result != null && int.TryParse(result.ToString(), out count))
                {
                    label4.Text = count.ToString();
                }
                else
                {
                    label4.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load lenders count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label4.Text = "0";
            }
        }
        private void LoadTotalUsersCount()
        {
            string query = "SELECT COUNT(*) FROM users WHERE deleted_at IS NULL"; 
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);

            try
            {
                object result = db.ExecuteScalarQuery(cmd);
                int count = 0;
                if (result != null && int.TryParse(result.ToString(), out count))
                {
                    label5.Text = count.ToString();
                }
                else
                {
                    label5.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label5.Text = "0";
            }
        }



        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

    }
}

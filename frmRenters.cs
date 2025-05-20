using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System.IO;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmRenters : Form
    {
        public frmRenters()
        {
            InitializeComponent();
        }
        private void frmRenters_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            LoadCustomersData();
            CustomizeDataGridView();
            AddActionButtonsToDataGridView();
            timer1.Start();
            label5.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }
        private void AddActionButtonsToDataGridView()
        {
            if (dataGridView1.Columns["Edit"] == null)
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                dataGridView1.Columns.Add(editButtonColumn);
            }
            if (dataGridView1.Columns["Delete"] == null)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                dataGridView1.Columns.Add(deleteButtonColumn);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void CustomizeDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.ClearSelection();
        }
        private void LoadCustomersData(string searchKeyword = "")
        {
            string query = "SELECT renters_name, email_address, phone_number, address FROM customers WHERE deleted_at IS NULL";
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (renters_name LIKE @search OR email_address LIKE @search OR phone_number LIKE @search OR address LIKE @search)";
            }
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

            try
            {
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["renters_name"].ToString(),
                        reader["email_address"].ToString(),
                        reader["phone_number"].ToString(),
                        reader["address"].ToString()
                    );
                }
                AddActionButtonsToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
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
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            frmLenders lendersForm = new frmLenders();
            lendersForm.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            frmClothes clothesForm = new frmClothes();
            clothesForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            frmRenters rentersForm = new frmRenters();
            rentersForm.Show();
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
        private void button2_Click(object sender, EventArgs e)
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
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
            this.Hide();
        }
        private void button8_Click(object sender, EventArgs e)
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
        private void pictureBox18_Click(object sender, EventArgs e)
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
        private void button7_Click(object sender, EventArgs e)
        {
        }
        private void button9_Click(object sender, EventArgs e)
        {
            frmAddRenter addRenterForm = new frmAddRenter();
            addRenterForm.ShowDialog();  

            LoadCustomersData();  
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void button12_Click(object sender, EventArgs e)
        {
            ExportToExistingExcel(); 
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string rentersName = dataGridView1.Rows[e.RowIndex].Cells["colRenterName"].Value.ToString();
                    string emailAddress = dataGridView1.Rows[e.RowIndex].Cells["colEmail"].Value.ToString();
                    string phoneNumber = dataGridView1.Rows[e.RowIndex].Cells["colPhone"].Value.ToString();
                    string address = dataGridView1.Rows[e.RowIndex].Cells["colAddress"].Value.ToString();
                    frmEditRenter editRenterForm = new frmEditRenter(rentersName, emailAddress, phoneNumber, address);
                    editRenterForm.StartPosition = FormStartPosition.CenterScreen;
                    editRenterForm.Show();
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["colEmail"].Value != null)
                    {
                        string emailAddress = dataGridView1.Rows[e.RowIndex].Cells["colEmail"].Value.ToString();
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this renter?",
                                                              "Confirm Delete",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            PerformSoftDelete(emailAddress, e.RowIndex);  
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        private void PerformSoftDelete(string emailAddress, int rowIndex)
        {
            string query = "UPDATE customers SET deleted_at = @deleted_at WHERE email_address = @email";
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", emailAddress);
            cmd.Parameters.AddWithValue("@deleted_at", DateTime.Now); 

            try
            {
                db.ExecuteQuery(cmd);
                dataGridView1.Rows.RemoveAt(rowIndex);
                MessageBox.Show("Renter deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting renter: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Refreshing data, please wait...", "Refreshing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("Data refreshed successfully!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(searchKeyword))
            {
                LoadCustomersData();  
            }
            else
            {
                SearchCustomersData(searchKeyword);
            }
        }
        private void SearchCustomersData(string searchKeyword)
        {
            string query = "SELECT renters_name, email_address, phone_number, address FROM customers WHERE deleted_at IS NULL";
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (renters_name LIKE @search OR email_address LIKE @search OR phone_number LIKE @search OR address LIKE @search)";
            }
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

            try
            {
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);
                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(
                        reader["renters_name"].ToString(),
                        reader["email_address"].ToString(),
                        reader["phone_number"].ToString(),
                        reader["address"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.Trim();
            LoadCustomersData(searchKeyword);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void ExportToExistingExcel()
        {
            string rentersDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "RentersData");
            string filePath = Path.Combine(rentersDataFolder, "RentersTemplate.xlsx");
            string imagePath = Path.Combine(rentersDataFolder, "image1.png");
            if (!File.Exists(imagePath))
            {
                MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range mergedRange = worksheet.Range["A1:B5"];
            double top = mergedRange.Top;
            double left = mergedRange.Left;
            double width = mergedRange.Width;
            double height = mergedRange.Height;

            try
            {
                worksheet.Shapes.AddPicture(imagePath, Microsoft.Office.Core.MsoTriState.msoFalse,
                    Microsoft.Office.Core.MsoTriState.msoCTrue, (float)left, (float)top, (float)width, (float)height);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            int row = 6;
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (dgvRow.IsNewRow) continue;  

                worksheet.Cells[row, 3].Value = dgvRow.Cells["colRenterName"].Value.ToString();
                worksheet.Cells[row, 4].Value = dgvRow.Cells["colEmail"].Value.ToString();
                worksheet.Cells[row, 5].Value = dgvRow.Cells["colPhone"].Value.ToString();
                worksheet.Cells[row, 6].Value = dgvRow.Cells["colAddress"].Value.ToString();
                row++;
            }

            workbook.Save();
            MessageBox.Show("Renters data has been exported to the existing Excel file!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excelApp.Quit();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }





    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmClothes : Form
    {
        public frmClothes()
        {
            InitializeComponent();
        }

        private void frmClothes_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            LoadClothesData();
            CustomizeDataGridView();
            AddActionButtonsToDataGridView();
            timer1.Start();
            label3.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
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

        private void LoadClothesData(string searchKeyword = "")
        {
            string query = "SELECT name, size, color, rental_price, category_name, lender_name FROM clothes WHERE deleted_at IS NULL";
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (name LIKE @search OR size LIKE @search OR color LIKE @search OR category_name LIKE @search OR lender_name LIKE @search)";
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
                        reader["name"].ToString(),
                        reader["size"].ToString(),
                        reader["color"].ToString(),
                        reader["rental_price"].ToString(),
                        reader["category_name"].ToString(),
                        reader["lender_name"].ToString()
                    );
                }

                AddActionButtonsToDataGridView(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading clothes data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            frmLenders lendersForm = new frmLenders();
            lendersForm.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.Show();
            this.Hide();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string clothesName = dataGridView1.Rows[e.RowIndex].Cells["colClothesName"].Value.ToString();
                    string size = dataGridView1.Rows[e.RowIndex].Cells["colSize"].Value.ToString();
                    string color = dataGridView1.Rows[e.RowIndex].Cells["colColor"].Value.ToString();
                    string rentalPrice = dataGridView1.Rows[e.RowIndex].Cells["colRentalPrice"].Value.ToString();
                    string category = dataGridView1.Rows[e.RowIndex].Cells["colCategory"].Value.ToString();
                    string lenderName = dataGridView1.Rows[e.RowIndex].Cells["colLenderName"].Value.ToString();

                    frmEditClothes editClothesForm = new frmEditClothes(clothesName, size, color, rentalPrice, category, lenderName);
                    editClothesForm.StartPosition = FormStartPosition.CenterScreen; 
                    editClothesForm.Show();
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    string clothesName = dataGridView1.Rows[e.RowIndex].Cells["colClothesName"].Value.ToString();
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this clothes item?",
                                                          "Confirm Delete",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        PerformSoftDelete(clothesName, e.RowIndex);
                    }
                }
            }
        }
        private void PerformSoftDelete(string clothesName, int rowIndex)
        {
            string query = "UPDATE clothes SET deleted_at = @deleted_at WHERE name = @clothes_name";
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@clothes_name", clothesName);
            cmd.Parameters.AddWithValue("@deleted_at", DateTime.Now);

            try
            {
                db.ExecuteQuery(cmd);
                dataGridView1.Rows.RemoveAt(rowIndex); 
                MessageBox.Show("Clothes item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClothesData(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting clothes item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmAddClothes addClothesForm = new frmAddClothes();
            addClothesForm.ShowDialog();

            LoadClothesData();  
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExportToExistingExcel();
        }
        private void ExportToExistingExcel()
        {
            string clothesDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "ClothesData");
            string filePath = Path.Combine(clothesDataFolder, "ClothesTemplate.xlsx");
            string imagePath = Path.Combine(clothesDataFolder, "image1.png"); 
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
                worksheet.Shapes.AddPicture(imagePath,
                    Microsoft.Office.Core.MsoTriState.msoFalse,
                    Microsoft.Office.Core.MsoTriState.msoCTrue,
                    (float)left, (float)top, (float)width, (float)height);
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

                worksheet.Cells[row, 3].Value = dgvRow.Cells["colClothesName"].Value.ToString();  
                worksheet.Cells[row, 4].Value = dgvRow.Cells["colSize"].Value.ToString();          
                worksheet.Cells[row, 5].Value = dgvRow.Cells["colColor"].Value.ToString();        
                worksheet.Cells[row, 6].Value = dgvRow.Cells["colRentalPrice"].Value.ToString();   
                worksheet.Cells[row, 7].Value = dgvRow.Cells["colCategory"].Value.ToString();      
                worksheet.Cells[row, 8].Value = dgvRow.Cells["colLenderName"].Value.ToString();   
                row++;
            }

            workbook.Save();
            MessageBox.Show("Clothes data has been exported to the existing Excel file!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excelApp.Quit();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }
    }
}

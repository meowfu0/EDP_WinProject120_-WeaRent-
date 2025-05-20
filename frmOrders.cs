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
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
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
        private void frmOrders_Load(object sender, EventArgs e)
        {
            dataGridView1.CellContentClick -= dataGridView1_CellContentClick;  
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;  

            LoadOrdersData();
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

        private void LoadOrdersData(string searchKeyword = "")
        {
            string query = "SELECT renter_name, clothes_name, order_date, return_date, lender_name, quantity, rental_price, total_price, payment_status FROM orders WHERE deleted_at IS NULL";

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

            try
            {
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);

                dataGridView1.Rows.Clear(); 

                int rowCount = 0;
                while (reader.Read())
                {
                    
                    string orderDateStr = reader["order_date"].ToString();
                    string returnDateStr = reader["return_date"].ToString();

                    DateTime orderDate = string.IsNullOrEmpty(orderDateStr) ? DateTime.MinValue : Convert.ToDateTime(orderDateStr);
                    DateTime returnDate = string.IsNullOrEmpty(returnDateStr) ? DateTime.MinValue : Convert.ToDateTime(returnDateStr);

                    dataGridView1.Rows.Add(
                        reader["renter_name"].ToString(),
                        reader["clothes_name"].ToString(),
                        orderDate == DateTime.MinValue ? "" : orderDate.ToString("yyyy-MM-dd"),
                        returnDate == DateTime.MinValue ? "" : returnDate.ToString("yyyy-MM-dd"),
                        reader["lender_name"].ToString(),
                        reader["quantity"].ToString(),
                        reader["rental_price"].ToString(),
                        reader["total_price"].ToString(),
                        reader["payment_status"].ToString()
                    );

                    rowCount++;
                }

                if (rowCount == 0)
                {
                    MessageBox.Show("No records found in the database matching the criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AddActionButtonsToDataGridView(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchOrdersData(string searchKeyword)
        {
            string query = "SELECT renter_name, clothes_name, order_date, return_date, lender_name, quantity, rental_price, total_price, payment_status FROM orders WHERE deleted_at IS NULL";
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (renter_name LIKE @search OR clothes_name LIKE @search OR lender_name LIKE @search OR payment_status LIKE @search)";
            }

            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@search", "%" + searchKeyword + "%");

            try
            {
                MySqlDataReader reader = db.ExecuteSelectQuery(cmd);

                dataGridView1.Rows.Clear(); // Clear existing rows

                int rowCount = 0;
                while (reader.Read())
                {
                    string orderDateStr = reader["order_date"].ToString();
                    string returnDateStr = reader["return_date"].ToString();

                    DateTime orderDate = string.IsNullOrEmpty(orderDateStr) ? DateTime.MinValue : Convert.ToDateTime(orderDateStr);
                    DateTime returnDate = string.IsNullOrEmpty(returnDateStr) ? DateTime.MinValue : Convert.ToDateTime(returnDateStr);

                    // Add the row to DataGridView
                    dataGridView1.Rows.Add(
                        reader["renter_name"].ToString(),
                        reader["clothes_name"].ToString(),
                        orderDate == DateTime.MinValue ? "" : orderDate.ToString("yyyy-MM-dd"),
                        returnDate == DateTime.MinValue ? "" : returnDate.ToString("yyyy-MM-dd"),
                        reader["lender_name"].ToString(),
                        reader["quantity"].ToString(),
                        reader["rental_price"].ToString(),
                        reader["total_price"].ToString(),
                        reader["payment_status"].ToString()
                    );

                    rowCount++;
                }

                if (rowCount == 0)
                {
                    MessageBox.Show("No records found in the database matching the criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                AddActionButtonsToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void label3_Click(object sender, EventArgs e)
        {

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
                    string renterName = dataGridView1.Rows[e.RowIndex].Cells["colRenterName"].Value.ToString();
                    string clothesName = dataGridView1.Rows[e.RowIndex].Cells["colClothesName"].Value.ToString();
                    DateTime orderDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["colOrderDate"].Value);
                    DateTime returnDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["colReturnDate"].Value);
                    string lenderName = dataGridView1.Rows[e.RowIndex].Cells["colLenderName"].Value.ToString();
                    int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["colQuantity"].Value);
                    decimal rentalPrice = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["colRentalPrice"].Value);
                    decimal totalPrice = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["colTotalPrice"].Value);
                    string paymentStatus = dataGridView1.Rows[e.RowIndex].Cells["colPaymentStatus"].Value.ToString();

                    frmEditOrders editOrderForm = new frmEditOrders(renterName, clothesName, orderDate, returnDate, lenderName, quantity, rentalPrice, totalPrice, paymentStatus);
                    editOrderForm.StartPosition = FormStartPosition.CenterScreen;
                    editOrderForm.Show();
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    string renterName = dataGridView1.Rows[e.RowIndex].Cells["colRenterName"].Value.ToString();
                    string clothesName = dataGridView1.Rows[e.RowIndex].Cells["colClothesName"].Value.ToString();

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        PerformSoftDelete(renterName, clothesName, e.RowIndex);
                    }
                }
            }
        }


        private void PerformSoftDelete(string renterName, string clothesName, int rowIndex)
        {
            string query = "UPDATE orders SET deleted_at = @deleted_at WHERE renter_name = @renter_name AND clothes_name = @clothes_name";
            DatabaseConnection db = new DatabaseConnection();
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@renter_name", renterName); 
            cmd.Parameters.AddWithValue("@clothes_name", clothesName); 
            cmd.Parameters.AddWithValue("@deleted_at", DateTime.Now);

            try
            {
                db.ExecuteQuery(cmd);
                dataGridView1.Rows.RemoveAt(rowIndex);  
                MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOrdersData();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            frmAddOrders addOrderForm = new frmAddOrders();
            addOrderForm.ShowDialog();  

            LoadOrdersData();  
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Refreshing data, please wait...", "Refreshing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("Data refreshed successfully!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmDateFilter dateFilterForm = new frmDateFilter();
            dateFilterForm.Owner = this;  
            dateFilterForm.StartPosition = FormStartPosition.CenterScreen;
            dateFilterForm.ShowDialog();  
        }


        public void ExportOrdersToExcel(DateTime startDate, DateTime endDate)
        {
            var dataGridView = dataGridView1;

            string ordersDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "OrdersData");
            string filePath = Path.Combine(ordersDataFolder, "OrdersTemplate.xlsx");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Template file not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            int row = 6;
            foreach (DataGridViewRow dgvRow in dataGridView.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                DateTime orderDate = Convert.ToDateTime(dgvRow.Cells["colOrderDate"].Value);
                DateTime returnDate = Convert.ToDateTime(dgvRow.Cells["colReturnDate"].Value);

                if (orderDate >= startDate && returnDate <= endDate)
                {
                    worksheet.Cells[row, 3].Value = dgvRow.Cells["colRenterName"].Value.ToString();
                    worksheet.Cells[row, 4].Value = dgvRow.Cells["colClothesName"].Value.ToString();
                    worksheet.Cells[row, 5].Value = dgvRow.Cells["colOrderDate"].Value.ToString();
                    worksheet.Cells[row, 6].Value = dgvRow.Cells["colReturnDate"].Value.ToString();
                    worksheet.Cells[row, 7].Value = dgvRow.Cells["colLenderName"].Value.ToString();
                    worksheet.Cells[row, 8].Value = dgvRow.Cells["colQuantity"].Value.ToString();
                    worksheet.Cells[row, 9].Value = dgvRow.Cells["colRentalPrice"].Value.ToString();
                    worksheet.Cells[row, 10].Value = dgvRow.Cells["colTotalPrice"].Value.ToString();
                    worksheet.Cells[row, 11].Value = dgvRow.Cells["colPaymentStatus"].Value.ToString();

                    row++;
                }
            }

            workbook.Save();
            MessageBox.Show("Orders data has been exported to the existing Excel file!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            excelApp.Quit();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.Trim();
            LoadOrdersData(searchKeyword);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchKeyword))
            {
                LoadOrdersData();  
            }
            else
            {
                SearchOrdersData(searchKeyword);  
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace EDP_WinProject102__WearRent_
{
    public partial class frmDateFilter : Form
    {
        private DateTime startDate;
        private DateTime endDate;
        public frmDateFilter()
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            startDate = dateTimePicker1.Value.Date;  
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            endDate = dateTimePicker2.Value.Date;  
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Get the selected start and end dates from DateTimePickers
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            // Validate that the start date is not after the end date
            if (startDate > endDate)
            {
                MessageBox.Show("Start Date cannot be after End Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

    // Call the Export function in the main form (frmOrders), passing the selected date range
    ((frmOrders)this.Owner).ExportOrdersToExcel(startDate, endDate);

            // Close the filter form after exporting
            this.Close();
        }
    }
}

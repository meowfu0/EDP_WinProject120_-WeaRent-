﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void frmOrders_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

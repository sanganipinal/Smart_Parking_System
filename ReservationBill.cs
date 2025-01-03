﻿using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartParkingSystem
{
    public partial class ReservationBill : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ReservationBill()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void txtsrh_TextChanged(object sender, EventArgs e)
        {
            if (txtsrh.Text == "")
            {
                load1();
            }
            else
            {
                var chk1 = db.tblDepartures.Where(d => d.Car_No == txtsrh.Text || d.Driver == txtsrh.Text || d.Type == txtsrh.Text);
                if (chk1 != null)
                {
                    dataGridView1.DataSource = chk1;
                    display();
                }
            }
        }

        private void load1()
        {
            var ld = db.tblDepartures.ToList();
            dataGridView1.DataSource = ld;
        }

        private void ReservationBill_Load(object sender, EventArgs e)
        {
            var ld = db.tblDepartures.ToList();
            dataGridView1.DataSource = ld;
            display();
        }

        public void display()
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            lblamt.Text = sum.ToString();

            var slot = db.tblSlots.Count();
            labelcp.Text = slot.ToString();
            var pca = db.tblArrivals.Count();
            labelarrive.Text = pca.ToString();

            var pcal = db.tblDepartures.Count();
            lbltotald.Text = pcal.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter p = new DGVPrinter();
            p.printDocument = printDocument1;
            p.Title = "Whole Report";
            p.SubTitle = string.Format("Date:{0}", DateTime.Now);

            p.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            p.printDocument = printDocument1;
            p.PageNumbers = true;

            p.PageNumberInHeader = true;

            p.PorportionalColumns = true;
            p.HeaderCellAlignment = StringAlignment.Near;
            p.Footer = "Smart Parking System";

            p.FooterSpacing = 15;
            p.PrintDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invoice i = new Invoice();
            i.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WelcomeScreen W = new WelcomeScreen();
            W.Show();
            this.Hide();
        }
    }
}
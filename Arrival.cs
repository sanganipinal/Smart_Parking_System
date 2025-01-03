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
    public partial class Arrival : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Arrival()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WelcomeScreen w = new WelcomeScreen();
            w.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void load()
        {
            var ld = db.tblArrivals.ToList();
            dataGridView1.DataSource = ld;
            labelid.Text = "";
            txtnmdr.Text = "";
            txtcnum.Text = "";
            txtstaytm.Text = "";
            checkedListBox1.Text = "";

            var total = db.tblArrivals.Count();
            lbltotal.Text = total.ToString();
        }

        private void Arrival_Load(object sender, EventArgs e)
        {
            load();
            comboBox1.DataSource = db.tblSlots.ToList();
            comboBox1.ValueMember = "Slot_No";
            comboBox1.DisplayMember = "Slot_No";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnmdr.Text != null & txtcnum.Text != null & txtstaytm != null & checkedListBox1.Text != null & comboBox1.Text != null)
                {
                    string cnum = txtcnum.Text;
                    var chk = db.tblArrivals.Where(o => o.Car_No == cnum).FirstOrDefault();
                    if (chk == null)
                    {
                        tblArrival a = new tblArrival();
                        a.Driver_Name = txtnmdr.Text;
                        a.Car_No = txtcnum.Text;
                        a.Category = checkedListBox1.Text;
                        a.Stay_Time = txtstaytm.Text;
                        a.Selected_Slot = comboBox1.Text;
                        a.Arrive_Time = DateTime.Now;

                        db.tblArrivals.InsertOnSubmit(a);
                        db.SubmitChanges();
                        MessageBox.Show("Car Parked Successfully...");
                        load();
                    }
                    else
                    {
                        MessageBox.Show("This number of Car is already parked...");
                    }
                }
                else
                {
                    MessageBox.Show("Empty box First fill all the detail then insert...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ir = e.RowIndex;
            labelid.Text = dataGridView1.Rows[ir].Cells[0].Value.ToString();
            txtnmdr.Text = dataGridView1.Rows[ir].Cells[1].Value.ToString();
            txtcnum.Text = dataGridView1.Rows[ir].Cells[2].Value.ToString();
            txtstaytm.Text = dataGridView1.Rows[ir].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[ir].Cells[4].Value.ToString();
            checkedListBox1.Text = dataGridView1.Rows[ir].Cells[5].Value.ToString();
            lblarrivaltm.Text = dataGridView1.Rows[ir].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelid.Text != null & txtnmdr.Text != null & txtcnum.Text != null & txtstaytm != null & checkedListBox1.Text != null & comboBox1.Text != null)
                {
                    if (MessageBox.Show("Do you want to edit record!...", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string cnum = txtcnum.Text;
                        var chk = db.tblArrivals.Where(o => o.Car_No == cnum).FirstOrDefault();
                        if (chk == null)
                        {
                            int st = Convert.ToInt32(labelid.Text);
                            var a = db.tblArrivals.Where(o => o.ID == st).FirstOrDefault();

                            a.Driver_Name = txtnmdr.Text;
                            a.Car_No = txtcnum.Text;
                            a.Category = checkedListBox1.Text;
                            a.Stay_Time = txtstaytm.Text;
                            a.Selected_Slot = comboBox1.Text;
                            a.Arrive_Time = DateTime.Now;

                            db.SubmitChanges();
                            MessageBox.Show("Data Updated");
                            load();
                        }
                        else
                        {
                            MessageBox.Show("With this name car already parked...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Record not Selected and Data not processed Try Again...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelid.Text != null)
                {
                    if (MessageBox.Show("Do you want to delete record!...", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int st = Convert.ToInt32(labelid.Text);
                        var a = db.tblArrivals.Where(o => o.ID == st).FirstOrDefault();

                        db.tblArrivals.DeleteOnSubmit(a);
                        db.SubmitChanges();
                        MessageBox.Show("Data Deleted");
                        load();
                    }
                }
                else
                {
                    MessageBox.Show("Record not selected please select it and then delete...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DGVPrinter p = new DGVPrinter();
            p.printDocument = printDocument1;
            p.Title = "Arrival Report";
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

        private void txtsrh_TextChanged(object sender, EventArgs e)
        {
            if (txtsrh.Text == "")
            {
                load();
            }
            else
            {
                searchdata();
            }
        }

        public void searchdata()
        {
            try
            {
                if (txtsrh.Text != null)
                {
                    string sk = txtsrh.Text;
                    var chk = db.tblArrivals.Where(o => o.Driver_Name == sk || o.Car_No == sk || o.Category == sk).ToList();
                    if (chk != null)
                    {
                        dataGridView1.DataSource = chk;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
    }
}
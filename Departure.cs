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
    public partial class Departure : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Departure()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            WelcomeScreen W = new WelcomeScreen();
            W.Show();
            this.Hide();
        }

        private void Departure_Load(object sender, EventArgs e)
        {
            try
            {
                var dblod = db.tblDepartures.ToList();
                dataGridView1.DataSource = dblod;
                comboBoxcarno.DataSource = db.tblArrivals.ToList();
                comboBoxcarno.ValueMember = "Car_No";
                comboBoxcarno.DisplayMember = "Car_No";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxcarno.Text != null & labeldname.Text != null & labelptype != null & labelptime.Text != null)
                {

                    tblDeparture d = new tblDeparture();
                    d.Car_No = comboBoxcarno.Text;
                    d.Driver = labeldname.Text;
                    d.Type = labelptype.Text;
                    d.Park_Time = labelptime.Text;

                    decimal str = Convert.ToDecimal(labelptime.Text);
                    decimal amt = Convert.ToDecimal(txtpamt.Text);
                    decimal amttotal = str * amt;

                    d.Amount = amttotal;
                    d.Departure_Time = DateTime.Now;

                    db.tblDepartures.InsertOnSubmit(d);
                    db.SubmitChanges();
                    MessageBox.Show("Departured Successfully...");
                    load();
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

        private void load()
        {
            var dblod = db.tblDepartures.ToList();
            dataGridView1.DataSource = dblod;
            comboBoxcarno.DataSource = db.tblArrivals.ToList();
            comboBoxcarno.ValueMember = "Car_No";
            comboBoxcarno.DisplayMember = "Car_No";
        }

        private void comboBoxcarno_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor Current = Cursors.WaitCursor;
                tblArrival obj = comboBoxcarno.SelectedItem as tblArrival;
                if (obj != null)
                {
                    labeldname.Text = obj.Driver_Name.ToString();
                    labelptype.Text = obj.Category.ToString();
                    labelptime.Text = obj.Stay_Time.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indexrow = e.RowIndex;
            labelid1.Text = dataGridView1.Rows[indexrow].Cells[0].Value.ToString();
            lbldtime.Text = dataGridView1.Rows[indexrow].Cells[6].Value.ToString();
            lblpfee.Text = dataGridView1.Rows[indexrow].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelid.Text != null & labeldname.Text != null & labelptype != null & labelptime.Text != null)
                {
                    if (MessageBox.Show("Do you want to edit record!...", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        int st = Convert.ToInt32(labelid.Text);
                        var d = db.tblDepartures.Where(o => o.ID == st).FirstOrDefault();

                        d.Car_No = comboBoxcarno.Text;
                        d.Driver = labeldname.Text;
                        d.Type = labelptype.Text;
                        d.Park_Time = labelptime.Text;

                        decimal str = Convert.ToDecimal(labelptime.Text);
                        decimal amt = Convert.ToDecimal(txtpamt.Text);
                        decimal amttotal = str * amt;

                        d.Amount = amttotal;
                        d.Departure_Time = DateTime.Now;

                        db.SubmitChanges();
                        MessageBox.Show("Data Updated");
                        load();
                    }
                }
                else
                {
                    MessageBox.Show("Record not Selected and Data not processed Try Again...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Amount not entered, enter amount and then try to update...");
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
                        var d = db.tblDepartures.Where(o => o.ID == st).FirstOrDefault();

                        db.tblDepartures.DeleteOnSubmit(d);
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
            p.Title = "Departure Report";
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
                load1();
            }
            else
            {
                var chk1 = db.tblDepartures.Where(d => d.Car_No == txtsrh.Text || d.Driver == txtsrh.Text || d.Type == txtsrh.Text);
                if (chk1 != null)
                {
                    dataGridView1.DataSource = chk1;
                }
            }
        }

        private void load1()
        {
            var ld = db.tblDepartures.ToList();
            dataGridView1.DataSource = ld;
        }
    }
}
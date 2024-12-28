using DGVPrinterHelper;
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
    public partial class SlotsForm : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public SlotsForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            WelcomeScreen S = new WelcomeScreen();
            S.Show();
            this.Hide();
        }

        public void reset()
        {
            txtsno.Text = "";
            txtloc.Text = "";
            labelid.Text = "";    
        }

        public void load()
        {
            var lod = db.tblSlots.ToList();
            dataGridView1.DataSource = lod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsno.Text != null & txtloc.Text != null)
                {
                    string sno = txtsno.Text;
                    var chk = db.tblSlots.Where(o => o.Slot_No == sno).FirstOrDefault();
                    if(chk == null)
                    {
                        tblSlot s = new tblSlot();
                        s.Slot_No = txtsno.Text;
                        s.Location = txtloc.Text;
                        db.tblSlots.InsertOnSubmit(s);
                        db.SubmitChanges();
                        MessageBox.Show("Data Inserted");
                        reset();
                        load();
                    }
                    else
                    {
                        MessageBox.Show("With this name slot already added...");
                    }
                }
                else
                {
                    MessageBox.Show("Slot No or Location Box is empty... Data not processed Try Again...!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void SlotsForm_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int ir = e.RowIndex;
            labelid.Text = dataGridView1.Rows[ir].Cells[0].Value.ToString();
            txtsno.Text = dataGridView1.Rows[ir].Cells[1].Value.ToString();
            txtloc.Text = dataGridView1.Rows[ir].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelid.Text != null & txtsno.Text != null & txtloc.Text != null)
                {
                    if (MessageBox.Show("Do you want to edit record!...", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string sno = txtsno.Text;
                        var chk = db.tblSlots.Where(o => o.Slot_No == sno).FirstOrDefault();
                        if (chk == null)
                        {
                            int st = Convert.ToInt32(labelid.Text);
                            var s = db.tblSlots.Where(o => o.ID == st).FirstOrDefault();

                            s.Slot_No = txtsno.Text;
                            s.Location = txtloc.Text;
                            db.SubmitChanges();
                            MessageBox.Show("Data Updated");
                            reset();
                            load();
                        }
                        else
                        {
                            MessageBox.Show("With this name slot already added...");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Slot No or Location Box is empty... Data not processed Try Again...!");
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
                        var s = db.tblSlots.Where(o => o.ID == st).FirstOrDefault();

                        db.tblSlots.DeleteOnSubmit(s);
                        db.SubmitChanges();
                        MessageBox.Show("Data Deleted");
                        reset();
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
                    var chk = db.tblSlots.Where(o => o.Slot_No == sk || o.Location == sk).ToList();
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

        private void button4_Click(object sender, EventArgs e)
        {
            DGVPrinter p = new DGVPrinter();
            p.printDocument = printDocument1;
            p.Title = "Total Cars Capacity Report";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

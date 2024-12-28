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
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.Show();
            this.Hide();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arrival A = new Arrival();
            A.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SlotsForm S = new SlotsForm();
            S.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Departure D = new Departure();
            D.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReservationBill R = new ReservationBill();
            R.Show();
            this.Hide();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SmartParkingSystem
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (txteml.Text != null & txtpwd.Text != null)
                {
                    var item = db.tblAccounts.Where(s => s.Email == txteml.Text & s.Password == txtpwd.Text).FirstOrDefault();
                    if (item != null)
                    {
                        WelcomeScreen wc = new WelcomeScreen();
                        wc.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your entered account information does not exists... First create your account");
                    }
                }
                else
                {
                    MessageBox.Show("Email or Password are not valid...! Try Again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
    }
}

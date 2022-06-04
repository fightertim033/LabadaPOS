﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabadaPOS
{
    public partial class Main : Form
    {
        public static Main instance;
        public Main()
        {
            InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }                                  

        private void exitbtn_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void exitbtn_MouseHover(object sender, EventArgs e)
        {
            exitbtn.BackColor = Color.SkyBlue;
        }

        private void exitbtn_MouseLeave(object sender, EventArgs e)
        {
            exitbtn.BackColor = Color.DeepSkyBlue;     
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(0);
        }

        private void tab2_btn_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
        }
        private void tab3_btn_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(2);
        }

        private void tab4_btn_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(3);
        }

        private void lightbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void mediumbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void heavybtn_Click(object sender, EventArgs e)
        {
            
        }

        private void settingsbtn_Click(object sender, EventArgs e)
        {

        }

        private void machinewash_btn_Click(object sender, EventArgs e)
        {

            lndrymthd_txt.Text = "Machine Wash";

        }

        private void dryclean_btn_Click(object sender, EventArgs e)
        {

            lndrymthd_txt.Text = "Dry Clean (currently unavailable)";
            MessageBox.Show("Dry Clean is currently unavailable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void detergentbtn_Click(object sender, EventArgs e)
        {
            if (addons_txt.Text == "")
            {
                addons_txt.Text = "Laundry Detergent";
            }
            else {
                addons_txt.Text = "";
            }
            
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            int lt = 35;
            int md = 55;
            int hvy = 75;

            int ltkilo = int.Parse(ltqty_txt.Text);
            int hvykilo = int.Parse(hvyqty_txt.Text);
            int mdkilo = int.Parse(mdqty_txt.Text);
            int kilos = ltkilo + hvykilo + mdkilo;
            int lttotal = ltkilo * lt;
            int mdtotal = mdkilo * md;
            int hvytotal = hvykilo * hvy;
            int kilototal = lttotal + mdtotal + hvytotal;

            int addons = kilos*15;
            int delivery;

            if (pikupmthd_txt.Text == "Delivery")
            {
                delivery = 30;
            }
            else
            {
                delivery = 0;
            }

            int formula;

            if (addons_txt.Text == "Laundry Detergent" && pikupmthd_txt.Text == "Delivery")
            {
                formula = kilototal + addons + delivery;
            }
            else if (addons_txt.Text != "Laundry Detergent" && pikupmthd_txt.Text == "Delivery")
            {
                formula = kilototal + delivery;
            }
            else if (addons_txt.Text == "Laundry Detergent" && pikupmthd_txt.Text != "Delivery")
            {
                formula = kilototal + addons;
            }
            else {
                formula = kilototal;
            }

            total_lbl.Text = formula.ToString();
        }

        private void deliverybtn_Click(object sender, EventArgs e)
        {
            pikupmthd_txt.Text = "Delivery";
        }

        private void pickupbtn_Click(object sender, EventArgs e)
        {
            pikupmthd_txt.Text = "Pickup";
        }

        private void numericUpDown_light_ValueChanged(object sender, EventArgs e)
        {
            string ltqty = numericUpDown_light.Value.ToString();
            ltqty_txt.Text = ltqty;
        }

        private void numericUpDown_medium_ValueChanged(object sender, EventArgs e)
        {
            string mdqty = numericUpDown_medium.Value.ToString();
            mdqty_txt.Text = mdqty;
        }

        private void numericUpDown_heavy_ValueChanged(object sender, EventArgs e)
        {
            string hvyqty = numericUpDown_heavy.Value.ToString();
            hvyqty_txt.Text = hvyqty;
        }
    }
}

using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_G5_Lab3.GUI
{
    public partial class CheckoutGUI : Form
    {
        public CheckoutGUI()
        {
            InitializeComponent();
        }
        public CheckoutGUI(Order order) : this()
        {
            textBox1.Text = order.UserName;
            textBox2.Text = "" + order.FirstName;
            textBox3.Text = "" + order.LastName;
            textBox4.Text = "" + order.Address;
            textBox5.Text = "" + order.City;
            textBox6.Text = "" + order.State;
            textBox7.Text = "" + order.Country;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

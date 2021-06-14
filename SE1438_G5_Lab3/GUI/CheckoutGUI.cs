using SE1438_G5_Lab3.DAL;
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
            var cart = ShoppingCartDAO.GetCart();
            textBox1.Text = order.UserName;
            textBox2.Text = "Quan" + order.FirstName;
            textBox3.Text = "Nguyen" + order.LastName;
            textBox4.Text = "Ha Noi" + order.Address;
            textBox5.Text = "Ha Noi" + order.City;
            textBox6.Text = "Ha Noi" + order.State;
            textBox7.Text = "Viet Nam" + order.Country;
            textBox8.Text = "0966 848 112" + order.Phone;
            textBox9.Text = "quanndh130577@fpt.edu.vn" + order.Email;
            textBox10.Text = cart.GetTotal().ToString();
            textBox11.Text = "FREE" + order.PromoCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckoutValidate.checkInput(textBox2,textBox3,textBox9,textBox8))
            {
                if (OrderDAO.Insert(new Order()
                {
                    UserName = Variables.UserName,
                    FirstName = textBox2.Text,
                    LastName = textBox3.Text,
                    Address = textBox4.Text,
                    City = textBox5.Text,
                    State = textBox6.Text,
                    Country = textBox7.Text,
                    Phone = textBox8.Text,
                    Email = textBox9.Text,
                    Total = ShoppingCartDAO.GetCart().GetTotal(),
                    PromoCode = textBox11.Text,
                    OrderDate = dateTimePicker1.Value,
                })) {
                    MessageBox.Show("Order has been created!");
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

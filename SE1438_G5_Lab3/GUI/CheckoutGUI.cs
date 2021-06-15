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
            txtUseName.Text = order.UserName;
            txtFirstName.Text = "Quan" + order.FirstName;
            txtLastName.Text = "Nguyen" + order.LastName;
            txtAddress.Text = "Ha Noi" + order.Address;
            txtCity.Text = "Ha Noi" + order.City;
            txtState.Text = "Ha Noi" + order.State;
            txtCountry.Text = "Viet Nam" + order.Country;
            txtPhone.Text = "0966 848 112" + order.Phone;
            txtEmail.Text = "quanndh130577@fpt.edu.vn" + order.Email;
            txtTotal.Text = cart.GetTotal().ToString();
            txtCode.Text = "FREE" + order.PromoCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckoutValidate.checkInput(txtFirstName,txtLastName,txtEmail,txtPhone))
            {
                if (OrderDAO.Insert(new Order()
                {
                    UserName = Variables.UserName,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Address = txtAddress.Text,
                    City = txtCity.Text,
                    State = txtState.Text,
                    Country = txtCountry.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Total = ShoppingCartDAO.GetCart().GetTotal(),
                    PromoCode = txtCode.Text,
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

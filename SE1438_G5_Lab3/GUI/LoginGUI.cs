using SE1438_G5_Lab3.DAL;
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
    public partial class LoginGUI : Form
    {
        private MainGUI mainForm;

        public LoginGUI(MainGUI mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = UserDAO.GetUsers()
                .Where(u => u.UserName == txtUserName.Text && u.Password == txtPassword.Text)
                .FirstOrDefault();
            if (user == null)
                MessageBox.Show("User does not exist!");
            else
            {
                Variables.UserName = user.UserName;
                Variables.Role = user.Role;
                ShoppingCartDAO.UserName = user.UserName;
                var cart = ShoppingCartDAO.GetCart();
                cart.MigrateCart();
            }
            this.Close();
            this.mainForm.displayMenu();
           // MainGUI main = new MainGUI();
           // main.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

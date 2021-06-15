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
    public partial class MainGUI : Form
    {
        private static MainGUI instance;

        private MainGUI()
        {
            InitializeComponent();
            displayMenu();
        }

        public static MainGUI GetMainGui()
        {
            if (instance == null)
                instance = new MainGUI();

            return instance;
        }

        private void Embed(Panel p, Form f)
        {
            p.Controls.Clear();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Visible = true;
            f.Dock = DockStyle.Fill;
            p.Controls.Add(f);//thêm form mới vào panel
            p.Show();
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new StoreGUI());
        }

        private void cartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Embed(panel1, CartGUI.GetCartGUI());
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(isLoggedIn())
            {
                Variables.UserName = null;
                displayMenu();
            } else
            {
                LoginGUI.GetLoginGUI().ShowDialog();
            }

        }

        private void albumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new AlbumGUI());
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new ReportGUI());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new AboutGUI());
        }

        private bool isLoggedIn()
        {
            return Variables.UserName != null && Variables.UserName != "";
        }

        public void displayMenu()
        {
            if (!isLoggedIn())
            {
                loginToolStripMenuItem.Text = "Login";

                albumToolStripMenuItem.Visible = false;
                reportToolStripMenuItem.Visible = false;
            }
            else
            {
                loginToolStripMenuItem.Text = "Logout (" + Variables.UserName + ")";

                albumToolStripMenuItem.Visible = true;
                reportToolStripMenuItem.Visible = true;
            }
            var cart = ShoppingCartDAO.GetCart();
            string cartSummary = "Cart (" + cart.GetCount() + ")";
            cartToolStripMenuItem.Text = cartSummary;
        }
    }
}

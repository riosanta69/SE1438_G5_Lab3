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
    public partial class CartGUI : Form
    {
        private static CartGUI instance;
        private CartGUI()
        {
            InitializeComponent();
        }

        public static CartGUI GetCartGUI()
        {
            if (instance == null)
                instance = new CartGUI();

            instance.bindDataGridView1();
            return instance;
        }

        public void bindDataGridView1()
        {
            var cart = ShoppingCartDAO.GetCart();
            var cartItems = cart.GetCartItems();
            txtTotal.Text = String.Format("{0:0.00}", cart.GetTotal());
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = cartItems;
            dataGridView1.Columns["RecordID"].Visible = false;
            dataGridView1.Columns["cartID"].Visible = false;
            int count = dataGridView1.Columns.Count;
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn()
            {

                Text = "Detail",
                Name = "Detail",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(0, btnDetail);

            DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn()
            {
                Text = "Remove from cart",
                Name = "Remove",

                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count + 1, btnRemove);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Remove"].Index)
            {
                int albumID = (int)dataGridView1.Rows[e.RowIndex].Cells["AlbumID"].Value;
                ShoppingCartDAO.GetCart().RemoveFromCart(albumID);
                bindDataGridView1();
                MainGUI.GetMainGui().displayMenu();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Detail"].Index)
            {
                int albumID = (int)dataGridView1.Rows[e.RowIndex].Cells["albumID"].Value;
                AlbumDetailGUI formdetail = new AlbumDetailGUI(albumID);
                formdetail.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Variables.UserName != null)
            {
                CheckoutGUI checkout = new CheckoutGUI(new Order()
                {
                    UserName = Variables.UserName,
                });
                checkout.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login!");
                LoginGUI.GetLoginGUI().ShowDialog();
            }
        }
    }
}

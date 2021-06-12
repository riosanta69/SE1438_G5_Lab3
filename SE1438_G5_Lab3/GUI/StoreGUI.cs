using SE1438_G5_Lab3.DAL;
using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_G5_Lab3.GUI
{
    public partial class StoreGUI : Form
    {
        private DataTable albumDataTable;

        public StoreGUI()
        {
            InitializeComponent();
            dataGridView1.DataSource = GenreDAO.GetDataTable();
            dataGridView1.Columns["GenreID"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;

            albumDataTable = AlbumDAO.GetDataTable();

            dataGridView1_CellClick_helper(1);

            bindGrid1();
        }
        private void bindGrid1()
        {
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn()
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
            //int count = dataGridView2.Columns.Count;
            dataGridView2.Columns.Insert(0, btnDetail);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
    
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Detail"].Index)
            {
                int albumID = (int)dataGridView2.Rows[e.RowIndex].Cells["albumID"].Value;
                AlbumDetailGUI formdetail = new AlbumDetailGUI(albumID);
                DialogResult dr = formdetail.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    var cart = ShoppingCartDAO.GetCart();
                    cart.AddToCart(albumID);
                    CartGUI fc = new CartGUI();
                    fc.ShowDialog();
                }
            }

        }
        
        private void dataGridView1_CellClick_helper(int selectedGenreID)
        {
            DataRow[] dataRows = albumDataTable.Select("GenreID = " + selectedGenreID);

            if (dataRows.Length > 0)
                dataGridView2.DataSource = dataRows.CopyToDataTable();
            else dataGridView2.DataSource = new DataTable();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedGenreID = (int)dataGridView1.Rows[e.RowIndex].Cells["GenreID"].Value;

            dataGridView1_CellClick_helper(selectedGenreID);
        }
    }
}

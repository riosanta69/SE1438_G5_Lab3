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
        public MainGUI()
        {
            InitializeComponent();
            
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
            Embed(panel1, new CartGUI());
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Embed(panel1, new LoginGUI());
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
    }
}

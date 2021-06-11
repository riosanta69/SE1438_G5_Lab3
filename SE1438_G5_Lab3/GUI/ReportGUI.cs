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
    public partial class ReportGUI : Form
    {
        public ReportGUI()
        {
            InitializeComponent();
            dataGridView1.DataSource = OrderDAO.GetDataTable();
            dataGridView2.DataSource = OrderDetailDAO.GetDataTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

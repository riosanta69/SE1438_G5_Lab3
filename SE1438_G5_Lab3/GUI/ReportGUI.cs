using SE1438_G5_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectionRange sr = new SelectionRange();
            sr.Start = DateTime.Parse(this.textBox1.Text);
            sr.End = DateTime.Parse(this.textBox2.Text);
            this.monthCalendar1.SelectionRange = sr;
            FillData();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
            this.textBox2.Text = monthCalendar1.SelectionRange.End.Date.ToShortDateString();
        }
        private void FillData()
        {
            SqlCommand cmd = new SqlCommand("select * from orders where orderDate between @sd and @ed and firstname like @fn and country like @c");
            cmd.Parameters.AddWithValue("@sd", monthCalendar1.SelectionStart);
            cmd.Parameters.AddWithValue("@ed",monthCalendar1.SelectionEnd);
            cmd.Parameters.AddWithValue("@fn", "%" + textBox3.Text.Trim() + "%");
            cmd.Parameters.AddWithValue("@c", "%" + textBox4.Text.Trim() + "%");
            dataGridView1.DataSource = DAO.GetDataTable(cmd);
        }
    }
}

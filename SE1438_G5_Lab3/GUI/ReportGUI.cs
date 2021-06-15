using SE1438_G5_Lab3.DAL;
using SE1438_G5_Lab3.DTL;
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

        private DataTable orderDetailTable;
        public ReportGUI()
        {
            InitializeComponent();
            dataGridView1.DataSource = OrderDAO.GetDataTable();
            orderDetailTable = OrderDetailDAO.GetDataTable();
            dataGridView2.DataSource = new DataTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells["Country"].Value.ToString();
                int selectedOrderID = (int)dataGridView1.Rows[e.RowIndex].Cells["OrderId"].Value;

                DataRow[] dataRows = orderDetailTable.Select("OrderId = " + selectedOrderID);

                if (dataRows.Length > 0)
                    dataGridView2.DataSource = dataRows.CopyToDataTable();
                else dataGridView2.DataSource = new DataTable();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectionRange sr = new SelectionRange();
            sr.Start = DateTime.Parse(this.txtFrom.Text);
            sr.End = DateTime.Parse(this.txtTo.Text);
            this.monthCalendar1.SelectionRange = sr;
            FillData();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.txtFrom.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
            this.txtTo.Text = monthCalendar1.SelectionRange.End.Date.ToShortDateString();
        }
        private void FillData()
        {
            SqlCommand cmd = new SqlCommand("select * from orders where orderDate between @sd and @ed and firstname like @fn and country like @c");
            cmd.Parameters.AddWithValue("@sd", monthCalendar1.SelectionStart);
            cmd.Parameters.AddWithValue("@ed",monthCalendar1.SelectionEnd);
            cmd.Parameters.AddWithValue("@fn", "%" + txtFirstName.Text.Trim() + "%");
            cmd.Parameters.AddWithValue("@c", "%" + txtCountry.Text.Trim() + "%");
            dataGridView1.DataSource = DAO.GetDataTable(cmd);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

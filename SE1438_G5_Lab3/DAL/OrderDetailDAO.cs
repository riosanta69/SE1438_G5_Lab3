using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    class OrderDetailDAO
    {
        internal static void Insert(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
        public static DataTable GetDataTable()
        {
            string sql = "select * from OrderDetails";
            return DAO.GetDataTable(sql);

        }
    }
}

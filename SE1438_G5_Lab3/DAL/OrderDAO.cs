using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    class OrderDAO
    {
        internal static void Insert(Order order)
        {
            throw new NotImplementedException();
        }

        internal static int GetMaxID()
        {
            throw new NotImplementedException();
        }
        public static DataTable GetDataTable()
        {
            string sql = "select * from Orders";
            return DAO.GetDataTable(sql);

        }

    }
}

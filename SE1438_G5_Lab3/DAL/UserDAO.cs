using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    class UserDAO
    {
        public static DataTable GetDataTable()
        {
            string sql = "select UserName, password from Users";
            return DAO.GetDataTable(sql);

        }
    }
}

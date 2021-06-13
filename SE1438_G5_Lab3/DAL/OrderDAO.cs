using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    class OrderDAO
    {
        public static bool Insert(Order order)
        {
            SqlCommand cmd = new SqlCommand("Insert into Orders(OrderId,OrderDate,PromoCode,UserName,FirstName,LastName,Address,City,State,Country,Phone,Email,Total) " +
               "Values(@OrderId,@OrderDate,@PromoCode,@UserName,@FirstName,@LastName,@Address,@City,@State,@Country,@Phone,@Email,@Total)");
            cmd.Parameters.AddWithValue("@OrderId", order.OrderID);
            cmd.Parameters.AddWithValue("@OrderDate",order.OrderDate );
            cmd.Parameters.AddWithValue("@PromoCode",order.PromoCode );
            cmd.Parameters.AddWithValue("@UserName",order.UserName);
            cmd.Parameters.AddWithValue("@FirstName",order.FirstName );
            cmd.Parameters.AddWithValue("@LastName",order.LastName);
            cmd.Parameters.AddWithValue("@Address",order.Address);
            cmd.Parameters.AddWithValue("@City",order.City);
            cmd.Parameters.AddWithValue("@State",order.State);
            cmd.Parameters.AddWithValue("@Country",order.Country);
            cmd.Parameters.AddWithValue("@Phone",order.Phone);
            cmd.Parameters.AddWithValue("@Email",order.Email);
            cmd.Parameters.AddWithValue("@Total",order.Total);
            return DAO.UpdateTable(cmd);
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

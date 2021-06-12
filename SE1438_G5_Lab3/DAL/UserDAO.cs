using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    class UserDAO
    {
        public static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var user = new User
                    {
                        Id = int.Parse(row["id"].ToString()),
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString()
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users.AsEnumerable();
        }
        public static DataTable GetDataTable()
        {
            string sql = "select * from Users";
            return DAO.GetDataTable(sql);

        }
        public static User GetUserByID(int id)
        {
            User user = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE ID = @ID");
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    user = new User
                    {
                        Id = int.Parse(row["id"].ToString()),
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString()

                    };

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

    }
}

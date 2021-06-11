using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    public class GenreDAO
    {
        public static IEnumerable<Genre> GetGenres()
        {
            var genres = new List<Genre>();

            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var genre = new Genre
                    {
                        GenreID = int.Parse(row["GenreId"].ToString()),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString()

                    };
                    genres.Add(genre);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return genres.AsEnumerable();
        }
        public static DataTable GetDataTable()
        {
            string sql = "select * from Genres";
            return DAO.GetDataTable(sql);

        }
        public static Genre GetGenreByID(int id)
        {
            Genre genre = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Genres WHERE genreID = @ID");
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    genre = new Genre
                    {
                        GenreID = int.Parse(row["GenreId"].ToString()),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString()

                    };

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return genre;
        }

    }
}

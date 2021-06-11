using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DAL
{
    class ArtistDAO
    {
        public static IEnumerable<Artist> GetArtists()
        {
            var artists = new List<Artist>();

            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var artist = new Artist
                    {
                        ArtistID = int.Parse(row["ArtistId"].ToString()),
                        Name = row["Name"].ToString()

                    };
                    artists.Add(artist);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return artists.AsEnumerable();
        }
        public static DataTable GetDataTable()
        {
            string sql = "select * from Artists";
            return DAO.GetDataTable(sql);

        }
        public static Artist GetArtistByID(int id)
        {
            Artist artist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Artists WHERE artistID = @ID");
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    artist = new Artist
                    {
                        ArtistID = int.Parse(row["ArtistId"].ToString()),
                        Name = row["Name"].ToString()

                    };

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return artist;
        }
    }
}

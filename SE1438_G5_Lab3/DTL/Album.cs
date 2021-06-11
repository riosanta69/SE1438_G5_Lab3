using SE1438_G5_Lab3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE1438_G5_Lab3.DTL
{
    public class Album
    {
        private int albumID;

        public int AlbumID
        {
            get { return albumID; }
            set { albumID = value; }
        }

        private int genreID;

        public int GenreID
        {
            get { return genreID; }
            set { genreID = value; }
        }
        private int artistID;

        public int ArtistID
        {
            get { return artistID; }
            set { artistID = value; }
        }

        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string AlbumUrl { get => albumUrl; set => albumUrl = value; }

        string albumUrl;



        public static bool Delete(Album album)
        {
            return AlbumDAO.Delete(album);
        }
    }
}

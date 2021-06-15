using SE1438_G5_Lab3.DAL;
using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_G5_Lab3.GUI
{
    public partial class AlbumDetailGUI : Form
    {
        private Album album;

        public AlbumDetailGUI(int albumID)
        {
            InitializeComponent();
            album = AlbumDAO.GetAlbumByID(albumID);

            txtTitle.Text = album.Title;
            txtPrice.Text = album.Price.ToString();
            txtArtist.Text = ArtistDAO.GetArtistByID(album.ArtistID).Name;
            txtGenre.Text = GenreDAO.GetGenreByID(album.GenreID).Name;
            String path = album.AlbumUrl.Replace('/', '\\');
            pictureBox1.Image = Image.FromFile(getProjectPath() + path);

        }
        private string getProjectPath()
        {
            string path = Application.StartupPath;
            DirectoryInfo di = new DirectoryInfo(path);
            for (int i = 0; i < 2; i++)
            {
                di = Directory.GetParent(di.FullName);
            }
            return di.FullName;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(album != null)
            {
                ShoppingCartDAO.GetCart().AddToCart(album.AlbumID);

                MainGUI.GetMainGui().displayMenu();
                //CartGUI cart = new CartGUI();
                //cart.ShowDialog();
                MessageBox.Show("Add to cart completed!");
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

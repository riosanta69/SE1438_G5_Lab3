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
        public AlbumDetailGUI(int albumID)
        {
            InitializeComponent();
            Album album = AlbumDAO.GetAlbumByID(albumID);

            textBox1.Text = album.Title;
            textBox2.Text = album.Price.ToString();
            textBox3.Text = ArtistDAO.GetArtistByID(album.ArtistID).Name;
            textBox4.Text = GenreDAO.GetGenreByID(album.GenreID).Name;
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
            CartGUI cart = new CartGUI();
            cart.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StoreGUI store = new StoreGUI();
            store.Show();
        }
    }
}

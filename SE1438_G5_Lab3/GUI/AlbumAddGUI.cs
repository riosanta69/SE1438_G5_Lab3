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
    public partial class AlbumAddGUI : Form
    {
        //private string mode;
        private Album album;
        private Genre genre;
        private Artist artist;

        public List<Genre> Genres { get; }
        public List<Artist> Artists { get; }

        public AlbumAddGUI()
        {
            InitializeComponent();

            List<Genre> genres = (List<Genre>)GenreDAO.GetGenres();
            List<Artist> artists = (List<Artist>)ArtistDAO.GetArtists();

            comboBox1.DataSource = genres;
            comboBox1.DisplayMember = "Name";

            comboBox2.DataSource = artists;
            comboBox2.DisplayMember = "Name";

            //mode = "add";
        }
 

        public AlbumAddGUI(Album album, Genre genre, Artist artist)
        {
            List<Genre> genres = (List<Genre>)GenreDAO.GetGenres();
            List<Artist> artists = (List<Artist>)ArtistDAO.GetArtists();
            InitializeComponent();
            this.album = album;
            this.genre = genre;
            this.artist = artist;
            textBox1.Text = album.Title;

            comboBox1.DataSource = genres;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = comboBox1.FindStringExact(genre.Name);

            comboBox2.DataSource = artists;
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedIndex = comboBox2.FindStringExact(artist.Name);

            textBox2.Text = album.Price.ToString();
            textBox3.Text = album.AlbumUrl;

            //mode = "edit";
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


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = album.AlbumUrl.Replace('/', '\\');
            pictureBox1.Image = Image.FromFile(getProjectPath() + path);

            OpenFileDialog opf = new OpenFileDialog
            {
                InitialDirectory = getProjectPath() + "\\Images\\",
                Title = "Select image file",
                Filter = "Gif files (*.gif)|*.gif| Png files (*.png)|*.png",
                FilterIndex = 1,
                CheckFileExists = true,
                CheckPathExists = true
            };
            if (opf.ShowDialog() == DialogResult.OK)
            {
                string ext = opf.FileName.Substring(opf.FileName.IndexOf('.'));
                string filename = Guid.NewGuid().ToString() + ext;
                string fileDest = getProjectPath() + "\\Images\\" + filename;
                File.Copy(opf.FileName, fileDest);
                textBox3.Text = "/Images/" + filename;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AlbumAddGUI_Load(object sender, EventArgs e)
        {
            button2.Click += addEvent;
            button2.Click += editEvent;
        }

        private void editEvent(object sender, EventArgs e)
        {
            Album updatedAlbum = new Album()
            {
                Title = textBox1.Text,
                Price = double.Parse(textBox2.Text),
                AlbumUrl = textBox3.Text,
            };
            AlbumDAO.Update(updatedAlbum);
        }

        private void addEvent(object sender, EventArgs e)
        {
            Album addAlbum = new Album()
            {
                Title = textBox1.Text,
                Price = double.Parse(textBox2.Text),
                AlbumUrl = textBox3.Text,
            };
            AlbumDAO.Insert(addAlbum);
        }
    }
}

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
        private string mode;
        private Album album;
        private Genre genre;
        private Artist artist;

        public List<Genre> Genres { get; }
        public List<Artist> Artists { get; }

        private AlbumGUI albumGUI;

        public void setAlbumGUI(AlbumGUI albumGUI)
        {
            this.albumGUI = albumGUI;
        }

        public AlbumAddGUI()
        {
            InitializeComponent();

            List<Genre> genres = (List<Genre>)GenreDAO.GetGenres();
            List<Artist> artists = (List<Artist>)ArtistDAO.GetArtists();

            cboGenre.DataSource = genres;
            cboGenre.DisplayMember = "Name";

            cboArtist.DataSource = artists;
            cboArtist.DisplayMember = "Name";

            mode = "add";
        }
 

        public AlbumAddGUI(Album album, Genre genre, Artist artist)
        {
            List<Genre> genres = (List<Genre>)GenreDAO.GetGenres();
            List<Artist> artists = (List<Artist>)ArtistDAO.GetArtists();
            InitializeComponent();
            this.album = album;
            this.genre = genre;
            this.artist = artist;
            txtTitle.Text = album.Title;

            cboGenre.DataSource = genres;
            cboGenre.DisplayMember = "Name";
            cboGenre.SelectedIndex = cboGenre.FindStringExact(genre.Name);

            cboArtist.DataSource = artists;
            cboArtist.DisplayMember = "Name";
            cboArtist.SelectedIndex = cboArtist.FindStringExact(artist.Name);

            txtPrice.Text = album.Price.ToString();
            txtAlbumUrl.Text = album.AlbumUrl;

            mode = "edit";
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


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        

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
                txtAlbumUrl.Text = "/Images/" + filename;
                pictureBox1.Image = Image.FromFile(fileDest);
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
            if(mode.Equals("add"))
                btnSave.Click += addEvent;
            if(mode.Equals("edit"))
                btnSave.Click += editEvent;
        }

        private void editEvent(object sender, EventArgs e)
        {

            album.Title = txtTitle.Text;
            album.Price = double.Parse(txtPrice.Text);
            album.AlbumUrl = txtAlbumUrl.Text;

            if (AlbumDAO.Update(album)) {
                albumGUI.initialize();
                Close();
            }
        }

        private void addEvent(object sender, EventArgs e)
        {
            Album addAlbum = new Album()
            {
                Title = txtTitle.Text,
                Price = double.Parse(txtPrice.Text),
                AlbumUrl = txtAlbumUrl.Text,
                GenreID = ((Genre) cboGenre.SelectedItem).GenreID,
                ArtistID =((Artist) cboArtist.SelectedItem).ArtistID,
            };
            if (AlbumDAO.Insert(addAlbum))
            {
                albumGUI.initialize();
                Close();
            }
        }
    }
}

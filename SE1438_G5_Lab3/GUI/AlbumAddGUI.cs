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
        Album album;
        Genre genre;
        Artist artist;

        public AlbumAddGUI()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = genre;
            //comboBox1.
        }

        public AlbumAddGUI(Album album, List<Genre> genres, List<Artist> artists, Genre genre, Artist artist)
        {
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
            //string path = album.AlbumUrl.Replace('/', '\\');
            //pictureBox1.Image = Image.FromFile(getProjectPath() + path);




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
    }
}

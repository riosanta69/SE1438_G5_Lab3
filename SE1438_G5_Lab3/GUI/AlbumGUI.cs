using SE1438_G5_Lab3.DAL;
using SE1438_G5_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE1438_G5_Lab3.GUI
{
    public partial class AlbumGUI : Form
    {
        private List<Genre> genres;
        private List<Artist> artists;

        public AlbumGUI()
        {
            InitializeComponent();
            dataGridView1.DataSource = AlbumDAO.GetAlbums();

            genres = (List<Genre>)GenreDAO.GetGenres();
            artists = (List<Artist>)ArtistDAO.GetArtists();

            bindGrid1();
            bindGrid2();
            bindGrid3();
        }
        private void bindGrid1()
        {
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn()
            {
                Name = "Detail",
                Text = "Detail",
                UseColumnTextForButtonValue = true
            };
        int count = dataGridView1.Columns.Count;
        dataGridView1.Columns.Insert(count, btnDetail);
        }

        private void bindGrid2()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn()
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            int count = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(count, btnEdit);
        }

        private void bindGrid3()
        {
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn()
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            int count = dataGridView1.Columns.Count;
            dataGridView1.Columns.Insert(count, btnDelete);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AlbumAddGUI a = new AlbumAddGUI();
            a.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Album album = ((List<Album>)dataGridView1.DataSource)[e.RowIndex];
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                DialogResult result = MessageBox.Show("Do you want to delete this album?",
     
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    );
                if (result == DialogResult.Yes)
                {
                    bool count = Album.Delete(album);
                    if (count == true)
                    {
                        MessageBox.Show("Delete complete !");

                    }
                    else
                        MessageBox.Show("Can not delete this album!");
                }

            }
            if (e.ColumnIndex == dataGridView1.Columns["Detail"].Index)
            {
                int albumID =(int) dataGridView1.Rows[e.RowIndex].Cells["albumID"].Value;
                AlbumDetailGUI formdetail = new AlbumDetailGUI(albumID);
                formdetail.ShowDialog();
            }
            if(e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                Genre genre = genres.Find(g => g.GenreID == album.GenreID);
                Artist artist = artists.Find(a => a.ArtistID == album.ArtistID);
                AlbumAddGUI newform = new AlbumAddGUI(album, genres, artists ,genre,artist);
                newform.ShowDialog();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutGUI about = new AboutGUI();
            about.ShowDialog();
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartGUI cart = new CartGUI();
            cart.ShowDialog();
        }
    }
}

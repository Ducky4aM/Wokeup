using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infrastructure;
using Infrastructure.DTO;
using Domain;

namespace Wokeup
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MusicApp musicApp = new MusicApp();
            List<Song> songs = (List<Song>)musicApp.SongCollection;

            foreach (Song song in songs)
            {
                Bitmap? image = LoadImageFromUrl(song.image);
                dgvTopSong.Rows.Add(song.ToString(), image, "asd");
            }

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvTopSong.Columns[1];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private Bitmap? LoadImageFromUrl(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return new Bitmap(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private void dgvTopSong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTopSong.SelectedRows[0].Cells[1].Value.ToString() != "")
            {
                Bitmap songImage = (Bitmap)dgvTopSong.SelectedRows[0].Cells[1].Value;
                pbDisplaySongImage.Image = songImage;
            }
        }
    }
}

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
        MusicApp musicApp;
        User user;
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.musicApp = new MusicApp(user);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IReadOnlyList<Song> songs = (IReadOnlyList<Song>)musicApp.GetTopListenedSongs;

            foreach (Song song in songs)
            {
                Bitmap? image = LoadImageFromUrl(song.image);
                dgvTopSong.Rows.Add(song, image, "artist");
            }

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvTopSong.Columns[1];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            Load_Favorite_list();
        }

        private void Load_Favorite_list()
        {
            IReadOnlyList<FavoriteList> favoriteLists = this.user.GetUserFavoriteLists();

            foreach (FavoriteList favoriteList in favoriteLists)
            {
                dgvFavoriteList.Rows.Add(favoriteList);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(user.id.ToString());
        }

        private Bitmap? LoadImageFromUrl(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
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

        private void btnCreatFavoriteList_Click(object sender, EventArgs e)
        {
            dgvFavoriteList.Rows.Clear();
            this.Visible = false;
            AddFavoriteListFOrm f = new AddFavoriteListFOrm(this.user);
            f.ShowDialog();
            this.Visible = true;
            Load_Favorite_list();
        }

        private void btnRemoveFavoriteList_Click(object sender, EventArgs e)
        {
            if (dgvTopSong.SelectedRows.Count > 0)
            {
                // Access the cell containing the FavoriteList
                FavoriteList favoriteList = dgvTopSong.SelectedRows[0].DataBoundItem as FavoriteList;

                if (favoriteList != null)
                {
                    MessageBox.Show(favoriteList.name);
                }
            }

        }
    }
}

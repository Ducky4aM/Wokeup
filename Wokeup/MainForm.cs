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
using Org.BouncyCastle.Utilities;

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
            lsbFavoriteList.Items.Clear();

            foreach (FavoriteList favoriteList in favoriteLists)
            {
                lsbFavoriteList.Items.Add(favoriteList);
            }
        }

        private void LoadSongFromFavorite(IReadOnlyList<Song> songs)
        {
            dgvSongOfFavoriteList.Rows.Clear();

            foreach (Song song in songs)
            {
                Bitmap? image = LoadImageFromUrl(song.image);
                dgvSongOfFavoriteList.Rows.Add(song, image, "artist");
            }

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvSongOfFavoriteList.Columns[1];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
            lsbFavoriteList.Items.Clear();
            this.Visible = false;
            AddFavoriteListFOrm f = new AddFavoriteListFOrm(this.user);
            f.ShowDialog();
            this.Visible = true;
            Load_Favorite_list();
        }

        private void btnRemoveFavoriteList_Click(object sender, EventArgs e)
        {
            FavoriteList? favoriteList = lsbFavoriteList.SelectedItem as FavoriteList;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {favoriteList.name}, The song on this list will alse be deleted",
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
                );

            if (result == DialogResult.OK)
            {
                bool removeFavoriteList = this.user.RemoveFavoriteList(favoriteList);

                if (removeFavoriteList == false)
                {
                    MessageBox.Show("Can't remove favorite list, please try again later!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Load_Favorite_list();
                    lsbFavoriteList.SelectedIndex = 0;
                }
            }

        }

        private void lsbFavoriteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbFavoriteList.SelectedIndex > -1)
            {
                FavoriteList? favoriteList = lsbFavoriteList.SelectedItem as FavoriteList;

                if (favoriteList != null)
                {
                    IReadOnlyList<Song> favoriteListSongs = favoriteList.GetSongs();

                    this.LoadSongFromFavorite(favoriteListSongs);
                }
            }
        }

        private void btnAddSongToFavoriteList_Click(object sender, EventArgs e)
        {
            if (dgvTopSong.SelectedRows.Count > 0)
            {
                Song? selectedSong = dgvTopSong.SelectedRows[0].Cells[0].Value as Song;
                Bitmap songImage = (Bitmap)dgvTopSong.SelectedRows[0].Cells[1].Value;

                if (selectedSong != null)
                {
                    this.Visible = false;
                    AddSongToFavoriteListForm f = new AddSongToFavoriteListForm(user, selectedSong, songImage);
                    f.ShowDialog();
                    this.Visible = true;
                }
            }
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTabPage = tbcMain.SelectedTab;
            if (selectedTabPage.Text == "Top song")
            {
                dgvTopSong.CurrentCell = dgvTopSong.Rows[0].Cells[0];
            }
            if (selectedTabPage.Text == "My favorite")
            {
                lsbFavoriteList.SelectedIndex = 0;
            }
        }

        private void dgvSongOfFavoriteList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSongOfFavoriteList.Columns["clmDeleteSongFromFavoriteList"].Index)
            {
                if (lsbFavoriteList.SelectedItem is FavoriteList selectedFavoriteList)
                {
                    bool isRemoved = selectedFavoriteList.RemoveSongFromFavoriteList(dgvSongOfFavoriteList.SelectedRows[0].Cells[0].Value as Song);

                    if (isRemoved == true)
                    {
                        this.LoadSongFromFavorite(selectedFavoriteList.GetSongs());
                    }
                    else
                    {
                        MessageBox.Show("Can't remove song, try again later!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

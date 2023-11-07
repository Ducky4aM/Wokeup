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
using Domain.Service;

namespace Wokeup
{
    public partial class MainForm : Form
    {
        SongService songService;
        User user;
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.songService = new SongService();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IReadOnlyList<Song> songs = this.songService.GetTopSongs();

            foreach (Song song in songs)
            {
                Bitmap? image = LoadImageFromUrl(song.image);
                dgvTopSong.Rows.Add(song, image, song.artist.name, song.genre.name);
            }

            DataGridViewImageColumn pic = new DataGridViewImageColumn();
            pic = (DataGridViewImageColumn)dgvTopSong.Columns[1];
            pic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            LoadFavoritelistToListBox();
            LoadGenreToComboBox(cmbFilterSong);
        }

        private void LoadFavoritelistToListBox()
        {
            FavoriteListService favoriteListService = new FavoriteListService(this.user);
            IReadOnlyList<FavoriteList> favoriteLists = favoriteListService.GetUserFavoriteLists();

            lsbFavoriteList.Items.Clear();

            foreach (FavoriteList favoriteList in favoriteLists)
            {
                lsbFavoriteList.Items.Add(favoriteList);
            }
        }

        private void LoadGenreToComboBox(ComboBox comboBox)
        {
            GenreService genreService = new GenreService();
            IReadOnlyList<Genre> Genres = genreService.GetAllGenre();

            foreach (Genre genre in Genres)
            {
                comboBox.Items.Add(genre);
            }

            comboBox.SelectedIndex = 0;
        }

        private void LoadSongFromFavoriteToDataTable(IReadOnlyList<Song>? songs)
        {
            if (songs == null)
            {
                return;
            }

            dgvSongOfFavoriteList.Rows.Clear();

            foreach (Song song in songs)
            {
                Bitmap? image = LoadImageFromUrl(song.image);
                dgvSongOfFavoriteList.Rows.Add(song, image, song.artist.name);
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
            LoadFavoritelistToListBox();
        }

        private void btnRemoveFavoriteList_Click(object sender, EventArgs e)
        {
            FavoriteList? favoriteList = lsbFavoriteList.SelectedItem as FavoriteList;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete `{favoriteList.name}`, The song on this list will also be deleted",
                "Warning",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
                );

            if (result == DialogResult.OK)
            {
                FavoriteListService favoriteListService = new FavoriteListService(this.user);
                ServiceStatusJob removeFavoriteListStatus = favoriteListService.RemoveFavoriteList(favoriteList);

                if (removeFavoriteListStatus.isSuccess == false)
                {
                    MessageBox.Show(
                        removeFavoriteListStatus.messageText,
                        removeFavoriteListStatus.messageTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else
                {
                    LoadFavoritelistToListBox();
                    lsbFavoriteList.SelectedIndex = 0;
                }
            }

        }

        private void lsbFavoriteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbFavoriteList.SelectedIndex > -1)
            {
                FavoriteList? favoriteList = lsbFavoriteList.SelectedItem as FavoriteList;
                FavoriteListService favoriteListService = new FavoriteListService(this.user);

                ServiceStatusJob serviceStatusJob = favoriteListService.getSongsFromFavoriteList(favoriteList);

                if (serviceStatusJob.isSuccess == false)
                {
                    MessageBox.Show(serviceStatusJob.messageText, serviceStatusJob.messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.LoadSongFromFavoriteToDataTable(favoriteList.GetSongs());
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
                if (lsbFavoriteList.Items.Count > 0)
                {
                    lsbFavoriteList.SelectedIndex = 0;
                    FavoriteList favoriteList = lsbFavoriteList.SelectedItem as FavoriteList;
                    this.LoadSongFromFavoriteToDataTable(favoriteList.GetSongs());
                }
            }
        }

        private void dgvSongOfFavoriteList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSongOfFavoriteList.Columns["clmDeleteSongFromFavoriteList"].Index)
            {
                if (lsbFavoriteList.SelectedItem is FavoriteList selectedFavoriteList)
                {
                    Song? song = dgvSongOfFavoriteList.SelectedRows[0].Cells[0].Value as Song;
                    FavoriteListService favoriteListService = new FavoriteListService(this.user);

                    ServiceStatusJob serviceStatusJob = favoriteListService.removeSongInFavoriteList(song, selectedFavoriteList);

                    if (serviceStatusJob.isSuccess == false)
                    {
                        MessageBox.Show(serviceStatusJob.messageText, serviceStatusJob.messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.LoadSongFromFavoriteToDataTable(selectedFavoriteList.GetSongs());
                    }
                }
            }
        }

        private void cmbFilterSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterSong.SelectedIndex > 0)
            {
                Genre genre = cmbFilterSong.SelectedItem as Genre;
                SongService songService = new SongService();

                LoadSongFromFavoriteToDataTable(songService.GetSongsBaseOnGenre(genre));
            }
        }
    }
}

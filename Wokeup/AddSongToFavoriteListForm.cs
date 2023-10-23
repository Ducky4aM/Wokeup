using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wokeup
{
    public partial class AddSongToFavoriteListForm : Form
    {
        User user;
        Song selectedSong;
        Bitmap songImage;
        public AddSongToFavoriteListForm(User user, Song selectedSong, Bitmap songImage)
        {
            InitializeComponent();

            this.user = user;
            this.selectedSong = selectedSong;
            this.songImage = songImage;
        }

        private void AddSongToFavoriteListForm_Load(object sender, EventArgs e)
        {
            lblSongTitle.Text = selectedSong.ToString();
            pcbAddSongToFavoriteList.Image = this.songImage;

            IReadOnlyList<FavoriteList> favoriteLists = user.GetUserFavoriteLists();

            foreach (FavoriteList favoriteList in favoriteLists)
            {
                cmbSelectFavoriteList.Items.Add(favoriteList);
            }
        }

        private void btnConfirmAddSongToFavoriteList_Click(object sender, EventArgs e)
        {
            FavoriteList? favoriteList = cmbSelectFavoriteList.SelectedItem as FavoriteList;

            if (favoriteList != null)
            {
                bool addSongToFavoriteList = favoriteList.AddSongToFavoriteList(selectedSong);

                if (addSongToFavoriteList == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(
                       $"Song has already been added to {favoriteList.name} list, select another list!",
                       "Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning
                       );
                }
            }
        }

        private void BtnCancelAddSongToFavorite_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

using Domain;
using Domain.Interface;
using Domain.Service;
using Infrastructure;
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
        IUser user;
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

            IReadOnlyList<IFavoriteList> favoriteLists = user.GetFavoriteLists();

            foreach (FavoriteList favoriteList in favoriteLists)
            {
                cmbSelectFavoriteList.Items.Add(favoriteList);
            }
        }

        private void btnConfirmAddSongToFavoriteList_Click(object sender, EventArgs e)
        {
            if (cmbSelectFavoriteList.SelectedItem is FavoriteList favoriteList)
            {
                FavoriteListService favoriteListService = new FavoriteListService(this.user, new FavoriteListRepository());

                ServiceStatusResult serviceStatusJob = favoriteListService.AddSongToFavoriteList(selectedSong, favoriteList);

                if (serviceStatusJob.isSuccess == false)
                {
                    MessageBox.Show(
                    serviceStatusJob.messageText,
                    serviceStatusJob.messageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void BtnCancelAddSongToFavorite_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

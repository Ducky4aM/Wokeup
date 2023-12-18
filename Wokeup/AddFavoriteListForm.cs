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
using System.Xml.Linq;

namespace Wokeup
{
    public partial class AddFavoriteListFOrm : Form
    {
        IUser user;
        public AddFavoriteListFOrm(IUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnAddFavoriteList_Click(object sender, EventArgs e)
        {
            if (txbAddFavoriteList.Text == "")
            {
                MessageBox.Show(
                   "field name can't be empty!",
                   "Warnnig",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
                   );

                return;
            }

            FavoriteListService favoriteListService = new FavoriteListService(this.user, new FavoriteListRepository());
            ServiceStatusResult statusMessage = favoriteListService.CreateFavoriteList(new FavoriteList(txbAddFavoriteList.Text));

            if (statusMessage.isSuccess == false)
            {
                MessageBox.Show(
                    statusMessage.messageText,
                    statusMessage.messageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return;
            }

            MessageBox.Show(
                statusMessage.messageText,
                statusMessage.messageTitle,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelAddFavoriteList_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

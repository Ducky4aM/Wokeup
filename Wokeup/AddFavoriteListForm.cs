using Domain;
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
    public partial class AddFavoriteListFOrm : Form
    {
        User user;
        public AddFavoriteListFOrm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnAddFavoriteList_Click(object sender, EventArgs e)
        {
            FavoriteListService favoriteListService = new FavoriteListService(this.user);
            ServiceStatusJob statusMessage = favoriteListService.CreateFavoriteList(txbAddFavoriteList.Text);

            if (statusMessage.isSuccess == false)
            {
                MessageBox.Show(
                    statusMessage.messageText,
                    statusMessage.messageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            else
            {
                MessageBox.Show(
                    statusMessage.messageText,
                    statusMessage.messageTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelAddFavoriteList_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

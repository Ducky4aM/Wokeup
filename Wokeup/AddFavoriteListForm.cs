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
using System.Xml.Linq;

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
            // eerste fout checken.
            // if(txbAddFavoriteList.Text == "") {message box + return}

            if (txbAddFavoriteList.Text != "")
            {
                FavoriteListService favoriteListService = new FavoriteListService(this.user);
                ServiceStatusResult statusMessage = favoriteListService.CreateFavoriteList(txbAddFavoriteList.Text);

                if (statusMessage.isSuccess == false)
                {
                    MessageBox.Show(
                        statusMessage.messageText,
                        statusMessage.messageTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                // hier ook met isSuccess == true. niet met else
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
            else
            {
                MessageBox.Show(
                    "field name can't be empty!",
                    "Warnnig",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }

        }

        private void btnCancelAddFavoriteList_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

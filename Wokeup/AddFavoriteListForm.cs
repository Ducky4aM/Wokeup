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
            bool isAddNewFavoriteList = user.CreateNewFavoriteList(txbAddFavoriteList.Text);

            if (isAddNewFavoriteList == false)
            {
                MessageBox.Show(
                    $"Favorite list with name: {txbAddFavoriteList.Text} already exsit, please try other name!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelAddFavoriteList_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

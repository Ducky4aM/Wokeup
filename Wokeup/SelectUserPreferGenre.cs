﻿using Domain;
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
    public partial class frmSelectedFavoriteGenre : Form
    {
        User user;

        public frmSelectedFavoriteGenre(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void frmSelectedFavoriteGenre_Load(object sender, EventArgs e)
        {
            GenreService genreService = new GenreService(new GenreRepository());

            IReadOnlyList<Genre> genres = genreService.GetAllGenre();

            foreach (Genre genre in genres)
            {
                cmbSelectedPreferGenre.Items.Add(genre);
            }
        }

        private void OpenMainForm()
        {
            this.Hide();
            MainForm mainForm = new MainForm(user);
            mainForm.TopMost = true;
            mainForm.ShowDialog();
            mainForm.Focus();
        }

        private void btnConfirmSelectedFavortieGenre_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService(this.user);

            if (cmbSelectedPreferGenre.SelectedItem is Genre selectedGenre)
            {
               ServiceStatusResult result = userService.setUserPreferGenre(selectedGenre);

                if (result.isSuccess == false)
                {
                    MessageBox.Show(result.messageText, result.messageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OpenMainForm();
            }
        }

        private void btnSkipSelectFavoriteGenre_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }
    }
}

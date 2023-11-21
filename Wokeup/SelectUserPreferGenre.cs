using Domain;
using Domain.Service;
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
            GenreService genreService = new GenreService();

            IReadOnlyList<Genre> genres = genreService.GetAllGenre();

            foreach (Genre genre in genres)
            {
                cmbSelectedPreferGenre.Items.Add(genre.ToString());
            }
        }

        private void btnConfirmSelectedFavortieGenre_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSkipSelectFavoriteGenre_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(user);
            mainForm.TopMost = true;
            mainForm.ShowDialog();
            mainForm.Focus();
        }
    }
}

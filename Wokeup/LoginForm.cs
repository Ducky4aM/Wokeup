using Domain;
using Domain.Helper;
using Domain.Service;
using Domain.Service.Auth;
using Infrastructure;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Wokeup
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void OpenMainForm(User user)
        {
            this.Hide();
            MainForm mainForm = new MainForm(user);
            mainForm.TopMost = true;
            mainForm.ShowDialog();
            mainForm.Focus();
        }

        private void OpenSelectedPreferGenreForm(User user)
        {
            this.Hide();
            frmSelectedFavoriteGenre frm = new frmSelectedFavoriteGenre(user);
            frm.TopMost = true;
            frm.ShowDialog();
            frm.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbUsername.Text == "" || txbPassword.Text == "")
            {
                MessageBox.Show("Empty username or password", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            AuthenticationService authenticationService = new AuthenticationService(new UserRepository());
            AuthenticationResult authenicationResult = authenticationService.AuthUser(new User(txbUsername.Text, txbPassword.Text));

            if (authenicationResult.AuthenticationStatus != null)
            {
                MessageBox.Show(
                    authenicationResult.AuthenticationStatus.messageText,
                    authenicationResult.AuthenticationStatus.messageTitle
                    , MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );

                return;
            }

            User inlogedUser = authenicationResult.AuthenticatedUser;
            MessageBox.Show($"Welcome {inlogedUser.name}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // if user nor choose a prefer genre yet, ask or user want to select a prefer gerne (optional)
            if (inlogedUser.GetPreferGenre() == null)
            {
                DialogResult msbPreferGenreResult = MessageBox.Show(
                "It look like you not selected prefer genre yet! do you want to select a genre ?",
                "Prefer genre",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
                );

                if (msbPreferGenreResult == DialogResult.Yes)
                {
                    this.OpenSelectedPreferGenreForm(inlogedUser);
                }

                if (msbPreferGenreResult == DialogResult.No)
                {
                    this.OpenMainForm(inlogedUser);
                }
            }

            // if user already chose a prefer genre open main form.
            if (inlogedUser.GetPreferGenre() != null)
            {   
                this.OpenMainForm(inlogedUser);
            }
        }

        private void btnOpenSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.TopMost = true;
            signUpForm.ShowDialog();
            signUpForm.Focus();
        }
    }
}
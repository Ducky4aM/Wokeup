using Domain;
using Domain.Auth;
using Infrastructure;
using Infrastructure.DTO;
using MySql.Data.MySqlClient;

namespace Wokeup
{
    public partial class frmLogin : Form
    {
        private UserRepository userRepository = new UserRepository();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void OpenMainForm(User user)
        {
            this.Hide();
            MainForm mainForm = new MainForm(user);
            mainForm.TopMost = true;
            mainForm.ShowDialog();
            mainForm.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbUsername.Text == "" || txbPassword.Text == "")
            {
                MessageBox.Show("Empty username or password", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            else
            {
                Authentication authentication = new Authentication();
                AuthenicationResult authenicationResult = authentication.AuthUser(txbUsername.Text, txbPassword.Text);

                if (authenicationResult.AuthenticationStatus != null)
                {
                    MessageBox.Show(
                        authenicationResult.AuthenticationStatus.messageText,
                        authenicationResult.AuthenticationStatus.messageTitle
                        , MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
                if (authenicationResult.AuthenticatedUser != null)
                {
                    MessageBox.Show($"Welcome {authenicationResult.AuthenticatedUser.name}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.OpenMainForm(authenicationResult.AuthenticatedUser);
                }
            }
        }
    }
}
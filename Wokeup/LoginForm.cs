using Infrastructure;
using Infrastructure.DbConnect;
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void OpenMainForm()
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.TopMost = true;
            mainForm.ShowDialog();
            mainForm.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //UserDTO user = UserRepository.AuthUser(txbUsername.Text.ToLower(), txbPassword.Text);

            //if (user == null)
            //{
            //    MessageBox.Show("Login failed. Invalid username or password.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //if (user != null)
            //{
            //    MessageBox.Show($"Welcome {txbUsername.Text}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    this.OpenMainForm();
            //}

            this.OpenMainForm();
        }
    }
}
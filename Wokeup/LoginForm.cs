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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txbUsername.Text;
            password = txbPassword.Text;

            if (username == "duc" && password == "123")
            {
                MessageBox.Show("login");
            }

            MessageBox.Show("not correct");
        }
    }
}
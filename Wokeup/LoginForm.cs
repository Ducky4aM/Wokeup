using Infrastructure.DbConnect;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=3306;Database=wokeup;Uid=root;Pwd=password;";

            try
            {
                Connection.connOpen();

                string sql = "SELECT * FROM user";
                MySqlCommand cmd = new MySqlCommand(sql, Connection.DbConnect());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MessageBox.Show(reader["username"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
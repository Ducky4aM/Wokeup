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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            lblConfirmPasswordControlText.Visible = false;
        }


        private void btnConfirmRegister_Click(object sender, EventArgs e)
        {
        }

        private void txbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            lblConfirmPasswordControlText.Visible = true;

            string password = txbPassword.Text;
            string confirmPassword = txbConfirmPassword.Text;

            if (confirmPassword != password)
            {
                lblConfirmPasswordControlText.Text = "Passwords do not match";
                lblConfirmPasswordControlText.ForeColor = Color.Red;

                return;
            }

            lblConfirmPasswordControlText.Text = "Password Matches!";
            lblConfirmPasswordControlText.ForeColor = Color.Green;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginform = new frmLogin();
            loginform.TopMost = true;
            loginform.ShowDialog();
            loginform.Focus();
        }
    }
}

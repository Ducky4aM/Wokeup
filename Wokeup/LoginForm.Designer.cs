namespace Wokeup
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txbUsername = new TextBox();
            txbPassword = new TextBox();
            lblUserName = new Label();
            lblPassword = new Label();
            lblWelcome = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.Location = new Point(156, 208);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 35);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txbUsername
            // 
            txbUsername.Location = new Point(156, 112);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(180, 23);
            txbUsername.TabIndex = 1;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(156, 160);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(180, 23);
            txbPassword.TabIndex = 2;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblUserName.Location = new Point(70, 113);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(70, 17);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblPassword.Location = new Point(70, 161);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.Location = new Point(156, 62);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(93, 25);
            lblWelcome.TabIndex = 3;
            lblWelcome.Text = "Welcome";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 342);
            Controls.Add(lblPassword);
            Controls.Add(lblWelcome);
            Controls.Add(lblUserName);
            Controls.Add(txbPassword);
            Controls.Add(txbUsername);
            Controls.Add(btnLogin);
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txbUsername;
        private TextBox txbPassword;
        private Label lblUserName;
        private Label lblPassword;
        private Label lblWelcome;
    }
}
namespace Wokeup
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPassword = new Label();
            lblWelcome = new Label();
            lblUserName = new Label();
            txbPassword = new TextBox();
            txbUsername = new TextBox();
            btnLogin = new Button();
            btnConfirmRegister = new Button();
            txbConfirmPassword = new TextBox();
            label1 = new Label();
            lblConfirmPasswordControlText = new Label();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblPassword.Location = new Point(18, 125);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.Location = new Point(143, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(145, 25);
            lblWelcome.TabIndex = 8;
            lblWelcome.Text = "Create account";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblUserName.Location = new Point(18, 81);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(70, 17);
            lblUserName.TabIndex = 9;
            lblUserName.Text = "Username";
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(143, 119);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(180, 23);
            txbPassword.TabIndex = 6;
            txbPassword.UseSystemPasswordChar = true;
            // 
            // txbUsername
            // 
            txbUsername.Location = new Point(143, 75);
            txbUsername.Name = "txbUsername";
            txbUsername.Size = new Size(180, 23);
            txbUsername.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.Location = new Point(231, 210);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(92, 35);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnConfirmRegister
            // 
            btnConfirmRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirmRegister.Location = new Point(143, 210);
            btnConfirmRegister.Name = "btnConfirmRegister";
            btnConfirmRegister.Size = new Size(82, 35);
            btnConfirmRegister.TabIndex = 4;
            btnConfirmRegister.Text = "Register";
            btnConfirmRegister.UseVisualStyleBackColor = true;
            btnConfirmRegister.Click += btnConfirmRegister_Click;
            // 
            // txbConfirmPassword
            // 
            txbConfirmPassword.Location = new Point(143, 161);
            txbConfirmPassword.Name = "txbConfirmPassword";
            txbConfirmPassword.Size = new Size(180, 23);
            txbConfirmPassword.TabIndex = 6;
            txbConfirmPassword.UseSystemPasswordChar = true;
            txbConfirmPassword.TextChanged += txbConfirmPassword_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(18, 167);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 7;
            label1.Text = "Confirm password";
            // 
            // lblConfirmPasswordControlText
            // 
            lblConfirmPasswordControlText.AutoSize = true;
            lblConfirmPasswordControlText.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblConfirmPasswordControlText.ForeColor = Color.Red;
            lblConfirmPasswordControlText.Location = new Point(143, 148);
            lblConfirmPasswordControlText.Name = "lblConfirmPasswordControlText";
            lblConfirmPasswordControlText.Size = new Size(133, 13);
            lblConfirmPasswordControlText.TabIndex = 10;
            lblConfirmPasswordControlText.Text = "Passwords do not match";
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 257);
            Controls.Add(lblConfirmPasswordControlText);
            Controls.Add(label1);
            Controls.Add(lblPassword);
            Controls.Add(lblWelcome);
            Controls.Add(lblUserName);
            Controls.Add(txbConfirmPassword);
            Controls.Add(txbPassword);
            Controls.Add(txbUsername);
            Controls.Add(btnConfirmRegister);
            Controls.Add(btnLogin);
            Name = "SignUpForm";
            Text = "SignUpForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private Label lblWelcome;
        private Label lblUserName;
        private TextBox txbPassword;
        private TextBox txbUsername;
        private Button btnLogin;
        private Button btnConfirmRegister;
        private TextBox txbConfirmPassword;
        private Label label1;
        private Label lblConfirmPasswordControlText;
    }
}
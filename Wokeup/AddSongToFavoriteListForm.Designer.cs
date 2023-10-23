namespace Wokeup
{
    partial class AddSongToFavoriteListForm
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
            cmbSelectFavoriteList = new ComboBox();
            pcbAddSongToFavoriteList = new PictureBox();
            btnConfirmAddSongToFavoriteList = new Button();
            lblSongTitle = new Label();
            lblFavoriteListText = new Label();
            BtnCancelAddSongToFavorite = new Button();
            ((System.ComponentModel.ISupportInitialize)pcbAddSongToFavoriteList).BeginInit();
            SuspendLayout();
            // 
            // cmbSelectFavoriteList
            // 
            cmbSelectFavoriteList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectFavoriteList.FormattingEnabled = true;
            cmbSelectFavoriteList.Location = new Point(12, 134);
            cmbSelectFavoriteList.Name = "cmbSelectFavoriteList";
            cmbSelectFavoriteList.Size = new Size(181, 23);
            cmbSelectFavoriteList.TabIndex = 0;
            // 
            // pcbAddSongToFavoriteList
            // 
            pcbAddSongToFavoriteList.BackgroundImageLayout = ImageLayout.Stretch;
            pcbAddSongToFavoriteList.Location = new Point(212, 37);
            pcbAddSongToFavoriteList.Name = "pcbAddSongToFavoriteList";
            pcbAddSongToFavoriteList.Size = new Size(196, 166);
            pcbAddSongToFavoriteList.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbAddSongToFavoriteList.TabIndex = 1;
            pcbAddSongToFavoriteList.TabStop = false;
            // 
            // btnConfirmAddSongToFavoriteList
            // 
            btnConfirmAddSongToFavoriteList.Location = new Point(12, 163);
            btnConfirmAddSongToFavoriteList.Name = "btnConfirmAddSongToFavoriteList";
            btnConfirmAddSongToFavoriteList.Size = new Size(83, 40);
            btnConfirmAddSongToFavoriteList.TabIndex = 2;
            btnConfirmAddSongToFavoriteList.Text = "Add";
            btnConfirmAddSongToFavoriteList.UseVisualStyleBackColor = true;
            btnConfirmAddSongToFavoriteList.Click += btnConfirmAddSongToFavoriteList_Click;
            // 
            // lblSongTitle
            // 
            lblSongTitle.AutoSize = true;
            lblSongTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSongTitle.Location = new Point(12, 9);
            lblSongTitle.Name = "lblSongTitle";
            lblSongTitle.Size = new Size(57, 21);
            lblSongTitle.TabIndex = 3;
            lblSongTitle.Text = "label1";
            // 
            // lblFavoriteListText
            // 
            lblFavoriteListText.AutoSize = true;
            lblFavoriteListText.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblFavoriteListText.Location = new Point(13, 113);
            lblFavoriteListText.Name = "lblFavoriteListText";
            lblFavoriteListText.Size = new Size(77, 15);
            lblFavoriteListText.TabIndex = 4;
            lblFavoriteListText.Text = "Favorite list:";
            // 
            // BtnCancelAddSongToFavorite
            // 
            BtnCancelAddSongToFavorite.Location = new Point(101, 163);
            BtnCancelAddSongToFavorite.Name = "BtnCancelAddSongToFavorite";
            BtnCancelAddSongToFavorite.Size = new Size(82, 40);
            BtnCancelAddSongToFavorite.TabIndex = 5;
            BtnCancelAddSongToFavorite.Text = "button1";
            BtnCancelAddSongToFavorite.UseVisualStyleBackColor = true;
            BtnCancelAddSongToFavorite.Click += BtnCancelAddSongToFavorite_Click;
            // 
            // AddSongToFavoriteListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 207);
            Controls.Add(BtnCancelAddSongToFavorite);
            Controls.Add(lblFavoriteListText);
            Controls.Add(lblSongTitle);
            Controls.Add(btnConfirmAddSongToFavoriteList);
            Controls.Add(pcbAddSongToFavoriteList);
            Controls.Add(cmbSelectFavoriteList);
            Name = "AddSongToFavoriteListForm";
            Text = "AddSongToFavoriteListForm";
            Load += AddSongToFavoriteListForm_Load;
            ((System.ComponentModel.ISupportInitialize)pcbAddSongToFavoriteList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSelectFavoriteList;
        private PictureBox pcbAddSongToFavoriteList;
        private Button btnConfirmAddSongToFavoriteList;
        private Label lblSongTitle;
        private Label lblFavoriteListText;
        private Button BtnCancelAddSongToFavorite;
    }
}
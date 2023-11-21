namespace Wokeup
{
    partial class frmSelectedFavoriteGenre
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
            cmbSelectedPreferGenre = new ComboBox();
            lblSelectedFavoriteGenre = new Label();
            btnConfirmSelectedFavortieGenre = new Button();
            btnSkipSelectFavoriteGenre = new Button();
            SuspendLayout();
            // 
            // cmbSelectedPreferGenre
            // 
            cmbSelectedPreferGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectedPreferGenre.FormattingEnabled = true;
            cmbSelectedPreferGenre.Location = new Point(12, 72);
            cmbSelectedPreferGenre.Name = "cmbSelectedPreferGenre";
            cmbSelectedPreferGenre.Size = new Size(232, 23);
            cmbSelectedPreferGenre.TabIndex = 0;
            // 
            // lblSelectedFavoriteGenre
            // 
            lblSelectedFavoriteGenre.AutoSize = true;
            lblSelectedFavoriteGenre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSelectedFavoriteGenre.Location = new Point(12, 29);
            lblSelectedFavoriteGenre.Name = "lblSelectedFavoriteGenre";
            lblSelectedFavoriteGenre.Size = new Size(232, 21);
            lblSelectedFavoriteGenre.TabIndex = 1;
            lblSelectedFavoriteGenre.Text = "Choose one  genre (optional)";
            // 
            // btnConfirmSelectedFavortieGenre
            // 
            btnConfirmSelectedFavortieGenre.Location = new Point(12, 111);
            btnConfirmSelectedFavortieGenre.Name = "btnConfirmSelectedFavortieGenre";
            btnConfirmSelectedFavortieGenre.Size = new Size(75, 23);
            btnConfirmSelectedFavortieGenre.TabIndex = 2;
            btnConfirmSelectedFavortieGenre.Text = "Confirm";
            btnConfirmSelectedFavortieGenre.UseVisualStyleBackColor = true;
            btnConfirmSelectedFavortieGenre.Click += btnConfirmSelectedFavortieGenre_Click;
            // 
            // btnSkipSelectFavoriteGenre
            // 
            btnSkipSelectFavoriteGenre.Location = new Point(93, 111);
            btnSkipSelectFavoriteGenre.Name = "btnSkipSelectFavoriteGenre";
            btnSkipSelectFavoriteGenre.Size = new Size(75, 23);
            btnSkipSelectFavoriteGenre.TabIndex = 3;
            btnSkipSelectFavoriteGenre.Text = "Skip";
            btnSkipSelectFavoriteGenre.UseVisualStyleBackColor = true;
            btnSkipSelectFavoriteGenre.Click += btnSkipSelectFavoriteGenre_Click;
            // 
            // frmSelectedFavoriteGenre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 156);
            Controls.Add(btnSkipSelectFavoriteGenre);
            Controls.Add(btnConfirmSelectedFavortieGenre);
            Controls.Add(lblSelectedFavoriteGenre);
            Controls.Add(cmbSelectedPreferGenre);
            Name = "frmSelectedFavoriteGenre";
            Text = "Choose genre";
            Load += frmSelectedFavoriteGenre_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSelectedPreferGenre;
        private Label lblSelectedFavoriteGenre;
        private Button btnConfirmSelectedFavortieGenre;
        private Button btnSkipSelectFavoriteGenre;
    }
}
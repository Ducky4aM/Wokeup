namespace Wokeup
{
    partial class MainForm
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
            tbcMain = new TabControl();
            tbpSonglist = new TabPage();
            pbDisplaySongImage = new PictureBox();
            dgvTopSong = new DataGridView();
            button1 = new Button();
            tabPage2 = new TabPage();
            clmName = new DataGridViewTextBoxColumn();
            clmImage = new DataGridViewImageColumn();
            clmArtist = new DataGridViewTextBoxColumn();
            tbcMain.SuspendLayout();
            tbpSonglist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDisplaySongImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopSong).BeginInit();
            SuspendLayout();
            // 
            // tbcMain
            // 
            tbcMain.Controls.Add(tbpSonglist);
            tbcMain.Controls.Add(tabPage2);
            tbcMain.Location = new Point(2, 12);
            tbcMain.Name = "tbcMain";
            tbcMain.SelectedIndex = 0;
            tbcMain.Size = new Size(743, 503);
            tbcMain.TabIndex = 0;
            // 
            // tbpSonglist
            // 
            tbpSonglist.Controls.Add(pbDisplaySongImage);
            tbpSonglist.Controls.Add(dgvTopSong);
            tbpSonglist.Controls.Add(button1);
            tbpSonglist.Location = new Point(4, 24);
            tbpSonglist.Name = "tbpSonglist";
            tbpSonglist.Padding = new Padding(3);
            tbpSonglist.Size = new Size(735, 475);
            tbpSonglist.TabIndex = 0;
            tbpSonglist.Text = "TopSong";
            tbpSonglist.UseVisualStyleBackColor = true;
            // 
            // pbDisplaySongImage
            // 
            pbDisplaySongImage.Location = new Point(473, 6);
            pbDisplaySongImage.Name = "pbDisplaySongImage";
            pbDisplaySongImage.Size = new Size(258, 188);
            pbDisplaySongImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDisplaySongImage.TabIndex = 2;
            pbDisplaySongImage.TabStop = false;
            // 
            // dgvTopSong
            // 
            dgvTopSong.AllowUserToAddRows = false;
            dgvTopSong.AllowUserToDeleteRows = false;
            dgvTopSong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopSong.Columns.AddRange(new DataGridViewColumn[] { clmName, clmImage, clmArtist });
            dgvTopSong.Location = new Point(0, 200);
            dgvTopSong.Name = "dgvTopSong";
            dgvTopSong.ReadOnly = true;
            dgvTopSong.RowTemplate.Height = 70;
            dgvTopSong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopSong.Size = new Size(735, 233);
            dgvTopSong.TabIndex = 0;
            dgvTopSong.CellClick += dgvTopSong_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(6, 439);
            button1.Name = "button1";
            button1.Size = new Size(113, 31);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(735, 475);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // clmName
            // 
            clmName.FillWeight = 45.68528F;
            clmName.HeaderText = "Name";
            clmName.Name = "clmName";
            clmName.ReadOnly = true;
            clmName.Width = 301;
            // 
            // clmImage
            // 
            clmImage.FillWeight = 171.2557F;
            clmImage.HeaderText = "Image";
            clmImage.Name = "clmImage";
            clmImage.ReadOnly = true;
            clmImage.Width = 130;
            // 
            // clmArtist
            // 
            clmArtist.FillWeight = 83.05902F;
            clmArtist.HeaderText = "Artist";
            clmArtist.Name = "clmArtist";
            clmArtist.ReadOnly = true;
            clmArtist.Width = 270;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 518);
            Controls.Add(tbcMain);
            Name = "MainForm";
            Text = "Wokeup";
            Load += MainForm_Load;
            tbcMain.ResumeLayout(false);
            tbpSonglist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbDisplaySongImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopSong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcMain;
        private TabPage tbpSonglist;
        private TabPage tabPage2;
        private Button button1;
        private DataGridView dgvTopSong;
        private PictureBox pbDisplaySongImage;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewImageColumn clmImage;
        private DataGridViewTextBoxColumn clmArtist;
    }
}
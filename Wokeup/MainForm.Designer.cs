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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tbcMain = new TabControl();
            tbpSonglist = new TabPage();
            pbDisplaySongImage = new PictureBox();
            dgvTopSong = new DataGridView();
            clmName = new DataGridViewTextBoxColumn();
            clmImage = new DataGridViewImageColumn();
            clmArtist = new DataGridViewTextBoxColumn();
            clmTopSongGenre = new DataGridViewTextBoxColumn();
            btnAddSongToFavoriteList = new Button();
            tbpFavoriteList = new TabPage();
            lsbFavoriteList = new ListBox();
            dgvSongOfFavoriteList = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn1 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            clmDeleteSongFromFavoriteList = new DataGridViewButtonColumn();
            lblSongInFavoriteList = new Label();
            lblFavoriteList = new Label();
            btnRemoveFavoriteList = new Button();
            btnCreatFavoriteList = new Button();
            tbcMain.SuspendLayout();
            tbpSonglist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDisplaySongImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopSong).BeginInit();
            tbpFavoriteList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongOfFavoriteList).BeginInit();
            SuspendLayout();
            // 
            // tbcMain
            // 
            tbcMain.Controls.Add(tbpSonglist);
            tbcMain.Controls.Add(tbpFavoriteList);
            tbcMain.Location = new Point(2, 2);
            tbcMain.Name = "tbcMain";
            tbcMain.SelectedIndex = 0;
            tbcMain.Size = new Size(996, 513);
            tbcMain.TabIndex = 0;
            tbcMain.SelectedIndexChanged += tbcMain_SelectedIndexChanged;
            // 
            // tbpSonglist
            // 
            tbpSonglist.Controls.Add(pbDisplaySongImage);
            tbpSonglist.Controls.Add(dgvTopSong);
            tbpSonglist.Controls.Add(btnAddSongToFavoriteList);
            tbpSonglist.Location = new Point(4, 24);
            tbpSonglist.Name = "tbpSonglist";
            tbpSonglist.Padding = new Padding(3);
            tbpSonglist.Size = new Size(988, 485);
            tbpSonglist.TabIndex = 0;
            tbpSonglist.Text = "Top song";
            tbpSonglist.UseVisualStyleBackColor = true;
            // 
            // pbDisplaySongImage
            // 
            pbDisplaySongImage.BackgroundImage = (Image)resources.GetObject("pbDisplaySongImage.BackgroundImage");
            pbDisplaySongImage.BackgroundImageLayout = ImageLayout.Stretch;
            pbDisplaySongImage.Location = new Point(727, 6);
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
            dgvTopSong.AllowUserToResizeColumns = false;
            dgvTopSong.AllowUserToResizeRows = false;
            dgvTopSong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopSong.Columns.AddRange(new DataGridViewColumn[] { clmName, clmImage, clmArtist, clmTopSongGenre });
            dgvTopSong.Location = new Point(0, 200);
            dgvTopSong.Name = "dgvTopSong";
            dgvTopSong.ReadOnly = true;
            dgvTopSong.RowTemplate.Height = 70;
            dgvTopSong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopSong.Size = new Size(985, 282);
            dgvTopSong.TabIndex = 0;
            dgvTopSong.CellClick += dgvTopSong_CellClick;
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
            clmImage.Width = 200;
            // 
            // clmArtist
            // 
            clmArtist.FillWeight = 83.05902F;
            clmArtist.HeaderText = "Artist";
            clmArtist.Name = "clmArtist";
            clmArtist.ReadOnly = true;
            clmArtist.Width = 242;
            // 
            // clmTopSongGenre
            // 
            clmTopSongGenre.HeaderText = "Genre";
            clmTopSongGenre.Name = "clmTopSongGenre";
            clmTopSongGenre.ReadOnly = true;
            clmTopSongGenre.Width = 180;
            // 
            // btnAddSongToFavoriteList
            // 
            btnAddSongToFavoriteList.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddSongToFavoriteList.Location = new Point(0, 165);
            btnAddSongToFavoriteList.Name = "btnAddSongToFavoriteList";
            btnAddSongToFavoriteList.Size = new Size(138, 29);
            btnAddSongToFavoriteList.TabIndex = 1;
            btnAddSongToFavoriteList.Text = "Add to favorite list";
            btnAddSongToFavoriteList.UseVisualStyleBackColor = true;
            btnAddSongToFavoriteList.Click += btnAddSongToFavoriteList_Click;
            // 
            // tbpFavoriteList
            // 
            tbpFavoriteList.Controls.Add(lsbFavoriteList);
            tbpFavoriteList.Controls.Add(dgvSongOfFavoriteList);
            tbpFavoriteList.Controls.Add(lblSongInFavoriteList);
            tbpFavoriteList.Controls.Add(lblFavoriteList);
            tbpFavoriteList.Controls.Add(btnRemoveFavoriteList);
            tbpFavoriteList.Controls.Add(btnCreatFavoriteList);
            tbpFavoriteList.Location = new Point(4, 24);
            tbpFavoriteList.Name = "tbpFavoriteList";
            tbpFavoriteList.Padding = new Padding(3);
            tbpFavoriteList.Size = new Size(988, 485);
            tbpFavoriteList.TabIndex = 1;
            tbpFavoriteList.Text = "My favorite";
            tbpFavoriteList.UseVisualStyleBackColor = true;
            // 
            // lsbFavoriteList
            // 
            lsbFavoriteList.FormattingEnabled = true;
            lsbFavoriteList.ItemHeight = 15;
            lsbFavoriteList.Location = new Point(6, 57);
            lsbFavoriteList.Name = "lsbFavoriteList";
            lsbFavoriteList.Size = new Size(182, 364);
            lsbFavoriteList.TabIndex = 4;
            lsbFavoriteList.SelectedIndexChanged += lsbFavoriteList_SelectedIndexChanged;
            // 
            // dgvSongOfFavoriteList
            // 
            dgvSongOfFavoriteList.AllowUserToAddRows = false;
            dgvSongOfFavoriteList.AllowUserToDeleteRows = false;
            dgvSongOfFavoriteList.AllowUserToResizeColumns = false;
            dgvSongOfFavoriteList.AllowUserToResizeRows = false;
            dgvSongOfFavoriteList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSongOfFavoriteList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewImageColumn1, dataGridViewTextBoxColumn2, clmDeleteSongFromFavoriteList });
            dgvSongOfFavoriteList.Location = new Point(194, 57);
            dgvSongOfFavoriteList.Name = "dgvSongOfFavoriteList";
            dgvSongOfFavoriteList.ReadOnly = true;
            dgvSongOfFavoriteList.RowTemplate.Height = 70;
            dgvSongOfFavoriteList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSongOfFavoriteList.Size = new Size(795, 422);
            dgvSongOfFavoriteList.TabIndex = 3;
            dgvSongOfFavoriteList.CellClick += dgvSongOfFavoriteList_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.FillWeight = 45.68528F;
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewImageColumn1.FillWeight = 171.2557F;
            dataGridViewImageColumn1.HeaderText = "Image";
            dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            dataGridViewImageColumn1.ReadOnly = true;
            dataGridViewImageColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 83.05902F;
            dataGridViewTextBoxColumn2.HeaderText = "Artist";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 270;
            // 
            // clmDeleteSongFromFavoriteList
            // 
            clmDeleteSongFromFavoriteList.HeaderText = "Delete";
            clmDeleteSongFromFavoriteList.Name = "clmDeleteSongFromFavoriteList";
            clmDeleteSongFromFavoriteList.ReadOnly = true;
            clmDeleteSongFromFavoriteList.Text = "Delete";
            clmDeleteSongFromFavoriteList.UseColumnTextForButtonValue = true;
            // 
            // lblSongInFavoriteList
            // 
            lblSongInFavoriteList.AutoSize = true;
            lblSongInFavoriteList.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblSongInFavoriteList.Location = new Point(188, 22);
            lblSongInFavoriteList.Name = "lblSongInFavoriteList";
            lblSongInFavoriteList.Size = new Size(238, 32);
            lblSongInFavoriteList.TabIndex = 2;
            lblSongInFavoriteList.Text = "Song in favorite list";
            // 
            // lblFavoriteList
            // 
            lblFavoriteList.AutoSize = true;
            lblFavoriteList.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblFavoriteList.Location = new Point(6, 22);
            lblFavoriteList.Name = "lblFavoriteList";
            lblFavoriteList.Size = new Size(146, 32);
            lblFavoriteList.TabIndex = 2;
            lblFavoriteList.Text = "Favorite list";
            // 
            // btnRemoveFavoriteList
            // 
            btnRemoveFavoriteList.Location = new Point(100, 428);
            btnRemoveFavoriteList.Name = "btnRemoveFavoriteList";
            btnRemoveFavoriteList.Size = new Size(88, 51);
            btnRemoveFavoriteList.TabIndex = 1;
            btnRemoveFavoriteList.Text = "Remove";
            btnRemoveFavoriteList.UseVisualStyleBackColor = true;
            btnRemoveFavoriteList.Click += btnRemoveFavoriteList_Click;
            // 
            // btnCreatFavoriteList
            // 
            btnCreatFavoriteList.Location = new Point(3, 428);
            btnCreatFavoriteList.Name = "btnCreatFavoriteList";
            btnCreatFavoriteList.Size = new Size(91, 51);
            btnCreatFavoriteList.TabIndex = 1;
            btnCreatFavoriteList.Text = "Create";
            btnCreatFavoriteList.UseVisualStyleBackColor = true;
            btnCreatFavoriteList.Click += btnCreatFavoriteList_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 518);
            Controls.Add(tbcMain);
            Name = "MainForm";
            Text = "Wokeup";
            Load += MainForm_Load;
            tbcMain.ResumeLayout(false);
            tbpSonglist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbDisplaySongImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopSong).EndInit();
            tbpFavoriteList.ResumeLayout(false);
            tbpFavoriteList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSongOfFavoriteList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbcMain;
        private TabPage tbpSonglist;
        private TabPage tbpFavoriteList;
        private Button btnAddSongToFavoriteList;
        private DataGridView dgvTopSong;
        private PictureBox pbDisplaySongImage;
        private Button btnRemoveFavoriteList;
        private Button btnCreatFavoriteList;
        private Label lblSongInFavoriteList;
        private Label lblFavoriteList;
        private DataGridView dgvSongOfFavoriteList;
        private ListBox lsbFavoriteList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewButtonColumn clmDeleteSongFromFavoriteList;
        private DataGridViewTextBoxColumn clmName;
        private DataGridViewImageColumn clmImage;
        private DataGridViewTextBoxColumn clmArtist;
        private DataGridViewTextBoxColumn clmTopSongGenre;
    }
}
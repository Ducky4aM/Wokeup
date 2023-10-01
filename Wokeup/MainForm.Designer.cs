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
            listView1 = new ListView();
            tabPage2 = new TabPage();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            topsongToolStripMenuItem = new ToolStripMenuItem();
            menuToolStripMenuItem = new ToolStripMenuItem();
            tbcMain.SuspendLayout();
            tbpSonglist.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tbcMain
            // 
            tbcMain.Controls.Add(tbpSonglist);
            tbcMain.Controls.Add(tabPage2);
            tbcMain.Location = new Point(2, 75);
            tbcMain.Name = "tbcMain";
            tbcMain.SelectedIndex = 0;
            tbcMain.Size = new Size(743, 440);
            tbcMain.TabIndex = 0;
            // 
            // tbpSonglist
            // 
            tbpSonglist.Controls.Add(listView1);
            tbpSonglist.Location = new Point(4, 24);
            tbpSonglist.Name = "tbpSonglist";
            tbpSonglist.Padding = new Padding(3);
            tbpSonglist.Size = new Size(735, 412);
            tbpSonglist.TabIndex = 0;
            tbpSonglist.Text = "TopSong";
            tbpSonglist.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(6, 6);
            listView1.Name = "listView1";
            listView1.Size = new Size(722, 420);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(735, 432);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(621, 27);
            button1.Name = "button1";
            button1.Size = new Size(113, 31);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { topsongToolStripMenuItem, menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(746, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // topsongToolStripMenuItem
            // 
            topsongToolStripMenuItem.Name = "topsongToolStripMenuItem";
            topsongToolStripMenuItem.Size = new Size(67, 20);
            topsongToolStripMenuItem.Text = "Top song";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(79, 20);
            menuToolStripMenuItem.Text = "Favorite list";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 518);
            Controls.Add(button1);
            Controls.Add(tbcMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Wokeup";
            Load += MainForm_Load;
            tbcMain.ResumeLayout(false);
            tbpSonglist.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tbcMain;
        private TabPage tbpSonglist;
        private TabPage tabPage2;
        private ListView listView1;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem topsongToolStripMenuItem;
        private ToolStripMenuItem menuToolStripMenuItem;
    }
}
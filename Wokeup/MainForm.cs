using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Infrastructure;
using Infrastructure.DTO;

namespace Wokeup
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Image DownloadImage(string imageUrl)
        {
            WebClient webClient = new WebClient();
            byte[] imageByte = webClient.DownloadData(imageUrl);
            MemoryStream stream = new MemoryStream(imageByte);

            return Image.FromStream(stream);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            List<SongDTO> songs = SongRepository.GetAllSong();
            List<string> imageCollection = new List<string>();

            foreach (var song in songs)
            {
                imageCollection.Add(song.songImage);
            }
            


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(150, 150);

            for (int i = 0; i < imageCollection.Count; i++)
            {
                Image image = this.DownloadImage(imageCollection[i]);

                imgList.Images.Add(image);

                listView1.Items.Add(songs[i].songName, i);

            }
            listView1.LargeImageList = imgList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    // Get the first selected item (assuming single selection)
            //    ListViewItem selectedItem = listView1.SelectedItems[0];

            //    // Access data from the selected item's sub-items
            //    string name = selectedItem.Text; // Get the text from the first column (e.g., "Name")

            //    MessageBox.Show(name);
            //}
        }
    }
}

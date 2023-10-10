using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FavoriteList
    {
        public string name {  get; private set; }

        public User user { get; private set; }

        private List<Song> songCollection;
        public FavoriteList(string name, User owner)
        {
            this.name = name;
            this.user = owner;
            this.songCollection = new List<Song>();
        }

        public IReadOnlyList<Song> GetSongCollection() { 
            return songCollection; 
        }

        public bool AddSongToFavoriteList(Song song)
        {
            this.songCollection.Add(song);

            return true;
        }
    }
}

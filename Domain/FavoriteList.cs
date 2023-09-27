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

        public List<Song> songs { get; private set; }

        public FavoriteList(string name, User owner)
        {
            this.name = name;
            this.user = owner;
            this.songs = new List<Song>();
        }

        public bool AddSongToFavoriteList(Song song)
        {
            this.songs.Add(song);

            return true;
        }
    }
}
